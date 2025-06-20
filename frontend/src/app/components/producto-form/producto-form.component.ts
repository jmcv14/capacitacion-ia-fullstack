import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Producto } from '../../models/producto';
import { ProductoService } from '../../services/producto.service';

@Component({
  selector: 'app-producto-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatSnackBarModule
  ],
  templateUrl: './producto-form.component.html',
  styleUrl: './producto-form.component.scss'
})
export class ProductoFormComponent implements OnInit {
  productoForm: FormGroup;
  isEditMode = false;
  productoId: number | null = null;
  loading = false;

  constructor(
    private fb: FormBuilder,
    private productoService: ProductoService,
    private router: Router,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar
  ) {
    this.productoForm = this.fb.group({
      nombre: ['', [Validators.required, Validators.maxLength(100)]],
      descripcion: ['', [Validators.maxLength(500)]],
      precio: [0, [Validators.required, Validators.min(0)]],
      estado: [true]
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const id = params['id'];
      if (id) {
        this.isEditMode = true;
        this.productoId = +id;
        this.cargarProducto(this.productoId);
      }
    });
  }

  cargarProducto(id: number): void {
    this.loading = true;
    this.productoService.getProducto(id).subscribe({
      next: (producto) => {
        this.productoForm.patchValue(producto);
        this.loading = false;
      },
      error: (error) => {
        console.error('Error al cargar producto:', error);
        this.snackBar.open('Error al cargar el producto', 'Cerrar', {
          duration: 3000
        });
        this.loading = false;
        this.router.navigate(['/productos']);
      }
    });
  }

  onSubmit(): void {
    if (this.productoForm.valid) {
      this.loading = true;
      const producto: Producto = this.productoForm.value;

      if (this.isEditMode && this.productoId) {
        this.productoService.updateProducto(this.productoId, producto).subscribe({
          next: () => {
            this.snackBar.open('Producto actualizado exitosamente', 'Cerrar', {
              duration: 3000
            });
            this.router.navigate(['/productos']);
          },
          error: (error) => {
            console.error('Error al actualizar producto:', error);
            this.snackBar.open('Error al actualizar el producto', 'Cerrar', {
              duration: 3000
            });
            this.loading = false;
          }
        });
      } else {
        this.productoService.createProducto(producto).subscribe({
          next: () => {
            this.snackBar.open('Producto creado exitosamente', 'Cerrar', {
              duration: 3000
            });
            this.router.navigate(['/productos']);
          },
          error: (error) => {
            console.error('Error al crear producto:', error);
            this.snackBar.open('Error al crear el producto', 'Cerrar', {
              duration: 3000
            });
            this.loading = false;
          }
        });
      }
    } else {
      this.marcarCamposInvalidos();
    }
  }

  marcarCamposInvalidos(): void {
    Object.keys(this.productoForm.controls).forEach(key => {
      const control = this.productoForm.get(key);
      if (control?.invalid) {
        control.markAsTouched();
      }
    });
  }

  cancelar(): void {
    this.router.navigate(['/productos']);
  }

  getErrorMessage(fieldName: string): string {
    const field = this.productoForm.get(fieldName);
    if (field?.hasError('required')) {
      return 'Este campo es requerido';
    }
    if (field?.hasError('maxlength')) {
      const maxLength = field.getError('maxlength').requiredLength;
      return `Máximo ${maxLength} caracteres`;
    }
    if (field?.hasError('min')) {
      return 'El valor debe ser mayor o igual a 0';
    }
    return '';
  }
}

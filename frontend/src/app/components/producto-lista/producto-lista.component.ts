import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Producto } from '../../models/producto';
import { ProductoService } from '../../services/producto.service';

@Component({
  selector: 'app-producto-lista',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatSnackBarModule,
    MatDialogModule
  ],
  templateUrl: './producto-lista.component.html',
  styleUrl: './producto-lista.component.scss'
})
export class ProductoListaComponent implements OnInit {
  productos: Producto[] = [];
  displayedColumns: string[] = ['id', 'nombre', 'descripcion', 'precio', 'estado', 'acciones'];

  constructor(
    private productoService: ProductoService,
    private router: Router,
    private snackBar: MatSnackBar,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.cargarProductos();
  }

  cargarProductos(): void {
    this.productoService.getProductos().subscribe({
      next: (data) => {
        this.productos = data;
      },
      error: (error) => {
        console.error('Error al cargar productos:', error);
        this.snackBar.open('Error al cargar los productos', 'Cerrar', {
          duration: 3000
        });
      }
    });
  }

  editarProducto(id: number): void {
    this.router.navigate(['/productos/editar', id]);
  }

  eliminarProducto(id: number): void {
    if (confirm('¿Estás seguro de que quieres eliminar este producto?')) {
      this.productoService.deleteProducto(id).subscribe({
        next: () => {
          this.snackBar.open('Producto eliminado exitosamente', 'Cerrar', {
            duration: 3000
          });
          this.cargarProductos();
        },
        error: (error) => {
          console.error('Error al eliminar producto:', error);
          this.snackBar.open('Error al eliminar el producto', 'Cerrar', {
            duration: 3000
          });
        }
      });
    }
  }

  nuevoProducto(): void {
    this.router.navigate(['/productos/nuevo']);
  }
}

import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MatToolbarModule, MatButtonModule, MatIconModule],
  template: `
    <mat-toolbar color="primary">
      <span>Gestión de Productos</span>
      <span class="spacer"></span>
      <button mat-button routerLink="/productos">
        <mat-icon>list</mat-icon>
        Productos
      </button>
      <button mat-button routerLink="/productos/nuevo">
        <mat-icon>add</mat-icon>
        Nuevo
      </button>
    </mat-toolbar>
    
    <main>
      <router-outlet></router-outlet>
    </main>
  `,
  styles: [`
    .spacer {
      flex: 1 1 auto;
    }
    
    main {
      min-height: calc(100vh - 64px);
      background-color: #f5f5f5;
    }
    
    mat-toolbar {
      box-shadow: 0 2px 4px rgba(0,0,0,0.1);
    }
  `]
})
export class AppComponent {
  constructor(private router: Router) {}
}

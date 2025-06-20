# Frontend - Gestión de Productos

Aplicación frontend desarrollada con Angular 19 para gestionar productos, conectada al backend .NET 8.

## Características

- ✅ **Lista de productos** con tabla responsive
- ✅ **Formulario de creación** de nuevos productos
- ✅ **Formulario de edición** de productos existentes
- ✅ **Eliminación** de productos con confirmación
- ✅ **Diseño responsive** con Angular Material
- ✅ **Validaciones** de formularios
- ✅ **Notificaciones** con SnackBar
- ✅ **Navegación** entre componentes

## Tecnologías Utilizadas

- **Angular 19** - Framework principal
- **Angular Material** - Componentes UI
- **Angular Router** - Navegación
- **Angular Forms** - Formularios reactivos
- **Angular HttpClient** - Consumo de API
- **SCSS** - Estilos

## Estructura del Proyecto

```
src/
├── app/
│   ├── components/
│   │   ├── producto-lista/     # Lista de productos
│   │   └── producto-form/      # Formulario crear/editar
│   ├── models/
│   │   └── producto.ts         # Interfaz Producto
│   ├── services/
│   │   └── producto.service.ts # Servicio API
│   ├── app.component.ts        # Componente principal
│   ├── app.routes.ts          # Configuración de rutas
│   └── app.config.ts          # Configuración de la app
├── styles.scss                # Estilos globales
└── main.ts                   # Punto de entrada
```

## Instalación y Ejecución

1. **Instalar dependencias:**
   ```bash
   npm install
   ```

2. **Ejecutar en modo desarrollo:**
   ```bash
   npm start
   ```

3. **Acceder a la aplicación:**
   - Abrir navegador en: `http://localhost:4200`

## Funcionalidades

### Lista de Productos
- Muestra todos los productos en una tabla
- Botones para editar y eliminar cada producto
- Botón para crear nuevo producto
- Diseño responsive

### Formulario de Producto
- Campos: Nombre, Descripción, Precio, Estado
- Validaciones en tiempo real
- Modo creación y edición
- Navegación automática después de guardar

### API Integration
- Consume el backend en `https://localhost:7000`
- Manejo de errores con notificaciones
- Loading states durante operaciones

## Rutas

- `/` - Redirige a `/productos`
- `/productos` - Lista de productos
- `/productos/nuevo` - Crear nuevo producto
- `/productos/editar/:id` - Editar producto existente

## Desarrollo

### Generar componentes
```bash
ng generate component components/nombre-componente
```

### Build para producción
```bash
ng build
```

### Ejecutar tests
```bash
ng test
```

## Notas Importantes

- Asegúrate de que el backend esté ejecutándose en `https://localhost:7000`
- La aplicación usa CORS configurado en el backend
- Los estilos están optimizados para dispositivos móviles

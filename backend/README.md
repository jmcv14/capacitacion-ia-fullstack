# Productos API

API REST para gestión de productos desarrollada con .NET 8, ASP.NET Core Web API, Entity Framework Core y SQLite.

## Arquitectura

El proyecto sigue una arquitectura en capas:

- **Controllers**: Manejan las peticiones HTTP y respuestas
- **Services**: Contienen la lógica de negocio
- **Repositories**: Manejan el acceso a datos
- **Models**: Entidades y contexto de Entity Framework

## Características

- ✅ CRUD completo para productos
- ✅ Base de datos SQLite
- ✅ Entity Framework Core
- ✅ Swagger/OpenAPI para documentación
- ✅ Arquitectura en capas
- ✅ Inyección de dependencias
- ✅ Validaciones de modelo

## Modelo de Producto

```csharp
public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public bool Estado { get; set; }
}
```

## Endpoints

- `GET /api/productos` - Obtener todos los productos
- `GET /api/productos/{id}` - Obtener producto por ID
- `POST /api/productos` - Crear nuevo producto
- `PUT /api/productos/{id}` - Actualizar producto
- `DELETE /api/productos/{id}` - Eliminar producto

## Instalación y Ejecución

1. **Restaurar dependencias:**
   ```bash
   dotnet restore
   ```

2. **Ejecutar el proyecto:**
   ```bash
   dotnet run --project ProductosAPI.API
   ```

3. **Acceder a Swagger:**
   - Abrir navegador en: `https://localhost:7000` o `http://localhost:5000`

## Base de Datos

- La base de datos SQLite se crea automáticamente al ejecutar la aplicación
- Se incluyen datos de ejemplo (3 productos)
- El archivo de base de datos se crea en: `ProductosAPI.API/Productos.db`

## Tecnologías Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger/OpenAPI
- C# 12 
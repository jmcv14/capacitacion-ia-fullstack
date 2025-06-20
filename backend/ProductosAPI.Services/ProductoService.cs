using ProductosAPI.Models;
using ProductosAPI.Repositories;

namespace ProductosAPI.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> GetAllProductosAsync()
        {
            return await _productoRepository.GetAllAsync();
        }

        public async Task<Producto?> GetProductoByIdAsync(int id)
        {
            return await _productoRepository.GetByIdAsync(id);
        }

        public async Task<Producto> CreateProductoAsync(Producto producto)
        {
            return await _productoRepository.CreateAsync(producto);
        }

        public async Task<Producto> UpdateProductoAsync(int id, Producto producto)
        {
            var existingProducto = await _productoRepository.GetByIdAsync(id);
            if (existingProducto == null)
                throw new ArgumentException($"Producto con ID {id} no encontrado");

            existingProducto.Nombre = producto.Nombre;
            existingProducto.Descripcion = producto.Descripcion;
            existingProducto.Precio = producto.Precio;
            existingProducto.Estado = producto.Estado;

            return await _productoRepository.UpdateAsync(existingProducto);
        }

        public async Task<bool> DeleteProductoAsync(int id)
        {
            return await _productoRepository.DeleteAsync(id);
        }
    }
} 
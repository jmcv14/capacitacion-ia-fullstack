using Microsoft.AspNetCore.Mvc;
using ProductosAPI.Models;
using ProductosAPI.Services;

namespace ProductosAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns>Lista de productos</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            var productos = await _productoService.GetAllProductosAsync();
            return Ok(productos);
        }

        /// <summary>
        /// Obtiene un producto por su ID
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <returns>Producto encontrado</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            
            if (producto == null)
                return NotFound($"Producto con ID {id} no encontrado");

            return Ok(producto);
        }

        /// <summary>
        /// Crea un nuevo producto
        /// </summary>
        /// <param name="producto">Datos del producto</param>
        /// <returns>Producto creado</returns>
        [HttpPost]
        public async Task<ActionResult<Producto>> CreateProducto(Producto producto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productoCreado = await _productoService.CreateProductoAsync(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = productoCreado.Id }, productoCreado);
        }

        /// <summary>
        /// Actualiza un producto existente
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="producto">Datos actualizados del producto</param>
        /// <returns>Producto actualizado</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Producto>> UpdateProducto(int id, Producto producto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var productoActualizado = await _productoService.UpdateProductoAsync(id, producto);
                return Ok(productoActualizado);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Elimina un producto
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducto(int id)
        {
            var resultado = await _productoService.DeleteProductoAsync(id);
            
            if (!resultado)
                return NotFound($"Producto con ID {id} no encontrado");

            return NoContent();
        }
    }
} 
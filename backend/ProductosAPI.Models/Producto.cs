using System.ComponentModel.DataAnnotations;

namespace ProductosAPI.Models
{
    public class Producto
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string Descripcion { get; set; } = string.Empty;
        
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Precio { get; set; }
        
        [Required]
        public bool Estado { get; set; } = true;
    }
} 
using Microsoft.EntityFrameworkCore;

namespace ProductosAPI.Models
{
    public class ProductosDbContext : DbContext
    {
        public ProductosDbContext(DbContextOptions<ProductosDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración del modelo Producto
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.Precio).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.Estado).IsRequired();
            });

            // Datos de ejemplo
            modelBuilder.Entity<Producto>().HasData(
                new Producto { Id = 1, Nombre = "Laptop HP", Descripcion = "Laptop HP Pavilion 15", Precio = 899.99m, Estado = true },
                new Producto { Id = 2, Nombre = "Mouse Inalámbrico", Descripcion = "Mouse inalámbrico Logitech", Precio = 29.99m, Estado = true },
                new Producto { Id = 3, Nombre = "Teclado Mecánico", Descripcion = "Teclado mecánico RGB", Precio = 89.99m, Estado = true }
            );
        }
    }
} 
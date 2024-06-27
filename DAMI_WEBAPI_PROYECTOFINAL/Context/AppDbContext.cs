using DAMI_WEBAPI_PROYECTOFINAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAMI_WEBAPI_PROYECTOFINAL.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        // Por nombres de tablas
        public DbSet<UserModel> Users { get; set; }
        public DbSet<LibroModel> Libros { get; set; }
        public DbSet<PrestamoModel> Prestamos { get; set; }
        public DbSet<DetallePrestamoModel> DetallesPrestamos { get; set; }
    }
}

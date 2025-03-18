using Microsoft.EntityFrameworkCore;
using technical_tests_backend_ssr.Models;

namespace technical_tests_backend_ssr.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("Productos");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.Precio)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            entity.Property(p => p.Stock)
                .IsRequired();
        });
    }
}
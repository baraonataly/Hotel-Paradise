using Microsoft.EntityFrameworkCore;
using HotelParadiseAPI.Models;

namespace HotelParadiseAPI;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quarto>()
            .HasKey(q => q.Numero);
    }

    public DbSet<Hospede> Hospedes { get; set; } = null!;
    public DbSet<Quarto> Quartos { get; set; } = null!;
    public DbSet<Reserva> Reservas { get; set; } = null!;
}
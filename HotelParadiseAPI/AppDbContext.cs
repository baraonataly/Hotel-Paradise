using Microsoft.EntityFrameworkCore;
using HotelParadiseAPI.Models;

namespace HotelParadiseAPI;

public class AppDbContext : DbContext
{
    public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Hospede> Hospedes { get; set; }
}
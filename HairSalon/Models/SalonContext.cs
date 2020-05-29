using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models
{
  public class SalonContext : DbContext
  {
    public DbSet<Salon> Salon { get; set; }
    public DbSet<Client> Client { get; set; }

    public SalonContext(DbContextOptions options) : base(options) { }
  }
}
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models
{
  public class StylistContext : DbContext
  {
    public virtual DbSet<Stylist> Stylists { get; set; }
    public DbSet<Client> Clients { get; set; }

    public StylistContext(DbContextOptions options) : base(options) { }
  }
}
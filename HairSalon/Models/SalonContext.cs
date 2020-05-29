using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models
{
  public class SalonContext : DbContext
  {
    public DbSet<Salon> Salons { get; set; }
    public DbSet<Client> Clients { get; set; }

    public TableDataContext(DbContextOptions options) : base(options) { }
  }
}
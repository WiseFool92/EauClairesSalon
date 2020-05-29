using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    public Client()
    {
      this.Salon = new HashSet<Salon>();
    }
    public int ClientId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Contact { get; set; }
    public virtual ICollection<Salon> Salon { get; set; }
  }
}

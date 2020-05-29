using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TableData.Models
{
  public class Client
  {
    public Client()
    {
      this.Salons = new HashSet<Salon>();
    }

    public int ClientId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Contact { get; set; }
    public virtual ICollection<Salon> Salons { get; set; }
  }
}

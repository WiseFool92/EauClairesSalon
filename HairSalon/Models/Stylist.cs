using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    public int StylistId { get; set; }
    public string StylistName { get; set; }
    public string Specialty { get; set; }
    public virtual ICollection<Client> Client { get; set; }

    public Stylist()
    {
      this.Client = new HashSet<Client>();
    }
  }
}
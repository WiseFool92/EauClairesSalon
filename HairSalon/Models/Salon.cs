using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Salon
  {
    public int SalonId { get; set; }
    public string StylistName { get; set; }
    public string Specialty { get; set; }
    public virtual Client Client { get; set; }
  }
}
using Microsoft.AspNetCore.Mvc;
using TableData.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
  public class SalonController : Controller
  {
    private readonly SalonContext _db;

    public SalonController(SalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Salon> model = _db.Salon.ToList();
      return View("Index", model);
    }

     public ActionResult Create()
    {
      ViewBag.ClientId = new SelectList(_db.Client, "ClientId", "Type");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Salon salon)
    {
      _db.Salon.Add(salon);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Salon thisSalon = _db.Salon.FirstOrDefault(salon => salon.SalonId == id);
      return View("Details", thisSalon);
    }
  }
}



// Use to implement a search field for the user to compare offerings
    // [HttpPost]
    // public ActionResult index(string searchParameter)
    // {
    //   List<Salon> matchSalon = _db.Salon.Where(a => a.Type == searchParameter).ToList();
    //   return View("Index", matchSalon);
    // }
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using MySql.Data.MySqlClient;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    private readonly StylistContext _db;

    public StylistsController(StylistContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Stylist> model = _db.Stylists.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
     public ActionResult Create(Stylist stylist)
    {
      _db.Stylists.Add(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Stylist thisStylist = _db.Stylists.FirstOrDefault(stylists => stylists.StylistId == id);
      thisStylist.Clients = _db.Clients.Where(clients => clients.StylistId == id).ToList();
      return View(thisStylist);
    }

    public ActionResult Update(int id)
    {
      var thisStylist = _db.Stylists.FirstOrDefault(stylists => stylists.StylistId == id);
      return View(thisStylist);
    }

    [HttpPost]
    public ActionResult Update(Stylist stylist)
    {
      _db.Entry(stylist).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisStylist = _db.Stylists.FirstOrDefault(stylists => stylists.StylistId == id);
      return View(thisStylist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisStylist = _db.Stylists.FirstOrDefault(stylists => stylists.StylistId == id);
      _db.Stylists.Remove(thisStylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/search")]
    public ActionResult StylistSearch(string searchStylist, string searchStylistParam)
    {
      var model = from search in _db.Stylists select search;
      List<Stylist> matchesStylist = new List<Stylist> { };

      if (!string.IsNullOrEmpty(searchStylist))
      {
        if (searchStylistParam == "Name")
        {
          model = model.Where(entry => entry.StylistName.Contains(searchStylist));

        }
        else
        {
          model = model.Where(entry => entry.Specialty.Contains(searchStylist));
        }
      }

      matchesStylist = model.ToList();
      return View(matchesStylist);
    }
  }
}
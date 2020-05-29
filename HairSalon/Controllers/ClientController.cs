using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    private readonly SalonContext _db;

    public ClientController(SalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Client> model = _db.Client.ToList();
      return View("Index", model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Client client)
    {
      _db.Client.Add(client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Client thisClient = _db.Client.FirstOrDefault(client => client.ClientId == id);
      return View("Details", thisClient);
    }

    public ActionResult Update(int id)
    {
      var thisClient = _db.Client.FirstOrDefault(client => client.ClientId == id);
      return View("Update", thisClient);
    }

    [HttpPost]
    public ActionResult Update(Client client)
    {
      _db.Entry(client).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisClient = _db.Client.FirstOrDefault(client => client.ClientId == id);
      return View(thisClient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisClient = _db.Client.FirstOrDefault(client => client.ClientId == id);
      _db.Client.Remove(thisClient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
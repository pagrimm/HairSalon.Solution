using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly HairSalonContext _db;
    
    public ClientsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index(string searchQuery = null)
    {
      if (searchQuery != null)
      {
        ViewBag.SearchFlag = 1;
        List<Client> searchList = _db.Clients.Include(client => client.Stylist).Where(client => client.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
        return View(searchList);
      }
      else
      {
        ViewBag.SearchFlag = 0;
        List<Client> allClients = _db.Clients.Include(clients => clients.Stylist).ToList();
        return View(allClients);
      }
    }

    public ActionResult New()
    {
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult New(Client client)
    {
      _db.Clients.Add(client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    
    public ActionResult Show(int id)
    {
      Client model = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      return View(model);
    }

    public ActionResult Edit(int id)
    {
      Client model = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
      return View(model);
    }

    [HttpPost]
    public ActionResult Edit(Client client)
    {
      _db.Entry(client).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Destroy(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      _db.Clients.Remove(thisClient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    private readonly HairSalonContext _db;
    
    public StylistsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Client> allClients = _db.Clients.Include(clients => clients.Stylist).ToList();
      return View(allClients);
    }

    public ActionResult New()
    {
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
      
    }

    public ActionResult Edit(int id)
    {
      
    }

    [HttpPost]
    public ActionResult Destroy(int id)
    {
      
    }
  }
}
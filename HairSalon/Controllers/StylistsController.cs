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
      List<Stylist> allStylists = _db.Stylists.ToList();
      return View(allStylists);
    }

    public ActionResult New()
    {
      return View();
    }

    [HttpPost]
    public ActionResult New(Stylist stylist)
    {
      _db.Stylists.Add(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Show(int id)
    {
      Stylist model = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      return View(model);
    }

    public ActionResult Edit(int id)
    {
      Stylist model = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      return View(model);
    }

    [HttpPost]
    public ActionResult Edit(Stylist stylist)
    {
      _db.Entry(stylist).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Destroy(int id)
    {
      Stylist thisStylist = _db.Clients.FirstOrDefault(stylist => stylist.StylistId == id);
      _db.Stylists.Remove(thisStylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    private readonly HairSalonContext _db;
    
    public StylistsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index(string searchQuery = null)
    {
      if (searchQuery != null)
      {
        ViewBag.SearchFlag = 1;
        List<Stylist> searchList = _db.Stylists.Where(stylist => stylist.Name.Contains(searchQuery)).ToList();
        return View(searchList);
      }
      else
      {
        ViewBag.SearchFlag = 0;
        List<Stylist> allStylists = _db.Stylists.ToList();
        return View(allStylists);
      }
    }

    public ActionResult SearchResults (List<Stylist> inputList)
    {
      return View(inputList);
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
      Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      _db.Stylists.Remove(thisStylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
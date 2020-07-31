using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {
    private readonly HairSalonContext _db;
    
    public HomeController(HairSalonContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Index(string searchOption, string searchString)
    {
      if (searchOption == "clients")
      {
        return RedirectToAction ("Index", "Clients", new {searchQuery = searchString});
      }
      else
      {
        return RedirectToAction ("Index", "Stylists", new {searchQuery = searchString});
      }
    }
  }
}
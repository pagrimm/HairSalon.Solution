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

    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      
    }

    [HttpGet("/stylists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/stylists")]
    public ActionResult New(Cuisine cuisine)
    {
      
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
      
    }

    [HttpGet("/stylists/{id}/edit")]
    public ActionResult Edit(int id)
    {
      
    }

    [HttpPost("/stylists/{id}")]
    public ActionResult Destroy(int id)
    {
      
    }
  }
}
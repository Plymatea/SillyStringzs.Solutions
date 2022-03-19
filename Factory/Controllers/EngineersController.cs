using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "Your Army:";
      List<Engineer> model = _db.Engineers.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "Create Engineer";
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
      
    public ActionResult Details(int id)
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      var thisEngineer = _db.Engineers
          .Include(engineer => engineer.JoinEntities)
          .ThenInclude(join => join.Machine)
          .FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.PageTitle = thisEngineer.Name;
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult MachineAdd(int EngineerId, int MachineId)
    {
    if (MachineId != 0)
    {
        _db.MachineEngineer.Add(new MachineEngineer() { MachineId = MachineId, EngineerId = EngineerId });
        _db.SaveChanges();
    }
      return RedirectToAction("Details", new {id = EngineerId});
    }
  }
}
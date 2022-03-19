using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Linq;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      ViewBag.PageTitle = "ToolBox for world domination";
      List<Machine> model = _db.Machines.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.PageTitle = "Install Machine";
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index", "Machines"); 
    }
    public ActionResult Details(int id)
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      var thisMachine = _db.Machines
          .Include(machine => machine.JoinEntities)
          .ThenInclude(join => join.Engineer)
          .FirstOrDefault(engineer => engineer.MachineId == id);
      ViewBag.PageTitle = thisMachine.Name;
      return View(thisMachine);
    }
    [HttpPost]
    public ActionResult MachineAdd(int EngineerId, int MachineId)
    {
    if (EngineerId != 0)
    {
      _db.MachineEngineer.Add(new MachineEngineer() { MachineId = MachineId, EngineerId = EngineerId });
      _db.SaveChanges();
    }
      return RedirectToAction("Details", new {id = MachineId});
    }
    
  }
}
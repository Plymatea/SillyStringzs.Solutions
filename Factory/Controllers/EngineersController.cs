using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using System;

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
      if (String.IsNullOrEmpty(engineer.Name))
      {
        return RedirectToAction("Index");
      } else
      {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
      }
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
    public ActionResult Edit (int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(entry => entry.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit (Engineer engineer)
    {
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new{ id = engineer.EngineerId});
    }

    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(entry => entry.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(entry => entry.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
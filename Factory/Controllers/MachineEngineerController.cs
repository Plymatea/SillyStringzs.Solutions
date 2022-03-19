using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Linq;

namespace Factory.Controllers
{
  public class MachineEngineerController : Controller
  {
    private readonly FactoryContext _db;

    public MachineEngineerController(FactoryContext db)
    {
      _db = db;
    }
    [HttpPost]
    public ActionResult DeleteMachine(int joinId)
    {
    var thisItem = _db.MachineEngineer.FirstOrDefault(entry => entry.MachineEngineerId == joinId);
    _db.MachineEngineer.Remove(thisItem);
    _db.SaveChanges();
    return RedirectToAction("Details", "Engineers", new {id = thisItem.EngineerId});
    }
        [HttpPost]
    public ActionResult DeleteEngineer(int joinId)
    {
    var thisItem = _db.MachineEngineer.FirstOrDefault(entry => entry.MachineEngineerId == joinId);
    _db.MachineEngineer.Remove(thisItem);
    _db.SaveChanges();
    return RedirectToAction("Details", "Machines", new {id = thisItem.MachineId});
    }
  }
}
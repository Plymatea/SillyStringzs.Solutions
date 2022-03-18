using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
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
      List<Machine> model = _db.Machines.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      // ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "DepartmentMachineAbv");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index", "Machines"); 
    }

    // public ActionResult Details(int id)
    // {
    //   Client thisClient = _db.Clients.FirstOrDefault(c => c.ClientId == id);
    //   return View(thisClient);
    // }

    
  }
}
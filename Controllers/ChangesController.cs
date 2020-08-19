using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConserviceHRSite.Models;

namespace ConserviceHRSite.Controllers
{
    public class ChangesController : Controller
    {
        private readonly ConserviceTeam _context;

        public ChangesController(ConserviceTeam context)
        {
            _context = context;
        }

        // GET: Changes
        public async Task<IActionResult> Index(int? id)
        {
            
            var changes = from c in _context.Changes
                           select c;
            

            if (id!=null)
            {
                changes = changes.Where(c => c.EmployeeID.Equals(id));
            }
            await _context.Employee.ToListAsync();
            if (changes.Count() > 0)
            {
                ViewData["CurrentEmployee"] = "Changes For "+changes.First().Employee.Name;
            }
            else
            {
                ViewData["CurrentEmployee"] = "No Changes Found";
            }
            ViewData["EmployeeID"] = id;
           
            return View(await changes.AsNoTracking().ToListAsync());
        }

        

        // GET: Changes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Changes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,Description")] Changes changes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(changes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(changes);
        }

        
    }
}

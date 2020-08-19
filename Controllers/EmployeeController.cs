using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConserviceHRSite.Models;

namespace ConserviceHRSite.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ConserviceTeam _context;

        public EmployeeController(ConserviceTeam context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index(string sortOrder, string searchString, string departmentGenre)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            await _context.Department.ToListAsync();
            IQueryable<String> departmentQuery = from m in _context.Employee
                                            orderby m.Department.Name
                                            select m.Department.Name;

            var employees = from e in _context.Employee
                           select e;

           
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.Name.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(departmentGenre))
            {
                employees = employees.Where(x => x.Department.Name == departmentGenre);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(s => s.Name);
                    break;
                default:
                    employees = employees.OrderBy(s => s.Name);
                    break;
            }

            var departmentVM = new DepartmentViewModel
            {
                Departments = new SelectList(await departmentQuery.Distinct().ToListAsync()),
                Employees = await employees.ToListAsync()
            };

            await _context.Department.ToListAsync();
            await _context.Position.ToListAsync();
            await _context.Employee.ToListAsync();
            return View(departmentVM);
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _context.Department.ToListAsync();
            await _context.Position.ToListAsync();
            await _context.Employee.ToListAsync();
            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }
            
            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            PopulatePoitionsDropDownList();
            PopulateManagerDropDownList();
            return View();
        }

        public IActionResult Reporting()
        {
            calculateWeeklyHires();
            calculateYearlyTerminations();
            return View();
        }

        public async Task<IActionResult> Permissions()
        {
            return View(await _context.Employee.ToListAsync());
        }

        public void calculateWeeklyHires()
        {
            var employeeQuery = from e in _context.Employee
                                   select e;

            CultureInfo myCI = new CultureInfo("en-US");
            Calendar myCal = myCI.Calendar;
            DateTime today= DateTime.Today;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            int currentWeek = myCal.GetWeekOfYear(today, myCWR, myFirstDOW);

            int count = 0;
            foreach(var employee in employeeQuery)
            {
                int startWeek = myCal.GetWeekOfYear(employee.StartDate, myCWR, myFirstDOW);
                if(startWeek == currentWeek)
                {
                    count++;
                }
            }

            ViewBag.WeeklyHires = count;
        }

        public void calculateYearlyTerminations()
        {
            var employeeQuery = from e in _context.Employee
                                select e;

            DateTime today = DateTime.Today;

            int currentYear = today.Year;

            int count = 0;
            foreach (var employee in employeeQuery)
            {
                if (employee.EndDate != null)
                {
                    DateTime currentDate = (DateTime) employee.EndDate;
                    if(currentDate.Year == currentYear)
                    {
                        count++;
                    }
                }
               
            }

            ViewBag.YearlyTerminations = count;
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address,Email,Phone,PositionID,DepartmentID,StartDate,EndDate,Status,Shift,ManagerID,Photo,Color,Permission")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await _context.Department.ToListAsync();
            await _context.Position.ToListAsync();
            await _context.Employee.ToListAsync();
            PopulateDepartmentsDropDownList(employee.DepartmentID);
            PopulatePoitionsDropDownList(employee.PositionID);
            PopulateManagerDropDownList(employee.ManagerID);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _context.Department.ToListAsync();
            await _context.Position.ToListAsync();
            await _context.Employee.ToListAsync();
            var employee = await _context.Employee
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }
            PopulateDepartmentsDropDownList(employee.DepartmentID);
            PopulatePoitionsDropDownList(employee.PositionID);
            PopulateManagerDropDownList(employee.ManagerID);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            await _context.Department.ToListAsync();
            await _context.Position.ToListAsync();
            await _context.Employee.ToListAsync();
            var employeeToUpdate = await _context.Employee
                .FirstOrDefaultAsync(c => c.ID == id);

            if (await TryUpdateModelAsync<Employee>(employeeToUpdate,
                "",
                 c => c.Name,c => c.Address,c => c.Email,c => c.Phone,c => c.PositionID,c => c.DepartmentID,c => c.StartDate,c => c.EndDate,c => c.Status,c => c.Shift,c => c.ManagerID,c => c.Photo, c => c.Color,c => c.Permission))
            {
                Dictionary<string, System.Tuple<object, object>> modified =
                _context.Entry(employeeToUpdate)
                    .Properties.Where(p => p.IsModified)
                    .ToDictionary(p => p.Metadata.Name, p => new System.Tuple<object, object>(p.OriginalValue, p.CurrentValue));
                foreach(var change in modified)
                {
                    switch (change.Key)
                    {
                        case "Permission":
                            ChangesController newPermissionController = new ChangesController(_context);
                            Changes newPermissionChange = new Changes();
                            newPermissionChange.Date = DateTime.Today;
                            newPermissionChange.EmployeeID = employeeToUpdate.ID;
                            newPermissionChange.ChangeType = ChangeType.Permission;
                            newPermissionChange.Description = "Permissions changed from " + change.Value.Item1 + " to " + change.Value.Item2;
                            await newPermissionController.Create(newPermissionChange);
                            //add a permision change to database
                            break;
                        case "ManagerID":
                            ChangesController newManagerController = new ChangesController(_context);
                            Changes newManagerChange = new Changes();
                            newManagerChange.Date = DateTime.Today;
                            newManagerChange.EmployeeID = employeeToUpdate.ID;
                            newManagerChange.ChangeType = ChangeType.Manager;
                            var employeeQuery = from p in _context.Employee
                                                 orderby p.Name
                                                 select p;
                            String oldManager = "";
                            String newManager = "";
                            foreach (Employee employee in employeeQuery)
                            {
                                if (employee.ID == (int)change.Value.Item1)
                                {
                                    oldManager = employee.Name;
                                }
                                if (employee.ID == (int)change.Value.Item2)
                                {
                                    newManager = employee.Name;
                                }
                            }
                            newManagerChange.Description = "Manager changed from " + oldManager + " to " + newManager;
                            await newManagerController.Create(newManagerChange);
                            //add a manager change to database
                            break;
                        case "PositionID":
                            ChangesController newPositionController = new ChangesController(_context);
                            Changes newPositionChange = new Changes();
                            newPositionChange.Date = DateTime.Today;
                            newPositionChange.EmployeeID = employeeToUpdate.ID;
                            newPositionChange.ChangeType = ChangeType.Permission;
                            var positionsQuery = from p in _context.Position
                                                 orderby p.Name
                                                 select p;
                            String oldPosition = "";
                            String newPosition = "";
                            foreach(Position position in positionsQuery)
                            {
                                if (position.ID == (int) change.Value.Item1)
                                {
                                    oldPosition = position.Name;
                                }
                                if (position.ID == (int)change.Value.Item2)
                                {
                                    newPosition = position.Name;
                                }
                            }
                            newPositionChange.Description = "Position changed from " + oldPosition +" to "+newPosition;
                            await newPositionController.Create(newPositionChange);
                            //add a position change to database
                            break;
                        
                    }
                }
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateDepartmentsDropDownList(employeeToUpdate.DepartmentID);
            PopulatePoitionsDropDownList(employeeToUpdate.PositionID);
            PopulateManagerDropDownList(employeeToUpdate.ManagerID);
            return View(employeeToUpdate);
        }

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Department
                                   orderby d.Name
                                   select d;
            ViewBag.DepartmentID = new SelectList(departmentsQuery.AsNoTracking(), "ID", "Name", selectedDepartment);
        }

        private void PopulatePoitionsDropDownList(object selectedPosition = null)
        {
            var positionsQuery = from p in _context.Position
                                   orderby p.Name
                                   select p;
            ViewBag.PositionID = new SelectList(positionsQuery.AsNoTracking(), "ID", "Name", selectedPosition);
        }
        
        private void PopulateManagerDropDownList(object selectedManager = null)
        {
            var managersQuery = (from m in _context.Employee
                                 join p in _context.Position
                                 on m.PositionID equals p.ID
                                 where p.Name == "Manager"
                                 select new
                                 {
                                     Name = m.Name,
                                     ID = m.ID,
                                     Position = p.Name
                                 }
                                ).ToList();
           
            ViewBag.ManagerID = new SelectList(managersQuery, "ID", "Name", selectedManager);
            
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _context.Department.ToListAsync();
            await _context.Position.ToListAsync();
            await _context.Employee.ToListAsync();
            var employee = await _context.Employee
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Department.ToListAsync();
            await _context.Position.ToListAsync();
            await _context.Employee.ToListAsync();
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.ID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bangazon_Workforce_Management.Models;
using Bangazon_Workforce_Management.Models.ViewModel;

namespace Bangazon_Workforce_Management.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly Bangazon_Workforce_ManagementContext _context;

        public EmployeesController(Bangazon_Workforce_ManagementContext context)
        {
            _context = context;    
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var bangazon_Workforce_ManagementContext = _context.Employee.Include(e => e.Department);
            return View(await bangazon_Workforce_ManagementContext.ToListAsync());
        }

        // GET: Employees/Details/5
        //This method was authored by Azim Sodikov
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .Include("ComputerEmployee.Computer")
                .Include("TrainingProgramEmployee.TrainingProgram")
                .SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DeptID"] = new SelectList(_context.Department, "DeptID", "DeptName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,FirstName,LastName,StartDate,Supervisor,DeptID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DeptID"] = new SelectList(_context.Department, "DeptID", "DeptName", employee.DeptID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        ////This method was authored by Jordan Dhaenens, Azim Sodikov, Andrew Rock
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }
            var vm = new EmployeeEditVM();
            vm.Employee = employee;
            //Grabs unassigned computers from ComputerEmployee and Computer tables
            IEnumerable<Computer> assignedComps = from ce in _context.ComputerEmployee
                                   from c in _context.Computer
                                   where ce.End == null
                                   where ce.ComputerID == c.ComputerID
                                   select c;

            IEnumerable<Computer> allComps = from c in _context.Computer
                           where c.DecomissionDate == null
                              select c;

            IEnumerable<Computer> unassignedComps = allComps.Except(assignedComps);

            
            ViewData["DeptID"] = new SelectList(_context.Department, "DeptID", "DeptName", employee.DeptID);
            ViewData["ComputerID"] = new SelectList(unassignedComps, "ComputerID", "Make", vm.ComputerEmployee.ComputerID);

            return View(vm);
        }

        // POST: Employees/Edit/5
        //This method is authored by Jordan Dhaenens and Azim 
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeEditVM employeeEditVM)
        {


            if (id != employeeEditVM.Employee.EmployeeID)
            {
                return NotFound();
            }
            
            

            employeeEditVM.ComputerEmployee.EmployeeID = id;
            //Does the employee currently have a computer? Then we need to update that entry, end its assignment and the create a new entry for that employee
            var existsInComputerEmployee = await _context.ComputerEmployee
                .SingleOrDefaultAsync(e => e.EmployeeID == id && e.End == null);
            //If there is an instance of ComputerEmployee that matches the update criteria
            if (existsInComputerEmployee != null)
            {
                //This sets the ComputerEmployeeID of the entry that needs their End date updated
                existsInComputerEmployee.End = DateTime.Now;
            }
            employeeEditVM.ComputerEmployee.Start = DateTime.Now;

            if (ModelState.IsValid)
            {
                
                try
                {
                    //This is to update employee name and DepartmentID
                    _context.Update(employeeEditVM.Employee);
                    if (existsInComputerEmployee != null)
                    {
                        _context.Update(existsInComputerEmployee);
                    } 
                    if (employeeEditVM.ComputerEmployee.ComputerID != 0)
                    {
                        _context.Add(employeeEditVM.ComputerEmployee);
                    }
                    
                    //This saves all changes
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employeeEditVM.Employee.EmployeeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");      
            }
            ViewData["DeptID"] = new SelectList(_context.Department, "DeptID", "DeptName", employeeEditVM.Employee.DeptID);
            ViewData["ComputerID"] = new SelectList(_context.Computer, "ComputerID", "Make", employeeEditVM.ComputerEmployee.ComputerID);
            return View(employeeEditVM);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.EmployeeID == id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeID == id);
        }
    }
}

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


            ViewData["DeptID"] = new SelectList(_context.Department, "DeptID", "DeptName", employee.DeptID);
            ViewData["ComputerID"] = new SelectList(_context.Computer, "ComputerID", "Make", vm.ComputerEmployee.ComputerID);

            EmployeeEditVM test = vm;
            return View(vm);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeEditVM employeeEditVM)
        {
            employeeEditVM.ComputerEmployee.EmployeeID = id;

            var compEmp = await _context.ComputerEmployee.SingleOrDefaultAsync(c => c.ComputerID == employeeEditVM.ComputerEmployee.ComputerID && c.EmployeeID == id && employeeEditVM.ComputerEmployee.End == null);
            employeeEditVM.ComputerEmployee.ComputerEmployeeID = compEmp.ComputerEmployeeID;

            if (id != employeeEditVM.Employee.EmployeeID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(employeeEditVM.Employee);
                    _context.Update(employeeEditVM.ComputerEmployee);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bangazon_Workforce_Management.Models;

namespace Bangazon_Workforce_Management.Controllers
{
    public class ComputerEmployeesController : Controller
    {
        private readonly Bangazon_Workforce_ManagementContext _context;

        public ComputerEmployeesController(Bangazon_Workforce_ManagementContext context)
        {
            _context = context;    
        }

        // GET: ComputerEmployees
        public async Task<IActionResult> Index()
        {
            var bangazon_Workforce_ManagementContext = _context.ComputerEmployee.Include(c => c.Computer).Include(c => c.Employee);
            return View(await bangazon_Workforce_ManagementContext.ToListAsync());
        }

        // GET: ComputerEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computerEmployee = await _context.ComputerEmployee
                .Include(c => c.Computer)
                .Include(c => c.Employee)
                .SingleOrDefaultAsync(m => m.ComputerEmployeeID == id);
            if (computerEmployee == null)
            {
                return NotFound();
            }

            return View(computerEmployee);
        }

        // GET: ComputerEmployees/Create
        public IActionResult Create()
        {
            ViewData["ComputerID"] = new SelectList(_context.Computer, "ComputerID", "Make");
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "FirstName");
            return View();
        }

        // POST: ComputerEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComputerEmployeeID,EmployeeID,ComputerID,Start,End")] ComputerEmployee computerEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(computerEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ComputerID"] = new SelectList(_context.Computer, "ComputerID", "Make", computerEmployee.ComputerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "FirstName", computerEmployee.EmployeeID);
            return View(computerEmployee);
        }

        // GET: ComputerEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computerEmployee = await _context.ComputerEmployee.SingleOrDefaultAsync(m => m.ComputerEmployeeID == id);
            if (computerEmployee == null)
            {
                return NotFound();
            }
            ViewData["ComputerID"] = new SelectList(_context.Computer, "ComputerID", "Make", computerEmployee.ComputerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "FirstName", computerEmployee.EmployeeID);
            return View(computerEmployee);
        }

        // POST: ComputerEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComputerEmployeeID,EmployeeID,ComputerID,Start,End")] ComputerEmployee computerEmployee)
        {
            if (id != computerEmployee.ComputerEmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(computerEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComputerEmployeeExists(computerEmployee.ComputerEmployeeID))
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
            ViewData["ComputerID"] = new SelectList(_context.Computer, "ComputerID", "Make", computerEmployee.ComputerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "FirstName", computerEmployee.EmployeeID);
            return View(computerEmployee);
        }

        // GET: ComputerEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computerEmployee = await _context.ComputerEmployee
                .Include(c => c.Computer)
                .Include(c => c.Employee)
                .SingleOrDefaultAsync(m => m.ComputerEmployeeID == id);
            if (computerEmployee == null)
            {
                return NotFound();
            }

            return View(computerEmployee);
        }

        // POST: ComputerEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var computerEmployee = await _context.ComputerEmployee.SingleOrDefaultAsync(m => m.ComputerEmployeeID == id);
            _context.ComputerEmployee.Remove(computerEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ComputerEmployeeExists(int id)
        {
            return _context.ComputerEmployee.Any(e => e.ComputerEmployeeID == id);
        }
    }
}

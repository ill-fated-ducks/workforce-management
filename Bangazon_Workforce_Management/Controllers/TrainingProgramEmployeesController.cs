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
    public class TrainingProgramEmployeesController : Controller
    {
        private readonly Bangazon_Workforce_ManagementContext _context;

        public TrainingProgramEmployeesController(Bangazon_Workforce_ManagementContext context)
        {
            _context = context;    
        }

        // GET: TrainingProgramEmployees
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrainingProgramEmployee.ToListAsync());
        }

        // GET: TrainingProgramEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingProgramEmployee = await _context.TrainingProgramEmployee
                .SingleOrDefaultAsync(m => m.TrainingProgramEmployeeID == id);
            if (trainingProgramEmployee == null)
            {
                return NotFound();
            }

            return View(trainingProgramEmployee);
        }

        // GET: TrainingProgramEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingProgramEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingProgramEmployeeID,TrainingProgramID,EmployeeID")] TrainingProgramEmployee trainingProgramEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingProgramEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(trainingProgramEmployee);
        }

        // GET: TrainingProgramEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingProgramEmployee = await _context.TrainingProgramEmployee.SingleOrDefaultAsync(m => m.TrainingProgramEmployeeID == id);
            if (trainingProgramEmployee == null)
            {
                return NotFound();
            }
            return View(trainingProgramEmployee);
        }

        // POST: TrainingProgramEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainingProgramEmployeeID,TrainingProgramID,EmployeeID")] TrainingProgramEmployee trainingProgramEmployee)
        {
            if (id != trainingProgramEmployee.TrainingProgramEmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingProgramEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingProgramEmployeeExists(trainingProgramEmployee.TrainingProgramEmployeeID))
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
            return View(trainingProgramEmployee);
        }

        // GET: TrainingProgramEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingProgramEmployee = await _context.TrainingProgramEmployee
                .SingleOrDefaultAsync(m => m.TrainingProgramEmployeeID == id);
            if (trainingProgramEmployee == null)
            {
                return NotFound();
            }

            return View(trainingProgramEmployee);
        }

        // POST: TrainingProgramEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainingProgramEmployee = await _context.TrainingProgramEmployee.SingleOrDefaultAsync(m => m.TrainingProgramEmployeeID == id);
            _context.TrainingProgramEmployee.Remove(trainingProgramEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TrainingProgramEmployeeExists(int id)
        {
            return _context.TrainingProgramEmployee.Any(e => e.TrainingProgramEmployeeID == id);
        }
    }
}

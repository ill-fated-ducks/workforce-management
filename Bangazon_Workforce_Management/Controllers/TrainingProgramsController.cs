using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bangazon_Workforce_Management.Models;
using Bangazon_Workforce_Management.ViewModels;

namespace Bangazon_Workforce_Management.Controllers
{
    public class TrainingProgramsController : Controller
    {
        private readonly Bangazon_Workforce_ManagementContext _context;

        public TrainingProgramsController(Bangazon_Workforce_ManagementContext context)
        {
            _context = context;    
        }

        // GET: TrainingPrograms
        public async Task<IActionResult> Index()
        {
            IEnumerable<TrainingProgram> programs = await _context.TrainingProgram.Where<TrainingProgram>(p => p.StartDate > DateTime.Now).ToListAsync();
            return View(programs);
        }

        // GET: TrainingPrograms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var trainingProgram = await _context.TrainingProgram
                .SingleOrDefaultAsync(m => m.TrainingProgramID == id);
            if (trainingProgram == null)
            {
                return NotFound();
            }

            return View(trainingProgram);*/
            TrainingProgram program = await _context.TrainingProgram
                .SingleOrDefaultAsync(t => t.TrainingProgramID == id);
            IEnumerable<TrainingProgramEmployee> TPEs = await _context.TrainingProgramEmployee.Where(t => t.TrainingProgramID == id).Include(t => t.Employee).ToListAsync();
            TrainingEmployeeViewModel something = new TrainingEmployeeViewModel(TPEs, program) { };

            return View(something);
        }

        // GET: TrainingPrograms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingPrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingProgramID,Name,Description,StartDate,EndDate,MaxAttendees")] TrainingProgram trainingProgram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(trainingProgram);
        }

        // GET: TrainingPrograms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingProgram = await _context.TrainingProgram.SingleOrDefaultAsync(m => m.TrainingProgramID == id);
            if (trainingProgram == null)
            {
                return NotFound();
            }
            return View(trainingProgram);
        }

        // POST: TrainingPrograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainingProgramID,Name,Description,StartDate,EndDate,MaxAttendees")] TrainingProgram trainingProgram)
        {
            if (id != trainingProgram.TrainingProgramID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingProgramExists(trainingProgram.TrainingProgramID))
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
            return View(trainingProgram);
        }

        // GET: TrainingPrograms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingProgram = await _context.TrainingProgram
                .SingleOrDefaultAsync(m => m.TrainingProgramID == id);
            if (trainingProgram == null)
            {
                return NotFound();
            }

            return View(trainingProgram);
        }

        // POST: TrainingPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainingProgram = await _context.TrainingProgram.SingleOrDefaultAsync(m => m.TrainingProgramID == id);
            _context.TrainingProgram.Remove(trainingProgram);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TrainingProgramExists(int id)
        {
            return _context.TrainingProgram.Any(e => e.TrainingProgramID == id);
        }
    }
}

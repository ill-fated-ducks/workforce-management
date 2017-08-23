using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bangazon_Workforce_Management.Models;
using Microsoft.EntityFrameworkCore;
using Bangazon_Workforce_Management.ViewModels;

namespace Bangazon_Workforce_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly Bangazon_Workforce_ManagementContext _context;

        public HomeController(Bangazon_Workforce_ManagementContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sortedEmployees = _context.Employee.OrderBy(e => e.StartDate).Include(d => d.Department).Take(5);

            var sortedPrograms = from p in _context.TrainingProgram
                                 where p.StartDate > DateTime.Now && p.StartDate <= DateTime.Now.AddDays(30)
                                 select p;

            var homePageView = new HomePageViewModel(sortedEmployees, sortedPrograms);
            
            return View(homePageView);
            
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

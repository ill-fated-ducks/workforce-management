using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bangazon_Workforce_Management.Models;
using Microsoft.EntityFrameworkCore;

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
            var bangazon_Workforce_ManagementContext = _context.Employee.Include(e => e.Department);
            return View(await bangazon_Workforce_ManagementContext.ToListAsync());
            
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

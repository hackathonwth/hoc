using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HOC.Models;
using HOC.Entities.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace HOC.Controllers
{
    public class ApprovalController : Controller
    {
        private HOCContext context;

        public ApprovalController(HOCContext _context)

        {
            this.context = _context;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Get()
        {
            ViewData["Message"] = "Your application description page.";

            var displayData = this.context.Projects.Select(x =>
                new
                {
                    x.Id,
                    x.Name,
                    x.StartDate,
                    x.EndDate,
                    CurrentStatus = x.Status.Name
                }).ToList();

            return new JsonResult(displayData);
        }

        public IActionResult Approve()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

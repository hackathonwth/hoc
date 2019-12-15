using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HOC.Entities.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOC.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly HOCContext _context;

        public ScheduleController(HOCContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index(string UserType, string UserId)
        {
            List<Projects> projects = new List<Projects>();
            projects = _context.Projects.Where(x =>
                x.Stage == Entities.Models.ProjectStage.Approved).ToList();

            var data = projects.Select(x => 
                new Schedules{
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate });

            return View(data);
        }

    }
}

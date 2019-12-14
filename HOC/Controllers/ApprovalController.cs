using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HOC.Models;
using HOC.Entities.Models.DB;
using Microsoft.EntityFrameworkCore;
using HOC.Entities.Models;
using HOC.BusinessService;
using Newtonsoft.Json;

namespace HOC.Controllers
{
    public class ApprovalController : Controller
    {
        private HOCContext context;
        private Projects currentProject;

        public ApprovalController(HOCContext _context)

        {
            this.context = _context;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Get(string projectId)
        {
            int id = Int32.Parse(projectId);
            ViewData["Message"] = "Your application description page.";

            currentProject = this.context.Projects.First(x => x.Id == id);
            var data = new ApprovalProjectDisplay
            (
                currentProject.Name,
                currentProject.Description,
                currentProject.StartDate,
                currentProject.EndDate,
                currentProject.Stage
            );

            return this.Json(data);
        }

        public IActionResult Judge(string data)
        {
            ViewData["Message"] = "Determine application acceptance the application";
            var jObj = JsonConvert.DeserializeObject<JudgeObject>(data);
            ProjectStage stage = jObj.stage;
            UserEmailInformation emailInfo = jObj.userEmailInformation;

            currentProject.Stage = stage;
            this.context.SaveChanges();

            var message = new JudgeEmailMessage(currentProject.Name, stage);
            new EmailService(emailInfo, message);

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

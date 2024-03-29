﻿using System;
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

        public ApprovalController(HOCContext _context)

        {
            this.context = _context;
            
        }
        //public IActionResult Index(string projectId)
        //{
        //    int id = Int32.Parse(projectId);
        //    var currentProject = this.context.Projects.First(x => x.Id == id);
        //    var data = new ApprovalProjectDisplay
        //        (
        //            currentProject.Name,
        //            currentProject.Description,
        //            currentProject.StartDate,
        //            currentProject.EndDate,
        //            currentProject.Stage
        //        );
        //    ViewBag.Id = projectId;
        //    return View(data);
        //}
        public IActionResult Index(string projectId)
        {
            string UID = this.HttpContext.User.Identity.Name;
            if (UID != null)
            {
                var userProfile = this.context.Users.Find(UID);
                ViewBag.EmailAddress = userProfile.Uid;
                ViewBag.UsersName = userProfile.UserName;
            }
            else
            {
                ViewBag.EmailAddress = "naveen.lanke@lcginc.com";
                ViewBag.UsersName = "Sir What-the-Hack";
            }
            int id = Int32.Parse(projectId);
            var currentProject = this.context.Projects.First(x => x.Id == id);
            var data = new ApprovalProjectDisplay
                (
                    currentProject.Name,
                    currentProject.Description,
                    currentProject.StartDate,
                    currentProject.EndDate,
                    currentProject.Stage
                );
            ViewBag.Id = projectId;
            return View(data);
        }

        [HttpGet]
        public IActionResult Get(string projectId)
        {
            int id = Int32.Parse(projectId);
            var currentProject = this.context.Projects.First(x => x.Id == id);
            ViewData["Message"] = "Your application description page.";

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

        public IActionResult Judge(string projectId, string stage, string emailAddress, string name)
        {
            ViewData["Message"] = "Determine application acceptance the application";
            //var jObj = JsonConvert.DeserializeObject<JudgeObject>(data);
            int stg = Int32.Parse(stage);
            ProjectStage projectStage = (ProjectStage)stg;
            //UserEmailInformation emailInfo = jObj.userEmailInformation;
            UserEmailInformation emailInfo = new UserEmailInformation(emailAddress, name);

            int id = Int32.Parse(projectId);
            var currentProject = this.context.Projects.First(x => x.Id == id);
            currentProject.Stage = projectStage;
            this.context.SaveChanges();

            var message = new JudgeEmailMessage(currentProject.Name, projectStage);
            var emailService = new EmailService(emailInfo, message);
            emailService.Send();

            return RedirectToAction("Index", "ApprovalsDashboard");
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

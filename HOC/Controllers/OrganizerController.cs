﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using HOC.Models;
using HOC.Entities.Models.DB;
using System.Net.Http;
using HOC.BusinessService;

namespace HOC.Controllers
{
    public class OrganizerController : Controller
    {
        int userID = 1;

        private HOCContext context;

        public OrganizerController(HOCContext _context)

        {
            this.context = _context;

        }

        // GET: Organizer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Organizer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Organizer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        public ActionResult Create(IFormCollection form)
        {
            Microsoft.Extensions.Primitives.StringValues val1, val2;
            try
            {

                // ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                form.TryGetValue("ProjectName", out val1);
                form.TryGetValue("Description", out val2);

                Projects proj = new Projects();
                proj.CreatedBy = 1;
                proj.Name = val1.ToString();
                proj.Description = val2.ToString();
                proj.StartDate = DateTime.Today;
                proj.EndDate = DateTime.Today;
                proj.ApprovedOn = DateTime.Today;
                proj.CreatedOn = DateTime.Today;
                proj.ModifiedOn = DateTime.Today;
                proj.ApprovedBy = 1;
                proj.ModifiedBy = 1;
                this.context.Projects.Add(proj);
                this.context.SaveChanges();
                //proj. = 1;
                //HTTP POST
                //var postTask = client.PostAsJsonAsync<Project>("project", proj);


                // Campaign manager notification
                for (int i = 0; i < proj.WorkflowId; i++)
                {
                    var campaignManager = this.context.Workflow.Find(i++);
                    var emailInfo = new UserEmailInformation(campaignManager.Name, campaignManager.EmailAddress);
                    var messageInfo = new CampaignManagerNotificationEmail(proj.Name);
                    new EmailService(emailInfo, messageInfo);
                }
                //var result = postTask.Result;
                //if (result.IsSuccessStatusCode)
                //{
                return RedirectToAction("Index");
                //}
                //}




            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Organizer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Organizer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Organizer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Organizer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ProjectDetails(int projId)
        {

            return View();
        }

        public ActionResult MyProjects()
        {

            return View();
        }
    }
}
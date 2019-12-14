using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using HOC.Entities.Models.DB;
using System.Net.Http;

namespace HOC.Controllers
{
    public class OrganizerController : Controller
    {
        int userID = 1;

        public OrganizerController()
        {
            userID = MyUserID;
        }

        int MyUserID
        {
            get
            {
                int uid = 1;
                //get uid from session

                return uid;
            }
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
        public ActionResult Create(IFormCollection form)
        {
            Microsoft.Extensions.Primitives.StringValues val1, val2, val3, val4;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://HOCAPI.AzureWebsites.net/api/Create");
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                    form.TryGetValue("ProjectName", out val1);
                    form.TryGetValue("Description", out val2);
                    form.TryGetValue("StartDate", out val3);
                    form.TryGetValue("EndDate", out val4);

                    Projects proj = new Projects();
                    proj.CreatedBy = MyUserID;
                    proj.Name = val1.ToString();
                    proj.Description = val2.ToString();
                    proj.StartDate = DateTime.Parse(val3.ToString());
                    proj.EndDate = DateTime.Parse(val4.ToString()); 
                    proj.ModifiedBy = proj.CreatedBy;
                    //proj. = 1;
                    //HTTP POST
                    //var postTask = client.PostAsJsonAsync<Project>("project", proj);
                    var postTask = client.PostAsJsonAsync<Projects>("project", proj);

                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

               
               
                return RedirectToAction("Create");
            }
            catch
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
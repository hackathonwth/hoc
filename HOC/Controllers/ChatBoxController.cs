using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HOC.Controllers
{
    public class ChatBoxController : Controller
    {
        // GET: ChatBox
        public ActionResult Index()
        {
            return View();
        }

        // GET: ChatBox/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChatBox/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChatBox/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChatBox/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChatBox/Edit/5
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

        // GET: ChatBox/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChatBox/Delete/5
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

        public IActionResult Send(string question)
        {
            return View("ChatBox");
        }
    }
}
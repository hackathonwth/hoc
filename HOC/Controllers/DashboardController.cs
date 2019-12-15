using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HOC.Entities.Models.DB;

namespace HOC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly HOCContext _context;

        public DashboardController(HOCContext context)
        {
            _context = context;
        }

        public IActionResult Index(string UserType, string UserId)
        {
            List<Projects> projects = new List<Projects>();
            if (UserType == "Organizer")
            {
                projects = _context.Projects.ToList();
            }
            else
            {
                projects = _context.Projects.ToList();
            }
            return View(projects);
        }

        // GET: Dashboard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects
                .Include(p => p.ApprovedByNavigation)
                .Include(p => p.CreatedByNavigation)
                .Include(p => p.ModifiedByNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projects == null)
            {
                return NotFound();
            }

            return View(projects);
        }

        // GET: Dashboard/Create
        public IActionResult Create()
        {
            ViewData["ApprovedBy"] = new SelectList(_context.Users, "Uid", "UserName");
            ViewData["CreatedBy"] = new SelectList(_context.Users, "Uid", "UserName");
            ViewData["ModifiedBy"] = new SelectList(_context.Users, "Uid", "UserName");
            return View();
        }

        // POST: Dashboard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Approved,ApprovedOn,ApprovedBy,StartDate,EndDate,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy,Stage")] Projects projects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projects);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApprovedBy"] = new SelectList(_context.Users, "Uid", "UserName", projects.ApprovedBy);
            ViewData["CreatedBy"] = new SelectList(_context.Users, "Uid", "UserName", projects.CreatedBy);
            ViewData["ModifiedBy"] = new SelectList(_context.Users, "Uid", "UserName", projects.ModifiedBy);
            return View(projects);
        }

        // GET: Dashboard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects.FindAsync(id);
            if (projects == null)
            {
                return NotFound();
            }
            ViewData["ApprovedBy"] = new SelectList(_context.Users, "Uid", "UserName", projects.ApprovedBy);
            ViewData["CreatedBy"] = new SelectList(_context.Users, "Uid", "UserName", projects.CreatedBy);
            ViewData["ModifiedBy"] = new SelectList(_context.Users, "Uid", "UserName", projects.ModifiedBy);
            return View(projects);
        }

        // POST: Dashboard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Approved,ApprovedOn,ApprovedBy,StartDate,EndDate,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy,Stage")] Projects projects)
        {
            if (id != projects.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectsExists(projects.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApprovedBy"] = new SelectList(_context.Users, "Uid", "UserName", projects.ApprovedBy);
            ViewData["CreatedBy"] = new SelectList(_context.Users, "Uid", "UserName", projects.CreatedBy);
            ViewData["ModifiedBy"] = new SelectList(_context.Users, "Uid", "UserName", projects.ModifiedBy);
            return View(projects);
        }

        // GET: Dashboard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects
                .Include(p => p.ApprovedByNavigation)
                .Include(p => p.CreatedByNavigation)
                .Include(p => p.ModifiedByNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projects == null)
            {
                return NotFound();
            }

            return View(projects);
        }

        // POST: Dashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projects = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(projects);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectsExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}

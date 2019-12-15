using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HOC.Entities.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HOC.Controllers
{
    public class ApprovalsDashboardController : Controller
    {
        private readonly HOCContext _context;

        public ApprovalsDashboardController(HOCContext context)
        {

            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index(string UserType, string UserId)
        {
            List<Projects> projects = new List<Projects>();
            projects = _context.Projects.Where(x =>
                x.Stage == Entities.Models.ProjectStage.Pending
                || x.Stage == Entities.Models.ProjectStage.Returned).ToList();

            return View(projects);
        }

        public IActionResult Process()
        {
            return View();
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

    }
}

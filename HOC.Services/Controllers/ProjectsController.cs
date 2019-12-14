using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HOC.Entities.Models.DB;

namespace HOC.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly HOCContext _context;

        public ProjectsController(HOCContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public IList<Projects> GetProjects()
        {
            try
            {
                List<Projects>  projects = new List<Projects>();

                using (var bdContext = new HOCContext())
                {
                    return projects = (from r in bdContext.Projects
                                       select (new Projects
                                       {
                                           Id = r.Id,
                                           Name = r.Name,
                                           Description = r.Description,
                                           Approved = r.Approved,
                                           ApprovedOn = r.ApprovedOn,
                                           ApprovedBy = r.ApprovedBy,
                                           StartDate = r.StartDate,
                                           EndDate = r.EndDate,
                                           CreatedOn = r.CreatedOn,
                                           CreatedBy = r.CreatedBy,
                                           ModifiedOn = r.ModifiedOn,
                                           ModifiedBy = r.ModifiedBy,
                                           StatusId = r.StatusId
                                       })).ToList();

                }
               // return projects;
            }catch(Exception ex)
            {
                return null;
                throw ex;
            }
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public Projects GetProjects([FromRoute] int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var projects = await _context.Projects.FindAsync(id);
            Projects project  = new  Projects();

            using (var bdContext = new HOCContext())
            {
                return project = (from r in bdContext.Projects
                                  where r.Id == id
                                  select (new Projects
                                   {
                                       Id = r.Id,
                                       Name = r.Name,
                                       Description = r.Description,
                                       Approved = r.Approved,
                                       ApprovedOn = r.ApprovedOn,
                                       ApprovedBy = r.ApprovedBy,
                                       StartDate = r.StartDate,
                                       EndDate = r.EndDate,
                                       CreatedOn = r.CreatedOn,
                                       CreatedBy = r.CreatedBy,
                                       ModifiedOn = r.ModifiedOn,
                                       ModifiedBy = r.ModifiedBy,
                                       StatusId = r.StatusId
                                   })).FirstOrDefault();

            }

           
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjects([FromRoute] int id, [FromBody] Projects projects)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projects.Id)
            {
                return BadRequest();
            }

            _context.Entry(projects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<IActionResult> PostProjects([FromBody] Projects projects)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var bdContext = new HOCContext())
            { 
                _context.Projects.Add(projects);
                Projects P1 = new Projects();
                 P1.Name = "Test2";
                P1.Description = "Description";
                  P1.CreatedBy = 1;
                   P1.ModifiedBy = 1;
                    P1.ModifiedOn = DateTime.Today;
                P1.StatusId = 1;
                bdContext.Projects.Add(P1);
                bdContext.SaveChanges();


            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjectsExists(projects.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjects", new { id = projects.Id }, projects);
        }

        [HttpPost]
        public  void SaveProject()
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            try { 
            using (var bdContext = new HOCContext())
            {
                //_context.Projects.Add(projects);
                Projects P1 = new Projects();
                P1.Name = "Test2";
                P1.Description = "Description";
                P1.CreatedBy = 1;
                P1.ModifiedBy = 1;
                P1.ModifiedOn = DateTime.Today;
                P1.StatusId = 1;
                bdContext.Projects.Add(P1);
                bdContext.SaveChanges();
                //return CreatedAtAction("GetProjects", new { id = P1.Id }, projects);

            }
            } catch(Exception ex)
            {

            }



        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjects([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projects = await _context.Projects.FindAsync(id);
            if (projects == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(projects);
            await _context.SaveChangesAsync();

            return Ok(projects);
        }

        private bool ProjectsExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
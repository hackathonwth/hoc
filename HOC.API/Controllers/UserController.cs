using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HOC.Entities.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HOC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly HOCContext _context;

        public UserController(HOCContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
           
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
          //  using(var bdContext =new HOC())
            //using (var bdContext = new HOCModel())
            //{

            //}
                return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

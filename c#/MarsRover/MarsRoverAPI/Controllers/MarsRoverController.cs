using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarsRoverAPI.Controllers
{
    [Route("api/marsrover")]
    [ApiController]
    public class MarsRoverController : ControllerBase
    {
        // GET: api/<MarsRoverController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //TODO: we need to think about it
            return new string[] { "TOBE", "IMPLEMENTED" };
        }

        // GET api/<MarsRoverController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"marsRover: {id}";
        }

        // POST api/<MarsRoverController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MarsRoverController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MarsRoverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

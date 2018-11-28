using Car_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Car_Capstone.Controllers
{
    [RoutePrefix("api/chars")]
    public class ValuesController : ApiController
    {
        public List<Car> chars = new List<Car>() {
            new Car("Mercury", "Sable", 1990, "Grey"),
            new Car("Ford", "Taurus", 1995, "White"),
            new Car("Jeep", "Cherokee", 1999, "Red"),
            new Car("Dodge", "Intrepid", 2000, "Black"),
            new Car("Plymouth", "Voyager", 1994, "Baby Blue"),
            new Car("Honda", "Accord", 2008, "Maroon")
        };
        // GET api/values
        [Route("")]
        public List<Car> Get()
        {
            return chars;
        }

        // GET api/values/5
        [Route("{id:int}")]
        public Car Get(int id)
        {
            return chars[id];
        }


        [Route("{name}")]
        [HttpGet]
        public List<Car> GetByName(string name)
        {
            var character = chars.Where(c => c.Make.Contains(name)).ToList();

            return character;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

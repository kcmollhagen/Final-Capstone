using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Car_Capstone.Models;

namespace Car_Capstone.Controllers
{
    [RoutePrefix("api/Cars")]
    public class CarsController : ApiController
    {
        private CarContext db = new CarContext();

        // GET: api/Cars
        [Route("")]
        public IQueryable<Car> GetCarChar()
        {
            return db.CarChar;
        }

        // GET: api/Cars/5
        //[Route("id :int")]
        [ResponseType(typeof(Car))]
        public IHttpActionResult GetCar(int id)
        {
            Car car = db.CarChar.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [Route("Make={Make}")]
        [HttpGet]
        public IQueryable<Car> GetCarByMake(string Make)
        {
            var Makes = db.CarChar.Where(c => c.Make.Contains(Make));
            return Makes;

        }

        [Route("Model={Model}")]
        [HttpGet]
        public IQueryable<Car> GetCarByModel(string Model)
        {
            var Models = db.CarChar.Where(c => c.Model.Contains(Model));
            return Models;

        }

        [Route("Year={Year}")]
        [HttpGet]
        public IQueryable<Car> GetCarByYear(int Year)
        {
            var Years = db.CarChar.Where(c => c.Make.Equals(Year));
            return Years;

        }

        [Route("Color={Color}")]
        [HttpGet]
        public IQueryable<Car> GetCarByColor(string Color)
        {
            var Colors = db.CarChar.Where(c => c.Make.Contains(Color));
            return Colors;

        }

        // PUT: api/Cars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCar(int id, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.ID)
            {
                return BadRequest();
            }

            db.Entry(car).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cars
        [ResponseType(typeof(Car))]
        public IHttpActionResult PostCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CarChar.Add(car);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = car.ID }, car);
        }

        // DELETE: api/Cars/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult DeleteCar(int id)
        {
            Car car = db.CarChar.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            db.CarChar.Remove(car);
            db.SaveChanges();

            return Ok(car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarExists(int id)
        {
            return db.CarChar.Count(e => e.ID == id) > 0;
        }
    }
}
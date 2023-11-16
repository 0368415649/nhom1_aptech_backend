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
using backend.Models;

namespace backend.Controllers
{
    public class favorite_carController : ApiController
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();

        // GET: api/favorite_car
        public IQueryable<favorite_car> Getfavorite_car()
        {
            return db.favorite_car;
        }

        // GET: api/favorite_car/5
        [ResponseType(typeof(favorite_car))]
        public IHttpActionResult Getfavorite_car(int id)
        {
            favorite_car favorite_car = db.favorite_car.Find(id);
            if (favorite_car == null)
            {
                return NotFound();
            }

            return Ok(favorite_car);
        }

        // PUT: api/favorite_car/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putfavorite_car(int id, favorite_car favorite_car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != favorite_car.favorite_car_id)
            {
                return BadRequest();
            }

            db.Entry(favorite_car).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!favorite_carExists(id))
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

        // POST: api/favorite_car
        [ResponseType(typeof(favorite_car))]
        [HttpPost]
        [Route("api/add_favorite_car")]

        public IHttpActionResult Postfavorite_car(favorite_car favorite_car)
        {
            try
            {
                db.favorite_car.Add(favorite_car);
                db.SaveChanges();
                return Ok(new { status = 1 });
            }
            catch (Exception)
            {
                return Ok(new { status = 0 });
                throw;
            }
            return Ok(new { status = 0 });
        }

        // DELETE: api/favorite_car/5
        [HttpDelete]
        [Route("api/delete_favorite_car")]
        [ResponseType(typeof(favorite_car))]
        public IHttpActionResult Deletefavorite_car(int favorite_car_id)
        {
            try
            {
                favorite_car favorite_car = db.favorite_car.Find(favorite_car_id);
                if (favorite_car == null)
                {
                    return NotFound();
                }

                db.favorite_car.Remove(favorite_car);
                db.SaveChanges();
                return Ok(new { status = 1 });
            }
            catch (Exception)
            {
                return Ok(new { status = 0 });
                throw;
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool favorite_carExists(int id)
        {
            return db.favorite_car.Count(e => e.favorite_car_id == id) > 0;
        }
    }
}
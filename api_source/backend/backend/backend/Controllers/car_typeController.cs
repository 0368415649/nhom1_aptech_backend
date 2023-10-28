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
    public class car_typeController : ApiController
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();

        // GET: api/car_type
        [Route("api/get_list_cartype")]
        public IQueryable<car_type> Getcar_type()
        {
            return db.car_type;
        }

        // GET: api/car_type/5
        [ResponseType(typeof(car_type))]
        public IHttpActionResult Getcar_type(int id)
        {
            car_type car_type = db.car_type.Find(id);
            if (car_type == null)
            {
                return NotFound();
            }

            return Ok(car_type);
        }

        // PUT: api/car_type/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcar_type(int id, car_type car_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car_type.car_type_id)
            {
                return BadRequest();
            }

            db.Entry(car_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!car_typeExists(id))
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

        // POST: api/car_type
        [ResponseType(typeof(car_type))]
        public IHttpActionResult Postcar_type(car_type car_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.car_type.Add(car_type);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = car_type.car_type_id }, car_type);
        }

        // DELETE: api/car_type/5
        [ResponseType(typeof(car_type))]
        public IHttpActionResult Deletecar_type(int id)
        {
            car_type car_type = db.car_type.Find(id);
            if (car_type == null)
            {
                return NotFound();
            }

            db.car_type.Remove(car_type);
            db.SaveChanges();

            return Ok(car_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool car_typeExists(int id)
        {
            return db.car_type.Count(e => e.car_type_id == id) > 0;
        }
    }
}
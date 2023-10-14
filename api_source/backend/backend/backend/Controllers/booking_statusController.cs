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
    public class booking_statusController : ApiController
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();

        // GET: api/booking_status
        public IQueryable<booking_status> Getbooking_status()
        {
            return db.booking_status;
        }

        // GET: api/booking_status/5
        [ResponseType(typeof(booking_status))]
        public IHttpActionResult Getbooking_status(int id)
        {
            booking_status booking_status = db.booking_status.Find(id);
            if (booking_status == null)
            {
                return NotFound();
            }

            return Ok(booking_status);
        }

        // PUT: api/booking_status/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putbooking_status(int id, booking_status booking_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != booking_status.booking_status_id)
            {
                return BadRequest();
            }

            db.Entry(booking_status).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!booking_statusExists(id))
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

        // POST: api/booking_status
        [ResponseType(typeof(booking_status))]
        public IHttpActionResult Postbooking_status(booking_status booking_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.booking_status.Add(booking_status);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = booking_status.booking_status_id }, booking_status);
        }

        // DELETE: api/booking_status/5
        [ResponseType(typeof(booking_status))]
        public IHttpActionResult Deletebooking_status(int id)
        {
            booking_status booking_status = db.booking_status.Find(id);
            if (booking_status == null)
            {
                return NotFound();
            }

            db.booking_status.Remove(booking_status);
            db.SaveChanges();

            return Ok(booking_status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool booking_statusExists(int id)
        {
            return db.booking_status.Count(e => e.booking_status_id == id) > 0;
        }
    }
}
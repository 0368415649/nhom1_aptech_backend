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
    public class bookingsController : ApiController
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();

        // GET: api/bookings
        public IQueryable<booking> Getbooking()
        {
            return db.booking;
        }

        // GET: api/bookings/5
        [ResponseType(typeof(booking))]
        public IHttpActionResult Getbooking(int id)
        {
            booking booking = db.booking.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        // PUT: api/bookings/5
        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/change_status_booking")]
        public IHttpActionResult CancelBooking(booking booking)
        {
            try
            {
                if(booking == null || booking.booking_id == null)
                {
                    return Ok(new { status = 0 });
                }
                var bookingFind = db.booking.Find(booking.booking_id);
                bookingFind.boocking_status_id = booking.boocking_status_id;
                switch (booking.boocking_status_id)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        break;
                    default:
                        break;
                }
                bookingFind.complete_flg = 1;
                db.SaveChanges();
                return Ok(new { status = 1 });
            }
            catch (Exception)
            {
                return Ok(new { status = 0 });
                throw;
            }
            return Ok(new { status = 0});
        }

        [ResponseType(typeof(booking))]
        [HttpPost]
        [Route("api/create_booking")]
        public IHttpActionResult Postbooking_status(booking booking)
        {
            try
            {
                booking.boocking_status_id = 1;
                booking.complete_flg = 0;
                db.booking.Add(booking);
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

        [ResponseType(typeof(booking))]
        public IHttpActionResult Deletebooking(int id)
        {
            booking booking = db.booking.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            db.booking.Remove(booking);
            db.SaveChanges();

            return Ok(booking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool bookingExists(int id)
        {
            return db.booking.Count(e => e.booking_id == id) > 0;
        }
    }
}
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
using System.Xml.Linq;
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

        [HttpGet]
        [Route("api/get_booking_user")]
        public IEnumerable<booking_view> GetBookingUser(int? customer_id, int? boocking_status_id)
        {
            var booking_view = db.booking
                .GroupJoin(
                    db.customer,
                    bk => bk.create_by,
                    c => c.customer_id,
                    (bk, cGroup) => new { bk, cGroup }
                )
                .SelectMany(
                    bkc => bkc.cGroup.DefaultIfEmpty(),
                    (bkc, c) => new { bkc.bk, c }
                )
                .Select(res => new booking_view()
                {
                    booking_id = res.bk.booking_id,
                    start_date = res.bk.start_date,
                    start_time = res.bk.start_time,
                    end_date = res.bk.end_date,
                    end_time = res.bk.end_time,
                    total = res.bk.total,
                    name = res.bk.name,
                    address = res.bk.address,
                    complete_flg = res.bk.complete_flg,
                    boocking_status_id = res.bk.boocking_status_id,
                    create_by = res.bk.create_by,
                    car_id = res.bk.car_id,
                    phone = res.c.phone,
                    full_name = res.c.full_name
                })
                .ToList();
            var bookings = booking_view
                .Where(item => item.create_by == customer_id)
                .Where(item => boocking_status_id == null || boocking_status_id == 0 || item.boocking_status_id == boocking_status_id)
                .ToList();
            bookings = bookings.OrderBy(c => c.car_id).ToList();
            return bookings;
        }

        [HttpGet]
        [Route("api/get_booking_owner")]
        public IEnumerable<booking_view> GetBookingOwner(int? customer_id, int? boocking_status_id)
        {
            var booking_view = db.booking
                .GroupJoin(
                    db.car,
                    bk => bk.car_id,
                    c => c.car_id,
                    (bk, cGroup) => new { bk, cGroup }
                )
                .SelectMany(
                    bkc => bkc.cGroup.DefaultIfEmpty(),
                    (bkc, c) => new { bkc.bk, c }
                ).Select(res => new booking_view()
                {
                    booking_id = res.bk.booking_id,
                    start_date = res.bk.start_date,
                    start_time = res.bk.start_time,
                    end_date = res.bk.end_date,
                    end_time = res.bk.end_time,
                    total = res.bk.total,
                    name = res.bk.name,
                    address = res.bk.address,
                    complete_flg = res.bk.complete_flg,
                    boocking_status_id = res.bk.boocking_status_id,
                    create_by = res.bk.create_by,
                    car_id = res.bk.car_id,
                    owner_id = res.c.customer_id
                })
                .ToList();
            var bookings = booking_view
                .Where(item => item.owner_id == customer_id)
                .Where(item => boocking_status_id == null || boocking_status_id == 0 || item.boocking_status_id == boocking_status_id)
                .ToList();
            bookings = bookings.OrderBy(c => c.car_id).ToList();
            return bookings;
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
                        bookingFind.complete_flg = 0;
                        break;
                    default:
                        bookingFind.complete_flg = 1;
                        break;
                }
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
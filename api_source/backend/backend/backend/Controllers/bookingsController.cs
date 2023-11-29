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
using backend.Service;

namespace backend.Controllers
{
    public class bookingsController : ApiController
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();
        CarServer carServer = new CarServer();

        [HttpGet]
        [Route("api/get_booking_verify")]
        [ResponseType(typeof(booking))]

        public IHttpActionResult Getbooking()
        {
            var result = from bk in db.booking
                         join c in db.car on bk.car_id equals c.car_id
                         join b in db.brand on c.brand_id equals b.brand_id
                         join m in db.model on c.model_id equals m.model_id
                         join cs in db.customer on bk.create_by equals cs.customer_id
                         where bk.boocking_status_id == 1
                         select new booking_view()
                         {
                             booking_id = bk.booking_id,
                             boocking_status_id = bk.boocking_status_id,
                             total = bk.total,
                             start_date = bk.start_date,
                             start_time = bk.start_time,
                             end_date = bk.end_date,
                             end_time = bk.end_time,
                             car_id = c.car_id,
                             model_id = c.model_id,
                             model_name = m != null ? m.model_name : null,
                             brand_id = c.brand_id,
                             brand_name = b != null ? b.brand_name : null,
                             address = bk.address,
                             image = c.image,
                             create_by = cs.customer_id,
                             phone = cs.phone,
                             name = cs.name_display
                             
                         };
            return Ok(result);
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
        [ResponseType(typeof(booking))]

        public IEnumerable<booking_view> GetBookingUser(int? customer_id, int? boocking_status_id)
            {
                var check = false;
                if (boocking_status_id == 4)
                {
                    check = true;
                }
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
                .GroupJoin(
                    db.car,
                    bkkk => bkkk.bk.car_id,
                    ca => ca.car_id,
                    (bkkk, caGroup) => new { bkkk, caGroup }
                )
                .SelectMany(
                    bkkk => bkkk.caGroup.DefaultIfEmpty(),
                    (bkkk, ca) => new { bkkk.bkkk.c, bkkk.bkkk.bk, ca }
                )
                .GroupJoin(
                    db.model,
                    bkkk => bkkk.ca.model_id,
                    model => model.model_id,
                    (bkkk, model) => new { bkkk, model }
                )
                .SelectMany(
                    bkkk => bkkk.model.DefaultIfEmpty(),
                    (bkkk, model) => new { bkkk.bkkk.c, bkkk.bkkk.bk, bkkk.bkkk.ca, model }
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
                    image = res.ca.image,
                    phone = res.c.phone,
                    full_name = res.c.full_name,
                    model_name = res.model.model_name
                })
                .ToList();
            var bookings = booking_view
                .Where(item => item.create_by == customer_id);
                if (check)
                {
                bookings = bookings
                .Where(item => item.boocking_status_id == 4 || item.boocking_status_id == 7 ) ;
                }
                else
                {
                bookings = bookings
                .Where(item => boocking_status_id == null || boocking_status_id == 0 || item.boocking_status_id == boocking_status_id);
                }
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
                )
                .GroupJoin(
                    db.model,
                    bkkk => bkkk.c.model_id,
                    ca => ca.model_id,
                    (bkkk, caGroup) => new { bkkk, caGroup }
                )
                .SelectMany(
                    bkkk => bkkk.caGroup.DefaultIfEmpty(),
                    (bkkk, ca) => new { bkkk.bkkk.c, bkkk.bkkk.bk, ca }
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
                    owner_id = res.c.customer_id,
                    image = res.c.image,
                    model_name = res.ca.model_name,
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
                        if (booking.boocking_status_id == 3)
                        {
                            int? car_id = bookingFind.car_id;
                            carServer.ChangeProcessingCar(car_id, 4);
                        }
                        break;
                    default:
                        if(booking.boocking_status_id == 4)
                        {
                             int? car_id = bookingFind.car_id;
                            carServer.ChangeProcessingCar(car_id, 3);
                            carServer.ChangeCarJourneys(car_id);
                        }
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
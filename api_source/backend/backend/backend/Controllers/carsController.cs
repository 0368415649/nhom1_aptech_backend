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
    public class carsController : ApiController
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();

        // GET: api/cars
        [HttpGet]
        [Route("api/get_all_car")]
        public IQueryable<car> Getcar()
        {
            return db.car;
        }

       /* var result = dbContext.Customers.Join(
                dbContext.Orders, // Bảng hoặc tập hợp dữ liệu thứ hai
                customer => customer.CustomerId, // Trường khóa ngoại của bảng thứ nhất
                order => order.CustomerId, // Trường khóa ngoại của bảng thứ hai
                (customer, order) => new
                {
                    CustomerName = customer.CustomerName,
                    OrderDate = order.OrderDate
                }
            );
*/
        // GET: api/cars
        [HttpGet]
        [Route("api/get_all_car_search")]
        public IEnumerable<car_view> GetAllCar(int? typeCar, int? brand, int? model, int? order_by_price, string name )
        {
            /* var query =( from c in db.car
                         join m in db.model
                         on c.model_id equals m.model_id
                         select new car()
                         {
                             car_id = c.car_id,
                             model_id = c.model_id,
                             brand_id = c.brand_id,
                             car_type_id = c.car_type_id
                         }).ToList();*/
            var car_view = db.car
                 .Join(
                     db.car_type,
                     c => c.car_type_id,
                     m => m.car_type_id,
                     (c, m) => new { c, m }
                 ).Select(res => new car_view()
                 {
                     car_id = res.c.car_id,
                     model_id = res.c.model_id,
                     brand_id = res.c.brand_id,
                     car_type_id = res.c.car_type_id

                 }).ToList();

            var cars = car_view
                .Where(item => typeCar == null || item.car_type_id == typeCar)
                .Where(item => brand == null || item.brand_id == brand)
                .Where(item => model == null || item.model_id == model).ToList();
            return cars;
        }


        // GET: api/cars/5
        [ResponseType(typeof(car))]
        public IHttpActionResult Getcar(int id)
        {
            car car = db.car.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/cars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcar(int id, car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.car_id)
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
                if (!carExists(id))
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

        // POST: api/cars
        [ResponseType(typeof(car))]
        public IHttpActionResult Postcar(car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.car.Add(car);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = car.car_id }, car);
        }

        // DELETE: api/cars/5
        [ResponseType(typeof(car))]
        public IHttpActionResult Deletecar(int id)
        {
            car car = db.car.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            db.car.Remove(car);
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

        private bool carExists(int id)
        {
            return db.car.Count(e => e.car_id == id) > 0;
        }
    }
}
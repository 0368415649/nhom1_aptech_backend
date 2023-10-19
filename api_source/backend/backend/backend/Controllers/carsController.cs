using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml.Linq;
using backend.Models;
using backend.Service;
using Newtonsoft.Json;

namespace backend.Controllers
{
    public class carsController : ApiController
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();
        string connstr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        // GET: api/cars
        [HttpGet]
        [Route("api/get_all_car")]
        public DataTable Getcar()
        {

            SqlConnection cnn = new SqlConnection(connstr);
            string sql = "SELECT * FROM car ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
           /* 
            string jsonData = JsonConvert.SerializeObject(ds.Tables[0]);

            // Tạo một đối tượng HttpResponseMessage
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");*/

            return ds.Tables[0];
        }

        
        [ResponseType(typeof(car))]
        [HttpGet]
        [Route("api/get_details_car")]
        public IEnumerable<car_view> Getcar(int id)
        {
            CarServer carServer = new CarServer();
            return carServer.Getcar(id);
        }

        // GET: api/cars
        [HttpGet]
        [Route("api/get_all_car_search")]
        public IEnumerable<car_view> GetAllCar(int? typeCar, int? brand, int? model, string order_by_price, string name)
        {
            CarServer carServer = new CarServer();
            return carServer.GetAllCar(typeCar, brand, model, order_by_price, name);
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
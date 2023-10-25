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
using System.Web.Http;
using System.Web.Http.Description;
using backend.Models;

namespace backend.Controllers
{
    public class vehicle_registrationController : ApiController
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();
        string connstr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;


        // GET: api/cars
        [HttpGet]
        [Route("api/max_id_vehicle")]
        public int Getcar()
        {
            try
            {
                SqlConnection cnn = new SqlConnection(connstr);
                string sql = "SELECT MAX(vehicle_registration_id) as max_id FROM vehicle_registration";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                int maxId = int.Parse(ds.Tables[0].Rows[0]["max_id"].ToString());
                return maxId == null ? 0 : maxId;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
            
        }


        // DELETE: api/vehicle_registration/5
        [ResponseType(typeof(vehicle_registration))]
        public IHttpActionResult Deletevehicle_registration(int id)
        {
            vehicle_registration vehicle_registration = db.vehicle_registration.Find(id);
            if (vehicle_registration == null)
            {
                return NotFound();
            }

            db.vehicle_registration.Remove(vehicle_registration);
            db.SaveChanges();

            return Ok(vehicle_registration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vehicle_registrationExists(int id)
        {
            return db.vehicle_registration.Count(e => e.vehicle_registration_id == id) > 0;
        }
    }
}
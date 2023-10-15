using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.SessionState;
using backend.Common;
using backend.Models;

namespace backend.Controllers
{
        
    public class customersController : ApiController
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();

        // GET: api/customers
        public IQueryable<customer> Getcustomer()
        {
            return db.customer;
        }

        // GET: api/customers/5
        [ResponseType(typeof(customer))]
        [Route("api/get_customer")]
        public IHttpActionResult Getcustomer(int id)
        {
            customer customer = db.customer.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // GET: check Login
        [ResponseType(typeof(customer))]
        [HttpGet]
        [Route("api/check_login")]
        public IHttpActionResult CheckLogin(string phone, string password)
        {
            LogicCommon logicCommon = new LogicCommon();
            LoginStatus loginStatus = new LoginStatus();
            customer customer = db.customer.FirstOrDefault(c => c.phone == phone && c.password == password);
            if (customer == null)
            {
                loginStatus.status = 0;

                return Ok(loginStatus);
            }
            return Ok(customer);


            /*loginStatus.status = 1;
            // Lấy đối tượng từ Session và ép kiểu
            string token = logicCommon.GenerateRandomString(10);
            loginStatus.token = token;
            return Ok(loginStatus);*/
        }


        // PUT: api/customers/5
        [ResponseType(typeof(void))]

        public IHttpActionResult Putcustomer(int id, customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.customer_id)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!customerExists(id))
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

        // POST: api/customers
        [ResponseType(typeof(customer))]
        [HttpPost]
        [Route("api/insert_customer")]
        public IHttpActionResult Postcustomer(customer customer)
        {
            if (!ModelState.IsValid)
            {
                
                return Ok(new { Status = 0 });
            }
            try
            {
                db.customer.Add(customer);
                db.SaveChanges();
                return Ok(new { Status = 1 });
            }
            catch (Exception)
            {
                return Ok(new { Status = 0 });
                throw;
            }
            
        }

        // DELETE: api/customers/5
        [ResponseType(typeof(customer))]
        public IHttpActionResult Deletecustomer(int id)
        {
            customer customer = db.customer.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.customer.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool customerExists(int id)
        {
            return db.customer.Count(e => e.customer_id == id) > 0;
        }
    }
}
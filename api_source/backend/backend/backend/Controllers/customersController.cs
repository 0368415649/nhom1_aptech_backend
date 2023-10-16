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
using backend.Service;

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

        // GET: api/customers/5
        [ResponseType(typeof(customer))]
        [HttpGet]
        [Route("api/check_exists_phone")]
        public IHttpActionResult CheckExistsPhone(string phone)
        {
            int count = db.customer.Where(c => c.phone == phone).Count();
            if (count > 0)
            {
                return Ok(new {status = 1});
            }
            return Ok(new { status = 0 });
        }



        // GET: check Login
        [ResponseType(typeof(customer))]
        [HttpGet]
        [Route("api/check_login")]
        public IHttpActionResult CheckLogin(string phone, string password)
        {
            LoginStatus loginStatus = new LoginStatus();
            try
            {
                customer cus = db.customer.FirstOrDefault(c => c.phone == phone);
                if (cus == null)
                {
                    loginStatus.status = 0;
                    return Ok(loginStatus);
                }
                bool isPassword = BCrypt.Net.BCrypt.Verify(password, cus.password);
                if (isPassword)
                {
                    loginStatus.status = 1;
                    loginStatus.customer_id = cus.customer_id;
                    return Ok(loginStatus);
                }

                loginStatus.status = 0;
                return Ok(loginStatus);
            }
            catch (Exception)
            {
                loginStatus.status = 0;
                return Ok(loginStatus);
                throw;
            }
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
        [Route("api/register_customer")]
        public IHttpActionResult Postcustomer(customer customer)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new { Status = 0 });
            }
            try
            {
                RegisterServer registerServer = new RegisterServer();
                registerServer.registerCustomer(customer);
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
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
    public class addressesController : ApiController
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();

        // GET: api/addresses
        public IQueryable<address> Getaddress()
        {
            return db.address;
        }

        // GET: api/addresses/5
        [ResponseType(typeof(address))]
        public IHttpActionResult Getaddress(int id)
        {
            address address = db.address.Find(id);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        // PUT: api/addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaddress(int id, address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != address.address_id)
            {
                return BadRequest();
            }

            db.Entry(address).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!addressExists(id))
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

        // POST: api/addresses
        [ResponseType(typeof(address))]
        [HttpPost]
        [Route("api/create_address")]
        public IHttpActionResult Postaddress(address address)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new { Status = 0 });
                    return BadRequest(ModelState);
                }

                db.address.Add(address);
                db.SaveChanges();
                return Ok(new { Status = 1 });
            }
            catch (Exception)
            {
                return Ok(new { Status = 1 });
                throw;
            }
            
        }

        // DELETE: api/addresses/5
        [ResponseType(typeof(address))]
        [HttpGet]
        [Route("api/delete_address")]
        public IHttpActionResult Deleteaddress(int id)
        {
            address address = db.address.Find(id);
            if (address == null)
            {
                return Ok(new { Status = 0 });
            }

            db.address.Remove(address);
            db.SaveChanges();

            return Ok(new { Status = 1 });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool addressExists(int id)
        {
            return db.address.Count(e => e.address_id == id) > 0;
        }
    }
}
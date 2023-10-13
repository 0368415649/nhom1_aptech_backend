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
using backend_api.Models;
using Newtonsoft.Json;

namespace backend_api.Controllers
{
    public class boocking_statusController : ApiController
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();

        // GET: api/boocking_status
        public IQueryable<boocking_status> Getboocking_status()
        {
            return db.boocking_status;
        }

        // GET: api/boocking_status/5
        [ResponseType(typeof(boocking_status))]
        public IHttpActionResult Getboocking_status(int id)
        {
            boocking_status boocking_status = db.boocking_status.Find(id);
            if (boocking_status == null)
            {
                return NotFound();
            }

            return Ok(boocking_status);
        }

        // PUT: api/boocking_status/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putboocking_status(int id, boocking_status boocking_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boocking_status.boocking_status_id)
            {
                return BadRequest();
            }

            db.Entry(boocking_status).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!boocking_statusExists(id))
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

        // POST: api/boocking_status
        [ResponseType(typeof(boocking_status))]
        public IHttpActionResult Postboocking_status(boocking_status boocking_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.boocking_status.Add(boocking_status);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = boocking_status.boocking_status_id }, boocking_status);
        }

        // DELETE: api/boocking_status/5
        [ResponseType(typeof(boocking_status))]
        public IHttpActionResult Deleteboocking_status(int id)
        {
            boocking_status boocking_status = db.boocking_status.Find(id);
            if (boocking_status == null)
            {
                return NotFound();
            }

            db.boocking_status.Remove(boocking_status);
            db.SaveChanges();

            return Ok(boocking_status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool boocking_statusExists(int id)
        {
            return db.boocking_status.Count(e => e.boocking_status_id == id) > 0;
        }
    }
}
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
    public class feebacksController : ApiController
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();

        // GET: api/feebacks
        public IQueryable<feeback> Getfeeback()
        {
            return db.feeback;
        }

        [ResponseType(typeof(address))]
        [HttpGet]
        [Route("api/get_list_feeback")]
        [ResponseType(typeof(feeback))]
        public IHttpActionResult GetListeeback(int car_id)
        {
            try
            {
                var listFeeback = db.feeback;
                var result = from fb in db.feeback
                             join cs in db.customer on fb.create_by equals cs.customer_id
                             where fb.car_id == car_id
                             select new feeback_view()
                             {
                                feeback_id = fb.feeback_id,
                                rate = fb.rate,
                                comment = fb.comment,
                                create_at = fb.create_at,
                                create_by = fb.create_by,
                                car_id = fb.car_id,
                                name_display = cs.name_display
                             };
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok(new { Status = 0 });
                throw;
            }
        }

        [ResponseType(typeof(address))]
        [HttpPost]
        [Route("api/create_feeback")]
        [ResponseType(typeof(feeback))]
        public IHttpActionResult Postfeeback(feeback feeback)
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                feeback.create_at = currentDate.ToString("yyyy-MM-dd HH:mm:ss");
                db.feeback.Add(feeback);
                db.SaveChanges();
                return Ok(new { Status = 1 });
            }
            catch (Exception)
            {
                return Ok(new { Status = 0 });
                throw;
            }
            

            return CreatedAtRoute("DefaultApi", new { id = feeback.feeback_id }, feeback);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool feebackExists(int id)
        {
            return db.feeback.Count(e => e.feeback_id == id) > 0;
        }
    }
}
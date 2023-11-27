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
    public class brandsController : ApiController
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();

        [Route("api/get_list_brand")]
        public IQueryable<brand> Getbrand()
        {
            return db.brand;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool brandExists(int id)
        {
            return db.brand.Count(e => e.brand_id == id) > 0;
        }
    }
}
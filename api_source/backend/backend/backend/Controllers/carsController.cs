using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml.Linq;
using backend.Common;
using backend.Models;
using backend.Service;
using backend.Service.SeviceInterface;
using Newtonsoft.Json;

namespace backend.Controllers
{
    public class carsController : ApiController
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();
        string connstr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        ICarServer _iCarServer;
        public carsController()
        {
            _iCarServer = new CarServer();
        }
        
        [ResponseType(typeof(car))]
        [HttpGet]
        [Route("api/get_details_car")]
        public IEnumerable<car_view> Getcar(int id, int? customer_id)
        {
            return _iCarServer.Getcar(id, customer_id);
        }


        [HttpGet]
        [Route("api/get_all_my_car")]
        public IEnumerable<car_view> GetAllMyCar(int? customer_id)
        {
            return _iCarServer.GetAllMyCar(customer_id);
        }

        [HttpGet]
        [Route("api/get_favorite_car")]
        public IEnumerable<car_view> GetFavoriteCar(int customer_id)
        {
            return _iCarServer.GetFavoriteCar(customer_id);
        }


        [HttpGet]
        [Route("api/get_all_car_search")]
        public IEnumerable<car_view> GetAllCar(int? typeCar, int? brand, string order_by_price, string name)
        {
            return _iCarServer.GetAllCar(typeCar, brand, order_by_price, name);
        }


        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/change_status_car")]
        public IHttpActionResult ChangeStatusCar(car car)
        {
            return Ok(_iCarServer.ChangeStatusCar(car));
        }

        [ResponseType(typeof(car))]
        [HttpPost]
        [Route("api/create_car")]
        public async Task<IHttpActionResult> Postcar()
        {
            try
            {
                
                var provider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath("~/Image/Car/Verify"));
                await Request.Content.ReadAsMultipartAsync(provider);
                return Ok(_iCarServer.Postcar(provider));
            }
            catch (Exception)
            {
                return Ok(new { status = 0 });
                throw;
            }
        }

        // PUT: api/cars/5
        [ResponseType(typeof(void))]
        [HttpPost]
        [Route("api/update_car")]
        public IHttpActionResult UpdateCar(car car)
        {
            try
            {
                CarServer carServer = new CarServer();
                bool isVerify = carServer.UpdateCar(car);
                if (isVerify)
                {
                    return Ok(new { status = 1 });
                }
            }
            catch (System.Exception)
            {
                return Ok(new { status = 0 });
                throw;
            }
            return Ok(new { status = 0 });
        }



        // DELETE: api/cars/5
        [ResponseType(typeof(car))]
        [HttpPost]
        [Route("api/delete_car")]
        public IHttpActionResult Deletecar(car car)
        {
            try
            {
                CarServer carServer = new CarServer();
                bool isVerify = carServer.DeleteCar(car);
                if (isVerify)
                {
                    return Ok(new { status = 1 });
                }
            }
            catch (System.Exception)
            {
                return Ok(new { status = 0 });
                throw;
            }
            return Ok(new { status = 0 });
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
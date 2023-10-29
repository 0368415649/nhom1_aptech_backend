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
        public IEnumerable<car_view> GetAllCar(int? typeCar, int? brand, string order_by_price, string name)
        {
            CarServer carServer = new CarServer();
            return carServer.GetAllCar(typeCar, brand, order_by_price, name);
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

        [ResponseType(typeof(car))]
        [HttpPost]
        [Route("api/create_car")]
        public async Task<IHttpActionResult> Postcar()
        {
            try
            {
            /*var files = HttpContext.Current.Request.Files["image1"];
            var filePath2 = Path.Combine(HttpContext.Current.Server.MapPath("~/Image/Car/Verify"), "haha.jpg");
            files.SaveAs(filePath2);
            *//*var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Image/Car/Verify"), "haha.jpg");
            File.Move(files., filePath);*/
            LogicCommon logicCommon = new LogicCommon();
            var provider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath("~/Image/Car/Verify"));
            await Request.Content.ReadAsMultipartAsync(provider);
            if (provider.FileData == null)
            {
                return Ok(new { status = 0 });
            }
            int i = 0;
            vehicle_registrationController vehicle_RegistrationController = new vehicle_registrationController();
            vehicle_registration vehicle_Registration = new vehicle_registration();
            int vehicleRegistrationId = vehicle_RegistrationController.Getcar() + 1;
            car car = new car();
            List<string> imagesCar = new List<string>();
            foreach (var fileData in provider.FileData)
            {
                var param = provider.FileData[i].Headers.ContentDisposition.Name.Trim('"');
                var fileName = i.ToString() + logicCommon.GenerateRandomString(5) + "_" + fileData.Headers.ContentDisposition.FileName.Trim('"');
                var pathName = "~/Image/Car/Image/";
                switch (param)
                {
                        case "image1":
                        case "image2":
                        case "image3":
                        case "image4":
                            imagesCar.Add(fileName);
                            pathName = "~/Image/Car/Image/";
                            break;
                        case "image5":
                        case "image6":
                            if (param == "image5")
                            {
                                vehicle_Registration.vehicle_registration_image = fileName;
                            }
                            else
                            {
                                vehicle_Registration.vehicle_inspection_image = fileName;
                            }
                            pathName = "~/Image/Car/Verify/";
                            break;
                        default:
                            break;
                }
                var filePath = Path.Combine(HttpContext.Current.Server.MapPath(pathName), fileName);
                File.Move(fileData.LocalFileName, filePath);
                i++;
            }
                /*Add vehicle_registrationController*/
                vehicle_Registration.vehicle_registration_id = vehicleRegistrationId;
                db.vehicle_registration.Add(vehicle_Registration);
                db.SaveChanges();
                /*Add car*/
                car.price = int.Parse(HttpContext.Current.Request.Form["price"]);
                car.year_manufacture = int.Parse(HttpContext.Current.Request.Form["year_manufacture"]);
                car.number_plate = HttpContext.Current.Request.Form["number_plate"];
                car.description = HttpContext.Current.Request.Form["description"];
                car.address = HttpContext.Current.Request.Form["address"];
                car.brand_id = int.Parse(HttpContext.Current.Request.Form["brand_id"]);
                car.model_id = int.Parse(HttpContext.Current.Request.Form["model_id"]);
                car.car_type_id = int.Parse(HttpContext.Current.Request.Form["car_type_id"]);
                car.customer_id = int.Parse(HttpContext.Current.Request.Form["customer_id"]);
                car.vehicle_registration_id = vehicleRegistrationId;
                car.image = string.Join("-", imagesCar); ;
                car.is_delete = 0;
                car.car_status_id = 1;
                car.count_journeys = 0;
                db.car.Add(car);
                db.SaveChanges();
                return Ok(new { status = 1 });
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
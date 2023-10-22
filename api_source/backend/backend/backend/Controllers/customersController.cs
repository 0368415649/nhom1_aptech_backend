using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
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
        string connstr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        // GET: api/customers
        public IQueryable<customer> Getcustomer()
        {
            return db.customer;
        }

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
                LoginService loginService = new LoginService();
                return Ok(loginService.CheckLogin(phone, password));
            }
            catch (Exception)
            {
                loginStatus.status = 0;
                return Ok(loginStatus);
                throw;
            }
        }

        // PUT: api/cars/5
        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/change_profile_customer")]
        public IHttpActionResult Putcar(customer customer)
        {
            try
            {
                CustomerService customerService = new CustomerService();
                bool isVerify = customerService.ChangeProfileCustomer(customer);
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

        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/change_phone")]
        public IHttpActionResult ChangePhone(customer customer)
        {
            try
            {
                CustomerService customerService = new CustomerService();
                bool isVerify = customerService.ChangePhone(customer);
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

        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/change_mail")]
        public IHttpActionResult ChangeMail(customer customer)
        {
            try
            {
                CustomerService customerService = new CustomerService();
                bool isVerify = customerService.ChangeMail(customer);
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


        [ResponseType(typeof(void))]
        [HttpPost]
        [Route("api/verify_customer")]
        public async Task<IHttpActionResult> VerifyCustomer()
        {
            try
            {
                LogicCommon logicCommon = new LogicCommon();
                var provider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath("~/Image/Customer/Verify"));
                await Request.Content.ReadAsMultipartAsync(provider);
                List<string> images = new List<string>();
                customer cus = new customer();
                int i = 0;
                foreach (var fileData in provider.FileData)
                {
                    if (fileData == null)
                    {
                        return Ok(new { status = 0 });
                    }
                    var originalFileName = fileData.Headers.ContentDisposition.FileName;
                    var fileName = logicCommon.GenerateRandomString(10) + originalFileName.Trim('"');
                    images.Add(fileName);
                    var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Image/Car/"), fileName);
                    File.Move(fileData.LocalFileName, filePath);
                    if( i == 0)
                    {
                        cus.id_frontside = fileName;
                    }
                    else
                    {
                        cus.id_backside = fileName;
                    }
                    i++;
                }
                cus.full_name = HttpContext.Current.Request.Form["full_name"];
                cus.id_number = HttpContext.Current.Request.Form["id_number"];
                cus.birthday = HttpContext.Current.Request.Form["birthday"];
                cus.customer_id = int.Parse(HttpContext.Current.Request.Form["customer_id"]);
                CustomerService customerService = new CustomerService();
                bool isVerify = customerService.VerifyCustomer(cus);
                if (isVerify)
                {
                    return Ok(new { status = 1 });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = 0 });
            }
            return Ok(new { status = 0 });
        }


        [ResponseType(typeof(void))]
        [HttpPost]
        [Route("api/verify_hehe")]
        public async Task<HttpResponseMessage> UploadImage()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath("~/Image/Customer/Verify"));
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                var fileData = provider.FileData.FirstOrDefault();
                if (fileData != null)
                {
                    var originalFileName = fileData.Headers.ContentDisposition.FileName;

                    var fileName = fileData.Headers.ContentDisposition.FileName;
                    fileName = originalFileName.Trim('"');
                    var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Image/Car/"),"mnkdsad" + fileName);

                    File.Move(fileData.LocalFileName, filePath);

                    return Request.CreateResponse(HttpStatusCode.OK, filePath);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No file uploaded.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/invalid_verify_customer")]
        public IHttpActionResult InvalidVerifyCustomer(customer customer)
        {
            try
            {
                CustomerService customerService = new CustomerService();
                bool isVerify = customerService.InvalidVerifyCustomer(customer);
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

        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/valid_verify_customer")]
        public IHttpActionResult ValidVerifyCustomer(customer customer)
        {
            try
            {
                CustomerService customerService = new CustomerService();
                bool isVerify = customerService.ValidVerifyCustomer(customer);
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
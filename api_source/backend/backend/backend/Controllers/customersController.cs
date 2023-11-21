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
            var countCar = db.car
                .Where(c => c.customer_id == id)
                .Select(c => (int?)c.count_journeys) // Chuyển đổi sang kiểu int? để xử lý trường hợp có giá trị null
                .DefaultIfEmpty(0) // Đặt giá trị mặc định là 0 nếu không có giá trị
                .Sum();
            customer customer = db.customer.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer_view customer_view = new customer_view();
            customer_view.customer_id = customer.customer_id;
            customer_view.phone = customer.phone;
            customer_view.email = customer.email;
            customer_view.name_display = customer.name_display;
            customer_view.full_name = customer.full_name;
            customer_view.birthday = customer.birthday;
            customer_view.password = customer.password;
            customer_view.sex = customer.sex;
            customer_view.role_id = customer.role_id;
            customer_view.id_number = customer.id_number;
            customer_view.id_frontside = customer.id_frontside;
            customer_view.id_backside = customer.id_backside;
            customer_view.verify_flg = customer.verify_flg;
            customer_view.count = countCar;
            return Ok(customer_view);
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
        [HttpGet]
        [Route("api/check_password")]
        public IHttpActionResult CheckPassword(int customer_id, string password)
        {
            Result result = new Result();
            try
            {
                LoginService loginService = new LoginService();
                bool isVerify = loginService.CheckPassword(customer_id, password);
                if (isVerify)
                {
                    result.status = 1;
                    return Ok(result);
                }
            }
            catch (System.Exception)
            {
                result.status = 0;
                return Ok(result);
                throw;
            }
            result.status = 0;
            return Ok(result);
        }

        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/change_password")]
        public IHttpActionResult ChangePassword(customer customer)
        {
            try
            {
                CustomerService customerService = new CustomerService();
                bool isVerify = customerService.ChangePassword(customer);
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
                    var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Image/Customer/Verify"), fileName);
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
        [HttpPut]
        [Route("api/change_verify_customer")]
        public IHttpActionResult ChangeVerifyCustomer(customer customer)
        {
            try
            {
                if (customer == null || customer.customer_id == null || customer.verify_flg == null)
                {
                    return Ok(new { status = 0 });
                }
                var customerFind = db.customer.Find(customer.customer_id);
                customerFind.verify_flg = customer.verify_flg;
               
                db.SaveChanges();
                return Ok(new { status = 1 });
            }
            catch (Exception)
            {
                return Ok(new { status = 0 });
                throw;
            }
            return Ok(new { status = 0 });
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
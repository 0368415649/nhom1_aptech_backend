using backend.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.Ajax.Utilities;
using System.Xml.Linq;
using backend.Service.SeviceInterface;
using System.Web.Http;
using System.Collections;
using backend.Common;
using backend.Controllers;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Dynamic;

namespace backend.Service
{
    public class CarServer : ICarServer
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();
        string connstr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public IEnumerable<car_view> GetAllTableCar()
        {
            var car_view = db.car
                .GroupJoin(
                    db.model,
                    c => c.model_id,
                    m => m.model_id,
                    (c, modelGroup) => new { c, modelGroup }
                )
                .SelectMany(
                    cm => cm.modelGroup.DefaultIfEmpty(),
                    (cm, m) => new { cm.c, m }
                )
                .GroupJoin(
                    db.brand,
                    cm => cm.c.brand_id,
                    b => b.brand_id,
                    (cm, brandGroup) => new { cm, brandGroup }
                )
                .SelectMany(
                    cmb => cmb.brandGroup.DefaultIfEmpty(),
                    (cmb, b) => new { cmb.cm.c, cmb.cm.m, b }
                ).GroupJoin(
                    db.booking,
                    cmbb => cmbb.c.car_id,
                    book => book.car_id,
                    (cmbb, bookGroup) => new { cmbb, bookGroup }
                )
                .SelectMany(
                    cmbb => cmbb.bookGroup.DefaultIfEmpty(),
                    (cmbb, book) => new { cmbb.cmbb.c, cmbb.cmbb.m, cmbb.cmbb.b, book }
                )
                .Select(res => new car_view()
                {
                    car_id = res.c.car_id,
                    model_id = res.c.model_id,
                    car_type_id = res.c.car_type_id,
                    model_name = res.m != null ? res.m.model_name : null,
                    brand_id = res.c.brand_id,
                    brand_name = res.b != null ? res.b.brand_name : null,
                    price = res.c.price,
                    count_journeys = res.c.count_journeys,
                    address = res.c.address,
                    customer_id = res.c.customer_id,
                    car_status_id = res.c.car_status_id,
                    image = res.c.image,
                    boocking_status_id = res.book.boocking_status_id
                })
                .ToList();
                var cars = car_view
                .GroupBy(item => new
                {
                    item.car_id,
                })
                .Select(group => group.First())
                .ToList();
            return cars;
        }

        public IEnumerable<car_view> GetAllCar(int? typeCar, int? brand, string order_by_price, string name)
        {
            var car_view = GetAllTableCar();
            var cars = car_view
                .Where(item => item.car_status_id == 3)
                .Where(item => item.boocking_status_id != 3)
                .Where(item => item.model_name.Contains(name ?? ""))
                .Where(item => typeCar == null || item.car_type_id == typeCar)
                .Where(item => brand == null || item.brand_id == brand)
                .GroupBy(item => new
                {
                    item.car_id,
                })
                .Select(group => group.First())
                .ToList();
            switch (order_by_price)
            {
                case "ASC":
                    cars = cars.OrderBy(c => c.price).ToList();
                    break;
                case "DESC":
                    cars = cars.OrderByDescending(c => c.price).ToList();
                    break;
                default:
                    break;
            }
            return cars;
        }

        
        public IEnumerable<car_view> GetFavoriteCar(int? customer_id)
        {
            var result = from fc in db.favorite_car
                         join c in db.car on fc.car_id equals c.car_id
                         join b in db.brand on c.brand_id equals b.brand_id
                         join m in db.model on c.model_id equals m.model_id
                         where fc.customer_id == customer_id
                         select new car_view()
                         {
                             car_id = c.car_id,
                             model_id = c.model_id,
                             car_type_id = c.car_type_id,
                             model_name = m != null ? m.model_name : null,
                             brand_id = c.brand_id,
                             brand_name = b != null ? b.brand_name : null,
                             price = c.price,
                             count_journeys = c.count_journeys,
                             address = c.address,
                             customer_id = c.customer_id,
                             car_status_id = c.car_status_id,
                             image = c.image,
                             favorite_car_id = fc.favorite_car_id
                         };
            return result;
        }


        public IEnumerable<car_view> GetAllMyCar(int? customer_id)
        {
           /* var cw = GetFavoriteCar(customer_id);
            // Lấy danh sách car_id
            List<int> carIds = cw.Select(car => car.car_id).ToList();*/

            var car_view = db.car
                .GroupJoin(
                    db.model,
                    c => c.model_id,
                    m => m.model_id,
                    (c, modelGroup) => new { c, modelGroup }
                )
                .SelectMany(
                    cm => cm.modelGroup.DefaultIfEmpty(),
                    (cm, m) => new { cm.c, m }
                )
                .GroupJoin(
                    db.car_status,
                    cm => cm.c.car_status_id,
                    t => t.car_status_id,
                    (cm, carStatusGroup) => new { cm, carStatusGroup }
                )
                .SelectMany(
                    cmt => cmt.carStatusGroup.DefaultIfEmpty(),
                    (cmt, t) => new { cmt.cm.c, cmt.cm.m, t }
                )
                .GroupJoin(
                    db.brand,
                    cmt => cmt.c.brand_id,
                    b => b.brand_id,
                    (cmt, brandGroup) => new { cmt, brandGroup }
                )
                .SelectMany(
                    cmtb => cmtb.brandGroup.DefaultIfEmpty(),
                    (cmtb, b) => new { cmtb.cmt.c, cmtb.cmt.m, cmtb.cmt.t, b }
                ).GroupJoin(
                     db.booking.Where(book => book.complete_flg == 0),
                    cmbb => cmbb.c.car_id,
                    book => book.car_id,
                    (cmbb, bookGroup) => new { cmbb, bookGroup }
                )
                .SelectMany(
                    cmbb => cmbb.bookGroup.DefaultIfEmpty(),
                    (cmbb, book) => new { cmbb.cmbb.c, cmbb.cmbb.m, cmbb.cmbb.t, cmbb.cmbb.b, book }
                )
                .Select(res => new car_view()
                {
                    car_id = res.c.car_id,
                    model_id = res.c.model_id,
                    car_type_id = res.c.car_type_id,
                    model_name = res.m != null ? res.m.model_name : null,
                    brand_id = res.c.brand_id,
                    brand_name = res.b != null ? res.b.brand_name : null,
                    price = res.c.price,
                    count_journeys = res.c.count_journeys,
                    address = res.c.address,
                    customer_id = res.c.customer_id,
                    car_status_id = res.c.car_status_id,
                    car_status_name = res.t != null ? res.t.car_status_name : null,
                    image = res.c.image,
                    complete_flg = res.book.complete_flg,
                    description = res.c.image != null ? "f" : "f"
                })
                .ToList();


            var cars = car_view
                .Where(item => item.customer_id == customer_id)
                .ToList();
            cars = cars.OrderBy(c => c.car_id).ToList();
            return cars;
        }


        public IEnumerable<car_view> Getcar(int id, int? customer_id)
        {
            /* int count = db.feeback.Count(f => f.car_id == 4);*/
            var feedbackStatistics = db.feeback
                .Where(f => f.car_id == id)
                .GroupBy(f => 1)
                .Select(g => new
                {
                    count = g.Count(),
                    averageRate = g.Average(f => f.rate)
                })
                .FirstOrDefault();
            int count = 0;
            double avgRate = 0;
            if(feedbackStatistics != null)
            {
                count = feedbackStatistics.count;
                avgRate = (double) feedbackStatistics.averageRate;
            }

            var result = from c in db.car
                         join m in db.model on c.model_id equals m.model_id
                         join b in db.brand on c.brand_id equals b.brand_id
                         join ct in db.car_type on c.car_type_id equals ct.car_type_id
                         join fc in db.favorite_car.Where(fc => fc.customer_id == customer_id) on c.car_id equals fc.car_id into fcGroup
                         from fc in fcGroup.DefaultIfEmpty()
                         select new car_view()
                         {
                             car_id = c.car_id,
                             model_id = c.model_id,
                             model_name = m.model_name,
                             brand_id = c.brand_id,
                             brand_name = b.brand_name,
                             price = c.price,
                             count_journeys = c.count_journeys,
                             address = c.address,
                             customer_id = c.customer_id,
                             image = c.image,
                             description = c.description,
                             rate = 5,
                             number_plate = c.number_plate,
                             year_manufacture = c.year_manufacture,
                             number_seats = ct.number_seats,
                             favorite_car_id = fc.favorite_car_id,
                             count_comment = count,
                             rate_avg = avgRate
                         };
            var cars = result
               .Where(item => item.car_id == id).ToList();
            return cars;
        }

        
        public bool UpdateCar(car car)
        {
            SqlConnection cnn = new SqlConnection(connstr);
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE [car] SET ");
                sql.Append(" price = N'" + car.price + "', ");
                sql.Append(" address = N'" + car.address + "', ");
                sql.Append(" description = N'" + car.description + "' ");
                sql.Append(" WHERE  car_id  =  " + car.car_id);
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlCommand cmd = cnn.CreateCommand();
                cmd.Connection = cnn;
                cmd.CommandText = sql.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
            finally
            {
                cnn.Close();
            }
            return false;
        }

        public bool DeleteCar(car car)
        {
            SqlConnection cnn = new SqlConnection(connstr);
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE [car] SET ");
                sql.Append(" is_delete = 1 ");
                sql.Append(" WHERE  car_id  =  " + car.car_id);
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlCommand cmd = cnn.CreateCommand();
                cmd.Connection = cnn;
                cmd.CommandText = sql.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
            finally
            {
                cnn.Close();
            }
            return false;
        }

        public Result ChangeStatusCar(car car)
        {
            Result result = new Result();
            result.status = 0;
            try
            {
                if (car == null || car.car_id == null || car.car_status_id == null)
                {
                    return result;
                }
                var carFind = db.car.Find(car.car_id);
                carFind.car_status_id = car.car_status_id;
                db.SaveChanges();
                result.status = 1;
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        public async Task<Result> Postcar(MultipartFormDataStreamProvider provider)
        {
            Result result = new Result();
            result.status = 0;
            try
            {
                /*var files = HttpContext.Current.Request.Files["image1"];
                var filePath2 = Path.Combine(HttpContext.Current.Server.MapPath("~/Image/Car/Verify"), "haha.jpg");
                files.SaveAs(filePath2);
                *//*var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Image/Car/Verify"), "haha.jpg");
                File.Move(files., filePath);*/
                int i = 0;
                LogicCommon logicCommon = new LogicCommon();
                vehicle_registrationController vehicle_RegistrationController = new vehicle_registrationController();
                int vehicleRegistrationId = vehicle_RegistrationController.Getcar() + 1;
                car car = new car();
                List<string> imagesCar = new List<string>();
                vehicle_registration vehicle_Registration = new vehicle_registration();
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
                string description = HttpContext.Current.Request.Form["description"];
                byte[] descriptionBytes = Encoding.UTF8.GetBytes(description);
                string encodedDescription = Encoding.UTF8.GetString(descriptionBytes);
                car.description = encodedDescription;
                car.price = int.Parse(HttpContext.Current.Request.Form["price"]);
                car.year_manufacture = int.Parse(HttpContext.Current.Request.Form["year_manufacture"]);
                car.number_plate = HttpContext.Current.Request.Form["number_plate"];
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
                result.status = 1;
                return result;
            }
            catch (Exception)
            {
                return result;
                throw;
            }
        }


    }
}
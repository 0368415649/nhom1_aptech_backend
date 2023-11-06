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

namespace backend.Service
{
    public class CarServer
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();
        string connstr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public IEnumerable<car_view> GetAllCar(int? typeCar, int? brand, string order_by_price, string name)
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
            var car_view = GetAllCar(null, null, "", "");
            car_view.Join(
                    db.favorite_car,
                    cv => cv.car_id,
                    fc => fc.car_id,
                    (c, modelGroup) => new { c, modelGroup }
                );
            car_view = car_view
               .Where(item => item.car_id == 3)
               .GroupBy(item => new
               {
                   item.car_id,
               })
               .Select(group => group.First())
               .ToList();
            return car_view;
        }

        public IEnumerable<car_view> GetAllMyCar(int? customer_id)
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
                    complete_flg = res.book.complete_flg
                })
                .ToList();


            var cars = car_view
                .Where(item => item.customer_id == customer_id)
                .ToList();
            cars = cars.OrderBy(c => c.car_id).ToList();
            return cars;
        }


        public IEnumerable<car_view> Getcar(int id)
        {

            var car_view = db.car
                  .Join(
                      db.model,
                      c => c.model_id,
                      m => m.model_id,
                      (c, m) => new { c, m }
                  ).Join(
                      db.brand,
                      c => c.c.brand_id,
                      b => b.brand_id,
                      (c, b) => new { c, b }
                  ).Join(
                      db.car_type,
                      c => c.c.c.car_type_id,
                      ct => ct.car_type_id,
                      (c, ct) => new { c, ct }
                  ).Select(res => new car_view()
                  {
                      car_id = res.c.c.c.car_id,
                      model_id = res.c.c.c.model_id,
                      model_name = res.c.c.m.model_name,
                      brand_id = res.c.c.c.brand_id,
                      brand_name = res.c.b.brand_name,
                      price = res.c.c.c.price,
                      count_journeys = res.c.c.c.count_journeys,
                      address = res.c.c.c.address,
                      customer_id = res.c.c.c.customer_id,
                      image = res.c.c.c.image,
                      description = res.c.c.c.description,
                      rate = 5,
                      number_plate = res.c.c.c.number_plate,
                      year_manufacture = res.c.c.c.year_manufacture,
                      number_seats = res.ct.number_seats
                  }).ToList();

            var cars = car_view
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



    }
}
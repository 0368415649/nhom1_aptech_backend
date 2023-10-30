﻿using backend.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace backend.Service
{
    public class CarServer
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();
        string connstr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public IEnumerable<car_view> GetAllCar(int? typeCar, int? brand, string order_by_price, string name)
        {
            var car_view = db.car
                 .Join(
                     db.model,
                     c => c.model_id,
                     m => m.model_id,
                     (c, m) => new { c, m }
                 ).Join(
                     db.brand,
                     cm => cm.c.brand_id,
                     b => b.brand_id,
                     (cm, b) => new { cm, b }
                 ).Select(res => new car_view()
                 {
                     car_id = res.cm.c.car_id,
                     model_id = res.cm.c.model_id,
                     car_type_id = res.cm.c.car_type_id,
                     model_name = res.cm.m.model_name,
                     brand_id = res.cm.c.brand_id,
                     brand_name = res.b.brand_name,
                     price = res.cm.c.price,
                     count_journeys = res.cm.c.count_journeys,
                     address = res.cm.c.address,
                     customer_id = res.cm.c.customer_id,
                     car_status_id = res.cm.c.car_status_id,
                     image = res.cm.c.image
                 }).ToList();

            var cars = car_view
                .Where(item => item.car_status_id == 3)
                .Where(item => item.model_name.Contains(name ?? ""))
                .Where(item => typeCar == null || item.car_type_id == typeCar)
                .Where(item => brand == null || item.brand_id == brand).ToList();
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


        public IEnumerable<car_view> GetAllMyCar(int? customer_id)
        {
            var car_view = db.car
                 .Join(
                     db.model,
                     c => c.model_id,
                     m => m.model_id,
                     (c, m) => new { c, m }
                 ).Join(
                     db.car_status,
                     ct => ct.c.car_status_id,
                     t => t.car_status_id,
                     (ct, t) => new { ct, t }
                 ).Join(
                     db.brand,
                     cm => cm.ct.c.brand_id,
                     b => b.brand_id,
                     (cm, b) => new { cm, b }
                 ).Select(res => new car_view()
                 {
                     car_id = res.cm.ct.c.car_id,
                     model_id = res.cm.ct.c.model_id,
                     car_type_id = res.cm.ct.c.car_type_id,
                     model_name = res.cm.ct.m.model_name,
                     brand_id = res.cm.ct.c.brand_id,
                     brand_name = res.b.brand_name,
                     price = res.cm.ct.c.price,
                     count_journeys = res.cm.ct.c.count_journeys,
                     address = res.cm.ct.c.address,
                     customer_id = res.cm.ct.c.customer_id,
                     car_status_id = res.cm.ct.c.car_status_id,
                     car_status_name = res.cm.t.car_status_name,
                     image = res.cm.ct.c.image
                 }).ToList();

            var cars = car_view
                .Where(item => item.customer_id == customer_id).ToList();
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
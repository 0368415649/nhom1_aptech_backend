using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Service
{
    public class CommonLogic
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();
        public List<car_view> convertCar(IQueryable<car_view> result)
        {
            List<car_view> cars = new List<car_view>();
            foreach (car_view car in result)
            {
                car_view car_View = new car_view();
                car_View.car_id = car.car_id;
                car_View.model_id = car.model_id;
                car_View.car_type_id = car.car_type_id;
                car_View.model_name = car.model_name;
                car_View.brand_id = car.brand_id;
                car_View.brand_name = car.brand_name;
                car_View.price = car.price;
                car_View.count_journeys = car.count_journeys;
                car_View.address = car.address;
                car_View.customer_id = car.customer_id;
                car_View.car_status_id = car.car_status_id;
                car_View.image = car.image;
                car_View.favorite_car_id = car.favorite_car_id;
                car_View.number_plate = car.number_plate;
                car_View.year_manufacture = car.year_manufacture;
                car_View.name_display = car.name_display;
                car_View.phone = car.phone;
                result_data result_datad = getRateCar(car.car_id);
                if (result_datad != null)
                {
                    car_View.count_comment = result_datad.Count;
                    car_View.rate_avg = result_datad.AverageRate;
                    car_View.rate = result_datad.AverageRate;
                }
                cars.Add(car_View);
            }
            return cars;
        }

        public List<car_view> convertMyCar(List<car_view> result)
        {
            List<car_view> cars = new List<car_view>();
            foreach (car_view car in result)
            {
                car_view car_View = new car_view();
                car_View.car_id = car.car_id;
                car_View.model_id = car.model_id;
                car_View.car_type_id = car.car_type_id;
                car_View.model_name = car.model_name;
                car_View.brand_id = car.brand_id;
                car_View.brand_name = car.brand_name;
                car_View.price = car.price;
                car_View.count_journeys = car.count_journeys;
                car_View.address = car.address;
                car_View.customer_id = car.customer_id;
                car_View.car_status_id = car.car_status_id;
                car_View.car_status_name = car.car_status_name;
                car_View.image = car.image;
                car_View.complete_flg = car.complete_flg;
                car_View.description = car.description;
                result_data result_datad = getRateCar(car.car_id);
                if (result_datad != null)
                {
                    car_View.count_comment = result_datad.Count;
                    car_View.rate_avg = result_datad.AverageRate;
                    car_View.rate = result_datad.AverageRate;
                }
                cars.Add(car_View);
            }
            return cars;
        }


        public List<car_view> convertAllCar(List<car_view> result)
        {
            List<car_view> cars = new List<car_view>();
            foreach (car_view car in result)
            {
                car_view car_View = new car_view();
                car_View.car_id = car.car_id;
                car_View.model_id = car.model_id;
                car_View.car_type_id = car.car_type_id;
                car_View.model_name = car.model_name;
                car_View.brand_id = car.brand_id;
                car_View.brand_name = car.brand_name;
                car_View.price = car.price;
                car_View.count_journeys = car.count_journeys;
                car_View.address = car.address;
                car_View.customer_id = car.customer_id;
                car_View.car_status_id = car.car_status_id;
                car_View.image = car.image;
                car_View.boocking_status_id = car.boocking_status_id;
                result_data result_datad = getRateCar(car.car_id);
                if (result_datad != null)
                {
                    car_View.count_comment = result_datad.Count;
                    car_View.rate_avg = result_datad.AverageRate;
                    car_View.rate = result_datad.AverageRate;
                }
                cars.Add(car_View);
            }
            return cars;
        }

        public result_data getRateCar(int id)
        {
            result_data result_data = new result_data();
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
            if (feedbackStatistics != null)
            {
                count = feedbackStatistics.count;
                avgRate = (double)feedbackStatistics.averageRate;
            }
            result_data.Count = count;
            result_data.AverageRate = avgRate;
            return result_data;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class car_view
    {
        public int car_id { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<int> year_manufacture { get; set; }
        public string number_plate { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string image { get; set; }
        public Nullable<int> is_delete { get; set; }
        public Nullable<int> car_status_id { get; set; }
        public Nullable<int> brand_id { get; set; }
        public Nullable<int> model_id { get; set; }
        public Nullable<int> car_type_id { get; set; }
        public Nullable<int> customer_id { get; set; }
        public Nullable<int> vehicle_registration_id { get; set; }
        public Nullable<int> count_journeys { get; set; }
        public string model_name { get; set; }

    }
}
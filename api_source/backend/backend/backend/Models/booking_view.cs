using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class booking_view
    {
        public int booking_id { get; set; }
        public string start_date { get; set; }
        public string start_time { get; set; }
        public string end_date { get; set; }
        public string end_time { get; set; }
        public Nullable<int> total { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Nullable<int> complete_flg { get; set; }
        public Nullable<int> boocking_status_id { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<int> car_id { get; set; }
        public Nullable<int> owner_id { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string name_display { get; set; }
        public string full_name { get; set; }
        public string birthday { get; set; }
        public string password { get; set; }
        public string sex { get; set; }
        public Nullable<int> role_id { get; set; }
        public string id_number { get; set; }
        public string id_frontside { get; set; }
        public string id_backside { get; set; }
        public Nullable<int> verify_flg { get; set; }
    }
}
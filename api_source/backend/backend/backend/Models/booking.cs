//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace backend.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class booking
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class feeback_view
    {
        public int feeback_id { get; set; }
        public Nullable<int> rate { get; set; }
        public string comment { get; set; }
        public string create_at { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<int> car_id { get; set; }
        public string name_display { get; set; }

    }
}
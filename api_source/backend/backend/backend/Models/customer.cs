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
    
    public partial class customer
    {
        public int customer_id { get; set; }
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

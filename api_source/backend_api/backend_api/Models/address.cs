//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace backend_api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class address
    {
        public int address_id { get; set; }
        public string address_name { get; set; }
        public Nullable<int> customer_id { get; set; }
    }
}

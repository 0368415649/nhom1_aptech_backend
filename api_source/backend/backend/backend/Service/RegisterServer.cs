using backend.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BCrypt.Net;

namespace backend.Service
{
    public class RegisterServer
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();

        public void registerCustomer(customer customer)
        {
            
            try
            {
                customer.password = BCrypt.Net.BCrypt.HashPassword(customer.password);
                db.customer.Add(customer);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
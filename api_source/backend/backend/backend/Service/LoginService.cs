using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using LoginStatus = backend.Models.LoginStatus;

namespace backend.Service
{
    public class LoginService
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();

        public LoginStatus CheckLogin(string phone, string password)
        {
            LoginStatus loginStatus = new LoginStatus();
            try
            {
                customer cus = db.customer.FirstOrDefault(c => c.phone == phone);
                if (cus == null)
                {
                    loginStatus.status = 0;
                    return loginStatus;
                }
                bool isPassword = BCrypt.Net.BCrypt.Verify(password, cus.password);
                if (isPassword)
                {
                    loginStatus.status = 1;
                    loginStatus.customer_id = cus.customer_id;
                    return loginStatus;
                }

                loginStatus.status = 0;
                return loginStatus;
            }
            catch (Exception)
            {
                loginStatus.status = 0;
                return loginStatus;
                throw;
            }
        }

        public bool CheckPassword(int customer_id, string password)
        {
            try
            {
                customer cus = db.customer.FirstOrDefault(c => c.customer_id == customer_id );
                if (cus == null)
                {
                    return false;
                }
                bool isPassword = BCrypt.Net.BCrypt.Verify(password, cus.password);
                if (isPassword)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

    }
}
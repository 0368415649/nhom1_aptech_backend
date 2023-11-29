using backend.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;

namespace backend.Service
{
    public class CustomerService
    {
        private ADDDA_APPEntities db = new ADDDA_APPEntities();
        string connstr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public bool VerifyCustomer(customer customer)
        {
            SqlConnection cnn = new SqlConnection(connstr);
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE [customer] SET ");
                sql.Append(" full_name = N'" + customer.full_name + "', ");
                sql.Append(" birthday = N'" + customer.birthday + "', ");
                sql.Append(" id_number = N'" + customer.id_number + "', ");
                sql.Append(" id_frontside = N'" + customer.id_frontside + "', ");
                sql.Append(" id_backside = N'" + customer.id_backside + "', ");
                sql.Append(" verify_flg = " + 1);
                sql.Append(" WHERE  customer_id  =  " + customer.customer_id);

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

        public bool InvalidVerifyCustomer(customer customer)
        {
            SqlConnection cnn = new SqlConnection(connstr);
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE [customer] SET ");
                sql.Append(" verify_flg = " + 3);
                sql.Append(" WHERE  customer_id  =  " + customer.customer_id);
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

        public bool ValidVerifyCustomer(customer customer)
        {
            SqlConnection cnn = new SqlConnection(connstr);
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE [customer] SET ");
                sql.Append(" verify_flg = " + 2);
                sql.Append(", role_id = " + 2);
                sql.Append(" WHERE  customer_id  =  " + customer.customer_id);
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

        public bool ChangeProfileCustomer(customer customer)
        {
            SqlConnection cnn = new SqlConnection(connstr);
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE [customer] SET ");
                sql.Append(" name_display = N'" + customer.name_display + "', ");
                sql.Append(" birthday = N'" + customer.birthday + "', ");
                sql.Append(" sex = N'" + customer.sex + "' ");
                sql.Append(" WHERE  customer_id  =  " + customer.customer_id);

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


        public bool ChangePhone(customer customer)
        {
            SqlConnection cnn = new SqlConnection(connstr);
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE [customer] SET ");
                sql.Append(" phone = N'" + customer.phone + "' ");
                sql.Append(" WHERE  customer_id  =  " + customer.customer_id);

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

        public bool ChangeMail(customer customer)
        {
            SqlConnection cnn = new SqlConnection(connstr);
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE [customer] SET ");
                sql.Append(" email = N'" + customer.email + "' ");
                sql.Append(" WHERE  customer_id  =  " + customer.customer_id);

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

        public bool ChangePassword(customer customer)
        {
            SqlConnection cnn = new SqlConnection(connstr);
            try
            {
                customer.password = BCrypt.Net.BCrypt.HashPassword(customer.password);
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE [customer] SET ");
                sql.Append(" password = N'" + customer.password + "' ");
                sql.Append(" WHERE  customer_id  =  " + customer.customer_id);

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
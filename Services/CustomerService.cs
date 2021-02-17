using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using BCT.SwaggerAPI.Model;

namespace BCT.SwaggerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        public int Add(Customer Customer)
        {
            string sQry = "INSERT INTO [Customer] ([FirstName],[LastName],[City],[State],[Country]) " +
                "VALUES('" + Customer.FirstName + "','" + Customer.LastName + "','" + Customer.City + "','" +
                Customer.State + "','" + Customer.Country + "')";
            int retVal = ExecuteCRUDByQuery(sQry);
            return retVal;
        }

        public int AddRange(IEnumerable<Customer> customers)
        {
            string sQry = "INSERT INTO [Customer] ([FirstName],[LastName],[City],[State],[Country]) VALUES";
            string sVal = "";
            foreach (var customer in customers)
                sVal += "('" + customer.FirstName + "','" + customer.LastName + "','" + customer.City + "','" + customer.State + "','" + customer.Country + "'),";
            sVal = sVal.TrimEnd(',');
            sQry = sQry + sVal;
            int retVal = ExecuteCRUDByQuery(sQry);
            return retVal;
        }

        public Customer Find(int id)
        {
            Customer Customer = null;
            string sQry = "SELECT * FROM [Customer] WHERE [Id]=" + id;
            DataTable dtCustomer = ExecuteQuery(sQry);
            if (dtCustomer != null)
            {
                DataRow dr = dtCustomer.Rows[0];
                Customer = GetCustomerByRow(dr);
            }
            return Customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            List<Customer> Customers = null;
            string sQry = "SELECT * FROM [Customer]";
            DataTable dtCustomer = ExecuteQuery(sQry);
            if (dtCustomer != null)
            {
                Customers = new List<Customer>();
                foreach (DataRow dr in dtCustomer.Rows)
                    Customers.Add(GetCustomerByRow(dr));
            }
            return Customers;
        }

        public int Remove(int id)
        {
            string sQry = "DELETE FROM [Customer] WHERE [Id]=" + id;
            int retVal = ExecuteCRUDByQuery(sQry);
            return retVal;
        }

        public int Update(Customer Customer, int id)
        {
            string sQry = "UPDATE [Customer] SET [FirstName]='" + Customer.FirstName + "',[LastName]='" + Customer.LastName + "',[City]='" + Customer.City + "',[State]='" + Customer.State + "',[Country]='" + Customer.Country + "' WHERE [Id]=" + id;
            int retVal = ExecuteCRUDByQuery(sQry);
            return retVal;
        }
        // code detail is below  
        private int ExecuteCRUDByQuery(string strSql)
        {
            string sConStr = "Data Source=. ;Initial Catalog=EmployeeDB; Integrated Security=true";
            SqlConnection conn = null;
            int iR = 0;
            try
            {
                conn = new SqlConnection(sConStr);
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                //Execute the command  
                iR = cmd.ExecuteNonQuery();
            }
            catch { iR = 0; }
            finally { if (conn.State != 0) conn.Close(); }
            return iR;
        }

        private DataTable ExecuteQuery(string strSql)
        {
            string sConStr = "Data Source=. ;Initial Catalog=EmployeeDB; Integrated Security=true";
            SqlConnection conn = null;
            DataTable dt = null;
            try
            {
                conn = new SqlConnection(sConStr);
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                conn.Open();
                dt = new DataTable();
                //Fill the dataset  
                da.Fill(dt);
                if (!(dt.Rows.Count > 0)) dt = null;
            }
            catch { dt = null; }
            finally { if (conn.State != 0) conn.Close(); }
            return dt;
        }

        private Customer GetCustomerByRow(DataRow dr)
        {
            Customer Customer = new Customer();
            Customer.Id = Convert.ToInt32(dr["Id"]);
            Customer.FirstName = dr["FirstName"].ToString();
            Customer.LastName = dr["LastName"].ToString();
            Customer.City = dr["City"].ToString();
            Customer.State = dr["State"].ToString();
            Customer.Country = dr["Country"].ToString();
            return Customer;
        }

    }
}


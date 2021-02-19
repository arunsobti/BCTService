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
    public class CustomerIssuesService : ICustomerIssuesService
    {
        public int Add(CustomerIssues CustomerIssues)
        {
            string sQry = "INSERT INTO [CustomerIssues] ([Issue],[CreationDate],[IssueTrackingDate],[Status],[Amount], [UserLastUpdated]) " +
                "VALUES('" + CustomerIssues.Issue + "','" + CustomerIssues.CreationDate + "','" + CustomerIssues.IssueTrackingDate + "','" +
                CustomerIssues.Status + "','" + CustomerIssues.Amount + "','" + CustomerIssues.UserLastUpdated + "')";
            int retVal = ExecuteCRUDByQuery(sQry);
            return retVal;
        }

        public int AddRange(IEnumerable<CustomerIssues> customerIssues)
        {
            string sQry = "INSERT INTO [CustomerIssues] ([Issue],[CreationDate],[IssueTrackingDate],[Status],[Amount], [UserLastUpdated]) VALUES";
            string sVal = "";
            foreach (var CustomerIssues in customerIssues)
                sVal += "('" + CustomerIssues.Issue + "','" + CustomerIssues.CreationDate + "','" + CustomerIssues.IssueTrackingDate + "','" +
                CustomerIssues.Status + "','" + CustomerIssues.Amount + "','" + CustomerIssues.UserLastUpdated + "'),";
            sVal = sVal.TrimEnd(',');
            sQry = sQry + sVal;
            int retVal = ExecuteCRUDByQuery(sQry);
            return retVal;
        }

        public CustomerIssues Find(int id)
        {
            CustomerIssues CustomerIssues = null;
            string sQry = "SELECT * FROM [CustomerIssues] WHERE [Id]=" + id;
            DataTable dtCustomerIssues = ExecuteQuery(sQry);
            if (dtCustomerIssues != null)
            {
                DataRow dr = dtCustomerIssues.Rows[0];
                CustomerIssues = GetCustomerIssuesByRow(dr);
            }
            return CustomerIssues;
        }

        public IEnumerable<CustomerIssues> GetAll()
        {
            List<CustomerIssues> CustomerIssues = null;
            string sQry = "SELECT * FROM [CustomerIssues]";
            DataTable dtCustomerIssues = ExecuteQuery(sQry);
            if (dtCustomerIssues != null)
            {
                CustomerIssues = new List<CustomerIssues>();
                foreach (DataRow dr in dtCustomerIssues.Rows)
                    CustomerIssues.Add(GetCustomerIssuesByRow(dr));
            }
            return CustomerIssues;
        }

        public int Remove(int id)
        {
            string sQry = "DELETE FROM [CustomerIssues] WHERE [Id]=" + id;
            int retVal = ExecuteCRUDByQuery(sQry);
            return retVal;
        }

        public int Update(CustomerIssues CustomerIssues, int id)
        {
            string sQry = "UPDATE [CustomerIssues] SET [Issue]='" + CustomerIssues.Issue + "',[IssueTrackingDate]='" + CustomerIssues.IssueTrackingDate + "',[Amount]='" + CustomerIssues.Amount + "',[Status]='" + CustomerIssues.Status + "',[UserLastUpdated]='" + CustomerIssues.UserLastUpdated + "' WHERE [Id]=" + id;
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

        private CustomerIssues GetCustomerIssuesByRow(DataRow dr)
        {
            CustomerIssues CustomerIssues = new CustomerIssues();
            CustomerIssues.Id = Convert.ToInt32(dr["Id"]);
            CustomerIssues.Amount = dr["Amount"].ToString();
            CustomerIssues.CreationDate = dr["CreationDate"].ToString();
            CustomerIssues.Issue = dr["Issue"].ToString();
            CustomerIssues.IssueTrackingDate = dr["IssueTrackingDate"].ToString();
            CustomerIssues.Status = dr["Status"].ToString();
            CustomerIssues.UserLastUpdated = dr["UserLastUpdated"].ToString();
            return CustomerIssues;
        }

    }
}


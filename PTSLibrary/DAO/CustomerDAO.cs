using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PTSLibrary.DAO
{
    class CustomerDAO
    {
        public int Authenticate (string username, string password)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            Customer cust;

            sql = "SELECT CustomerId FROM customer WHERE Username= '{0}' AND Password='{1}'";
            cn = new SqlConnection();
            cmd = new SqlCommand(sql, cn);
            int id = 0;

            try
            {
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (dr.Read())
                {
                    id = (int)dr["CustomerID"];

                }   
                dr.Close();


                while (dr.Read())
                {
                    List<Task> tasks = new List<Task>();
                    sql = "SELECT * FROM Tank WHERE ProjectId = ' " + dr["Project Id"].ToString() + " ' ";
                    SqlConnection cn2 = new SqlConnection("Data Source=DESKTOP-9A7I7EN;Initial Catalog=wm75;Integrated Security=True");
                    SqlCommand cmd2 = new SqlCommand(sql, cn2);

                    cn2.Open();
                    SqlDataReader dr2 = cmd2.ExecuteReader();

                    while (dr2.Read())
                    {
                        Task t = new Task((Guid)dr2["TaskId"], dr2["Name"].ToString(), (Status)dr2["StatusId"]);
                        tasks.Add(t);
                    }
                    dr2.Close();
                    Project p = new Project(dr["Name"].ToString(), (DateTime)dr["ExpectedStartDate"], (DateTime)dr["ExpectedEndDate"], (Guid)dr["Project Id"], tasks);
                    
                   
                }

                dr.Close();
            }

            catch (SqlException ex)
            {
                throw new Exception("Error Accessing Database", ex);
            }
            finally
            {
                cn.Close();
            }
            return id;
        }


                
    }
}
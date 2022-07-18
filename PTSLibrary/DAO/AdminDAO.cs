using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PTSLibrary.DAO
{
    class AdminDAO
    {
        public void CreateProject(string name, DateTime startDate, DateTime endDate, int customerId, int administratorId)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            Guid projectId = Guid.NewGuid();
            sql = "INSERT INTO Project(ProjectId, Name, ExpectedStartDate, ExpectedEndDate, CustomerId, AdministratorId)";
            sql += String.Format("VALUES({ 0},{ 1},{ 2},{ 3},{ 4},{ 5})", projectId, name, startDate, endDate, customerId, administratorId);
            cn = new SqlConnection("Data Source=DESKTOP-9A7I7EN;Initial Catalog=wm75;Integrated Security=True");
            cmd = new SqlCommand(sql, cn);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Inserting", ex);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
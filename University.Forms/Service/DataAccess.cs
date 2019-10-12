using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace UniversityApp.Forms.Service
{
    public class DataAccess
    {
        public DataTable ExecuteQuery(string command)
        {
            DataTable table = new DataTable();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                connection.Open();

                var adapter = new SqlDataAdapter(command, connection);

                adapter.Fill(table);
            }

            return table;
        }

        public void ExecuteNonQuery(string command)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                connection.Open();

                var sqlCommand = new SqlCommand(command, connection);

                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsAndVegetablesApp.ViewModels
{
    public class FoodDBConnector:IDBConnector
    {
        public string ConnectionString { get; set; }

        public FoodDBConnector(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public SqlConnection Connect()
        {
            return new SqlConnection(ConnectionString);
        }

        public void Disconnect(SqlConnection connection)
        {
            connection.Close();
        }
    }
}

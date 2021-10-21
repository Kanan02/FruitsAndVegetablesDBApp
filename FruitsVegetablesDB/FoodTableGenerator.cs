using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FruitsVegetablesDB
{
    public class FoodTableGenerator
    {
        public string StrConnect { get; set; }
        public FoodTableGenerator(string strConnect)
        {
            StrConnect = strConnect;
        }
        public bool CreateFoodTable()
        {
            using (SqlConnection con = new SqlConnection(StrConnect))
            {
                con.Open();
                try
                {
                    string str = @"CREATE TABLE Food (
                                    Id int NOT NULL PRIMARY KEY,
                                    Name varchar(255),
                                    Type varchar(255),
                                    Color varchar(255),
                                    Calority varchar(255)
                                );";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                
            }
        }
    }
}

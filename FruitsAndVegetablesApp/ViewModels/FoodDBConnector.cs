using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsAndVegetablesApp.ViewModels
{
    public class FoodDBConnector:IDBConncetor
    {
        public string ConnectionString { get; set; }

        public FoodDBConnector(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsAndVegetablesApp.ViewModels
{
    public interface IDBConnector
    {
        SqlConnection Connect();
        void Disconnect(SqlConnection connection);
    }
}

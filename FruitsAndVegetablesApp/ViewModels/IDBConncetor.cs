using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsAndVegetablesApp.ViewModels
{
    public interface IDBConncetor
    {
        void Connect();
        void Disconnect();
    }
}

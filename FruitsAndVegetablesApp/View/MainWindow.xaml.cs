using FruitsAndVegetablesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using FruitsAndVegetablesApp.Models;

namespace FruitsAndVegetablesApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDBConnector connector;
        private SqlConnection connection;
        public MainWindow()
        {
            InitializeComponent();
            connector = new FoodDBConnector(ConfigurationManager.ConnectionStrings["Local"].ConnectionString);
            connection = new SqlConnection("");
            
        }
        private void connectionButton_Click(object sender, RoutedEventArgs e)
        {
            
            if ((sender as Button).Content.ToString()=="Connect")
            {
                connection=connector.Connect();
                connection.Open();
                MessageBox.Show("Opened","Connection is Opened!",MessageBoxButton.OK,MessageBoxImage.Information);
                (sender as Button).Content = "Disconnect";
            }
            else
            {
                connector.Disconnect(connection);
                MessageBox.Show("Closed", "Connection is Closed!", MessageBoxButton.OK, MessageBoxImage.Information);
                (sender as Button).Content = "Connect";
            }
        }

        private void GetAll_Click(object sender, RoutedEventArgs e)
        {
            string query = "";
            DataTable data = new DataTable();
            if (connection.ConnectionString=="")
            {
                MessageBox.Show("Connect to Database First!");
                return;
            }
            switch ((sender as Button).Name)
            {
                case "GetAll":
                    query = "Select * from Food";
                    break;
                case "GetNames":
                    query = "Select Name from Food";
                    break;
                case "GetColors":
                    query = "Select Color from Food";
                    break;
                case "GetMaxCal":
                    query = "Select MAX(Calority) as Max from Food";
                    break;
                case "GetMinCal":
                    query = "Select MIN(Calority) as Min from Food";
                    break;
                case "GetAverCal":
                    query = "Select AVG(Calority) as Average from Food";
                    break;
                case "GetNumOfVeg":
                    query = "Select count(*) as 'Number of vegetables' from Food where Type='Vegetable'";
                    break;
                case "GetNumOfFruits":
                    query = "Select count(*) as 'Number of fruits' from Food where Type='Fruit'";
                    break;
                case "GetFoodOfCertainColor":
                    query = $"Select count(*) from Food where Color='{colorTextBox.Text}'";
                    break;
                case "GetNumOfFruitsOfEachColor":
                    query = "Select count(*),Color from Food group by Color";
                    break;
                case "GetFoodOfLessCalority":
                    query = $"Select * from Food where Calority<={lessCalTextBox.Text}";
                    break;
                case "GetFoodOfHigherCalority":
                    query = $"Select * from Food where Calority>{higherCalTextBox.Text}";
                    break;
                case "CalInterval":
                    query = $"Select *  from Food where Calority between {lcalTextBox.Text} and {hcalTextBox.Text}";
                    break;
                case "RedOrYellow":
                    query = "Select * from Food where Color='Red' or Color='Yellow'";
                    break;
                default:
                    break;
            }
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {

                adapter.Fill(data);
            }
            dataGrid.ItemsSource = data.AsDataView();

        }
        //private void ReadData(SqlDataReader reader)
        //{
          
        //    do
        //    {
                
        //        for (int i = 1; i < reader.FieldCount; ++i)
        //        {
        //            var column = new DataGridTextColumn();
        //            column.Header = reader.GetName(i);
        //            column.Binding = new Binding(reader.GetName(i));
        //            dataGrid.Columns.Add(column);
        //        }
                
        //        while (reader.Read())
        //        {
                    
        //            List<string> items = new List<string>();
        //            for (int i = 0; i < reader.FieldCount; i++)
        //            {

        //                items.Add (reader[i].ToString());
        //            }
        //            dataGrid.Items.Add(new Food { Id=int.Parse(items[0]),Name=items[1],Type=items[2],Color=items[3], Calority = int.Parse(items[4]) });

        //        }
        //    } while (reader.NextResult());
        //    reader.Close();



        //}
    }
}

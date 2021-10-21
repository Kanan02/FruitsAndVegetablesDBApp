using System;

namespace FruitsVegetablesDB
{
    class Program
    {
        static void Main(string[] args)
        {
            FoodTableGenerator foodTable = new FoodTableGenerator(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = FruitsAndVegetables;Integrated Security=True;");
            if (foodTable.CreateFoodTable())
            {
                Console.WriteLine("Food table is created!");
            }
            else
            {
                Console.WriteLine("Food table already exists!");

            }

        }
    }
}

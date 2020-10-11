using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2;

namespace Bazar.Models
{
    public class DatabaseOperation
    {
        public static List<CarModel> FetchAllCars()
        {
            List<CarModel> allCars = new List<CarModel>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Startup.ConnectionString;

            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM cars", conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CarModel car = new CarModel(reader);
                            allCars.Add(car);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return allCars;
        }
            
            
       

        public static void InsertCar(CarModel car)
        {
            string query = "INSERT INTO cars (marca, modelul, anul, volumul, puterea, combustibilul, caroseria, fotografia, descriere, pretul, contact) VALUES (@marca, @modelul, @anul, @volumul, @puterea, @combustibilul, @caroseria, @fotografia, @descriere, @pretul, @contact);";
            Dictionary<string, object> parameters = new Dictionary<string, object>()  { { "@marca",car.Marca }, {"@modelul", car.Modelul }, {"@anul", car.Anul }, { "@volumul", car.Volumul }, { "@puterea", car.Puterea }, {"@combustibilul",car.Combustibilul },
                        {"@caroseria", car.Caroseria }, {"@fotografia",car.Fotografia }, {"@descriere", car.Descriere }, {"@pretul", car.Pretul }, {"@contact", car.Contact } };
            ExecuteCommand(query, parameters);
        }



        public static void RemoveCarFromDatabase(CarModel car)
        {
            string query = "DELETE FROM cars WHERE Id = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@id", car.Id } };
            ExecuteCommand(query, parameters);
        }





        public static void ExecuteCommand(string query, Dictionary<string, object> par)
        {
            
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Startup.ConnectionString;
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    foreach (KeyValuePair<string, object> entry in par)
                    {
                        command.Parameters.AddWithValue(entry.Key, entry.Value);
                    }
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
           
        }     
    }
}

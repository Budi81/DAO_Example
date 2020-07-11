using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DAO_Example
{
    public class CarRepoFromDatabase : ICarRepo
    {
        private string connectionString = @"Server=localhost\SQLEXPRESS01;Database=CarsDatabase;Trusted_Connection = True;";
        private string querryString = @"SELECT * from [Dao].[Vehicles]";

        public List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(querryString, dbConnection);

            dbConnection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Car car = new Car
                {
                    RegistrationNumber = reader[1].ToString(),
                    Name = reader[2].ToString(),
                    Model = reader[3].ToString(),
                    YearOfProduction = Convert.ToInt32(reader[4])
                };

                   cars.Add(car);
            }
            reader.Close();
            dbConnection.Dispose();

            return cars;
        }

        public Car CreateCar(Dictionary<string, string> carInfo)
        {
            throw new NotImplementedException();
        }

        public void DelateCar(Car car, List<Car> allCars)
        {
            throw new NotImplementedException();
        }

        public Car GetCar(string registrationNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdateCar(Car car, Dictionary<string, string> carInfo, List<Car> allCars)
        {
            throw new NotImplementedException();
        }

        public void WriteFile(List<Car> allCars)
        {
            throw new NotImplementedException();
        }
    }
}

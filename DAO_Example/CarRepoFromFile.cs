﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Text;

namespace DAO_Example
{
    /// <summary>
    /// Concrete Class
    /// </summary>
    public class CarRepoFromFile : ICarRepo
    {
        private string fileName = "dane.txt";

        public List<Car> CreateCar(Dictionary<string, string> carInfo)
        {
            List<Car> allCars = GetAllCars(); 
            Car car = new Car
            {
                RegistrationNumber = carInfo["Registration Number"],
                Name = carInfo["make"],
                Model = carInfo["model"],
                YearOfProduction = Convert.ToInt32(carInfo["year of production"])
            };

            allCars.Add(car);

            return allCars;

        }

        public List<Car> DelateCar(Car car)
        {
            var allCars = GetAllCars();
            allCars.Remove(allCars.FirstOrDefault(x => x.RegistrationNumber == car.RegistrationNumber));
            Console.WriteLine($@"Registration number: {car.RegistrationNumber} delated from database.");

            return allCars;
        }
         
        public void WriteFile(List<Car> allCars)
        {
            FileInfo file = new FileInfo(fileName);

            if (file.Exists)
            {
                file.Delete();
                file.Create().Close();
            }
            else
            {
                file.Create().Close();
            }

            using (StreamWriter sw = file.AppendText())
            {
                foreach (var item in allCars)
                {
                    string line = $"{item.RegistrationNumber}, {item.Name}, " +
                        $"{item.Model}, {item.YearOfProduction}";

                    sw.WriteLine(line);
                }
            }
        }

        public List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] s = line.Split(",");

                    Car car = new Car
                    {
                        RegistrationNumber = s[0],
                        Name = s[1],
                        Model = s[2],
                        YearOfProduction = Convert.ToInt32(s[3])
                    };

                    cars.Add(car);
                }
            }

            return cars;
        }

        public Car GetCar(string registrationNumber)
        { 
           return GetAllCars().FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

        public List<Car> UpdateCar(Car car, Dictionary<string, string> carInfo)
        {
            List<Car> allCars = GetAllCars();

            if (allCars.Contains(car))
            {
                car.RegistrationNumber = carInfo["Registration Number"];
                car.Name = carInfo["Make"];
                car.Model = carInfo["Model"];
                car.YearOfProduction = Convert.ToInt32(carInfo["Year of production"]);
            }
            else
            {
                Console.WriteLine("No such record in database.");
            }

            return allCars;
        }
    }
}




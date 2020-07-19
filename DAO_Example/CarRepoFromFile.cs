using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Text;

namespace DAO_Example
{

    /// Concrete Class
    public class CarRepoFromFile : ICarRepo
    {
        private string fileName = "dane.txt";

        public void CreateCar(Dictionary<string, string> carInfo)
        {
            FileInfo file = new FileInfo(fileName);

            if (!file.Exists)
            {
                file.Create().Close();
            }
            /*
             I don't know why when sw.Writeline command doesn't write  string from new line?
             I had to use empty Writeline but it will give error if the file will be empty. 
            */
            using (StreamWriter sw = file.AppendText())
            {
                sw.WriteLine();
                string line = $"{carInfo["Registration number"]}, {carInfo["Make"]}, " +
                    $"{carInfo["Model"]}, {carInfo["Year of production"]}";

                sw.WriteLine(line);
            }

            //Car car = new Car
            //{
            //    RegistrationNumber = carInfo["Registration Number"],
            //    Name = carInfo["Make"],
            //    Model = carInfo["Model"],
            //    YearOfProduction = Convert.ToInt32(carInfo["Year of production"])
            //};

            //return car;
        }

        public void DelateCar(Car car)
        {
            var allCars = GetAllCars(); 
            allCars.Remove(allCars.FirstOrDefault(x => x.RegistrationNumber == car.RegistrationNumber));

            WriteFile(allCars);
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

                    Car car = new Car(s[0], s[1], s[2], Convert.ToInt32(s[3]));

                    cars.Add(car);
                }
            }

            return cars;
        }

        public Car GetCar(string registrationNumber)
        { 
           return GetAllCars().FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

        public void UpdateCar(Car car, Dictionary<string, string> carInfo)
        {
            var allCars = GetAllCars();
            var carToUpdate = allCars.Find(x => x.RegistrationNumber == car.RegistrationNumber);
            carToUpdate.ModifyRegistrationNumber(carInfo["Registration number"]);
            carToUpdate.ModifyMake(carInfo["Make"]);
            carToUpdate.ModifyModel(carInfo["Model"]);
            carToUpdate.ModifyYearOfProduction(Convert.ToInt32(carInfo["Year of production"]));

            WriteFile(allCars);
        }

        public bool CheckIfCarExists(Car car)
        {
            // I do not know how to make it work
            if (GetAllCars().FirstOrDefault(c => c.RegistrationNumber == car.RegistrationNumber) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
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
                    string line = $"{item.RegistrationNumber}, {item.Make}, " +
                        $"{item.Model}, {item.YearOfProduction}";

                    sw.WriteLine(line);
                }
            }
        }
    }
}




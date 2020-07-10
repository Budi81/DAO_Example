using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_Example
{

    /// Data Access Interface
    public interface ICarRepo
    {
        List<Car> GetAllCars();

        Car CreateCar(Dictionary<string, string> carInfo);

        List<Car> UpdateCar(Car car, Dictionary<string, string> carInfo);

        List<Car> DelateCar(Car car);

        Car GetCar(string registrationNumber);

        void WriteFile(List<Car> allCars);
    }
}

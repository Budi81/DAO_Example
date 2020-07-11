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

        void UpdateCar(Car car, Dictionary<string, string> carInfo, List<Car> allCars);

        void DelateCar(Car car, List<Car> allCars);

        Car GetCar(string registrationNumber);

        void WriteFile(List<Car> allCars);
    }
}

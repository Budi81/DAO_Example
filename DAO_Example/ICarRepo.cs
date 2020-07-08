using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_Example
{
    /// <summary>
    /// Data Access Interface
    /// </summary>
    public interface ICarRepo
    {
        List<Car> GetAllCars();

        List<Car> CreateCar(string[] carInfo);

        List<Car> UpdateCar(Car car, string[] carInfo);

        List<Car> DelateCar(Car car);

        Car GetCar(string registrationNumber);

        void WriteFile(List<Car> allCars);
    }
}

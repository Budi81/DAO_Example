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

        void CreateCar(string[] carInfo);

        Car UpdateCar(Car car);

        void DelateCar(Car car);

        Car GetCar(string registrationNumber);
    }
}

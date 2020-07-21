using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_Example
{

    /// Data Access Interface
    public interface ICarRepo
    {
        List<Car> GetAllCars();

        void CreateCar(Dictionary<string, string> carInfo);

        void UpdateCar(Car car, Dictionary<string, string> carInfo);

        void DelateCar(Car car);

        GetCarResult GetCar(string registrationNumber);

    }
}

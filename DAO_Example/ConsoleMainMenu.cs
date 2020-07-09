using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO_Example
{
    public class ConsoleMainMenu
    {
        private string[] menuOptions = { "Show all records", "Find record", "Create record", 
            "Update record", "Delate record", "Exit" };

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("select action:\n" +
                $"1) {menuOptions[0]}\n" +
                $"2) {menuOptions[1]}\n" +
                $"3) {menuOptions[2]}\n" +
                $"4) {menuOptions[3]}\n" +
                $"5) {menuOptions[4]}\n" +
                $"6) {menuOptions[5]}");
            Console.WriteLine(new string('-', 30));
        }

        public string RegistrationNumberInput()
        {
            Console.Write("Input registration number of the record you want to edit: ");
            string selectedCar = Console.ReadLine().ToUpper();
            Console.Clear();

            return selectedCar;
        }

        public void PrintCar(Car car)
        {
            Console.WriteLine($"Registration number: {car.RegistrationNumber}\n" +
                $"Name: {car.Name}\n" +
                $"Model: {car.Model}\n" +
                $"Year of production: {car.YearOfProduction}");
            Console.WriteLine(new string('-', 30));
        }

        public Dictionary<string, string> CreateCarInput()
        {
            Dictionary<string, string> carInput = new Dictionary<string, string>()
            {
                {"Registration Number", string.Empty},
                {"make", string.Empty},
                {"model", string.Empty},
                {"year of production", string.Empty}
            };
            //string[] carInput = {"car's Registration Number", "car's make", "car's model", "car's year of production"};

            foreach (var item in carInput)
            {
                Console.Write($"Input new car's {item.Key}: ");
                carInput[item.Key] = Console.ReadLine();
            }

            return carInput;
        }

        public Dictionary<string, string> UpdateCarInput(Car car)
        {
            Dictionary<string, string> carInput = new Dictionary<string, string>()
            {
                {"Registration number", car.RegistrationNumber},
                {"Make", car.Name},
                {"Model", car.Model},
                {"Year of production", car.YearOfProduction.ToString()}
            };

            Console.WriteLine(new string('-', 40));
            foreach (var item in carInput)
            {
                Console.WriteLine($"{item.Key}: ", item.Value);
            }
            Console.WriteLine(new string('-', 40));


            Console.WriteLine("Which record you want to update:\n" +
                $"1) {carInput.Keys.ToList()[0]}\n" +
                $"2) {carInput.Keys.ToList()[1]}\n" +
                $"3) {carInput.Keys.ToList()[2]}\n" +
                $"4) {carInput.Keys.ToList()[3]}\n");

            Console.ReadLine();

            return carInput;
        }

        public void EndProgram(bool endProgram)
        {
            endProgram = true;
        }

        public void UserChoice(int userChoice, List<Car> allCars, ICarRepo repo, bool endProgram)
        {
            switch (userChoice)
            {
                case 1:

                    foreach (var car in allCars)
                    {
                        PrintCar(car);
                    }
                    break;
                case 2:

                    Console.WriteLine();
                    PrintCar(repo.GetCar(RegistrationNumberInput()));

                    break;
                case 3:

                    var createdRecord =repo.CreateCar(CreateCarInput());
                    repo.WriteFile(createdRecord);

                    break;
                case 4:
                    var recordToUpdate = repo.GetCar(RegistrationNumberInput());
                    var updatedRecord = repo.UpdateCar(recordToUpdate,UpdateCarInput(recordToUpdate));
                    repo.WriteFile(updatedRecord);

                    break;
                case 5:
                    var delatedRecord = repo.DelateCar(repo.GetCar(RegistrationNumberInput()));
                    repo.WriteFile(delatedRecord);

                    break;
                case 6:
                    EndProgram(endProgram);

                    break;
                default:
                    Console.WriteLine("Wrong Choice");
                    break;
            }
        }

        public void ConsoleClear()
        {
            Console.Clear();
        }
    }
}

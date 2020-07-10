using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace DAO_Example
{
    public class ConsoleMainMenu
    {
        private string[] menuOptions = { "Show all records", "Find record", "Create record", 
            "Update record", "Delate record", "Exit" };

        public void ConsoleClear()
        {
            Console.Clear();
        }

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

        public string UserInputReader()
        {
            string message = "What do you want to do: ";
            Console.Write(message);
            return Console.ReadLine();
        }

        public string RegistrationNumberInput()
        {
            string message = "Input registration number of the record you want to edit: ";
            Console.WriteLine(new string('-', message.Length));
            Console.Write(message);
            string selectedCar = Console.ReadLine().ToUpper();
            Console.Clear();

            return selectedCar;
        }

        public void PrintCar(Car car)
        {
            Console.WriteLine(new string('-', 30));
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
                {"Make", string.Empty},
                {"Model", string.Empty},
                {"Year of production", string.Empty}
            };

            // gives an error on iteration of second element, don't know why
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

            var carToUpdateInput = carInput.ToDictionary(entry => entry.Key, entry => entry.Value);

            bool running = true;
            while (running)
            {
                Console.WriteLine(new string('-', 40));
                foreach (var item in carToUpdateInput)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
                Console.WriteLine(new string('-', 40));

                Console.WriteLine("Which record you want to update:\n" +
                    $"1) {carToUpdateInput.Keys.ToList()[0]}\n" +
                    $"2) {carToUpdateInput.Keys.ToList()[1]}\n" +
                    $"3) {carToUpdateInput.Keys.ToList()[2]}\n" +
                    $"4) {carToUpdateInput.Keys.ToList()[3]}\n" +
                    $"5) Apply changes and exit\n" +
                    $"6) Exit to Main menu");

                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out _))
                {
                    switch (Convert.ToInt32(userInput))
                    {
                        case 1:
                            Console.Write($"Input new {carToUpdateInput.Keys.ToList()[0]}: ");
                            string newRegistrationNumber = Console.ReadLine().ToUpper();
                            if (newRegistrationNumber.Length == 7)
                            {
                                carToUpdateInput["Registration number"] = newRegistrationNumber;
                                Console.WriteLine($"Registration number was changed to: {carToUpdateInput["Registration number"]}");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("That's not a proper registration number");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }

                            break;
                        case 2:
                            Console.Write($"Input new {carToUpdateInput.Keys.ToList()[1]}: ");
                            string newMake = Console.ReadLine();
                            carToUpdateInput["Make"] = newMake;
                            Console.WriteLine($"Make was changed to: {carToUpdateInput["Make"]}");
                            Thread.Sleep(2000);
                            Console.Clear();

                            break;
                        case 3:
                            Console.Write($"Input new {carToUpdateInput.Keys.ToList()[2]}: ");
                            string newModel = Console.ReadLine();
                            carToUpdateInput["Model"] = newModel;
                            Console.WriteLine($"Model was changed to: {carToUpdateInput["Model"]}");
                            Thread.Sleep(2000);
                            Console.Clear();

                            break;
                        case 4:
                            Console.Write($"Input new {carToUpdateInput.Keys.ToList()[3]}: ");
                            string newYearOfProduction = Console.ReadLine();
                            if (int.TryParse(newYearOfProduction, out _) && newYearOfProduction.Length <= 4)
                            {
                                carToUpdateInput["Year of production"] = newYearOfProduction;
                                Console.WriteLine($"Year of production was changed to: {carToUpdateInput["Year of production"]}");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Year of production must be four digit long");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }

                            break;
                        case 5:
                            carInput = carToUpdateInput.ToDictionary(entry => entry.Key, entry => entry.Value);
                            running = false;
                            
                            break;
                        case 6:
                            running = false;

                            break;
                        default:
                            Console.WriteLine("There's no such option to pick!");
                            Thread.Sleep(2000);
                            Console.Clear();

                            break;
                    }
                }
                else
                {
                    throw new ArgumentException(string.Empty, "Wrong imput. Use numbers from 1 to 5");
                }
            }

            return carInput;
        }

        public void UserChoice(int userChoice, ICarRepo repo)
        {
            List<Car> allCars = repo.GetAllCars();
            switch (userChoice)
            {
                case 1:
                    foreach (var car in allCars)
                    {
                        PrintCar(car);
                    }

                    break;
                case 2:
                    PrintCar(repo.GetCar(RegistrationNumberInput()));

                    break;
                case 3:
                    var createdRecord =repo.CreateCar(CreateCarInput());
                    allCars.Add(createdRecord);
                    repo.WriteFile(allCars);

                    break;
                case 4:
                    var recordToUpdate = repo.GetCar(RegistrationNumberInput());
                    var updatedRecord = repo.UpdateCar(recordToUpdate,UpdateCarInput(recordToUpdate));
                    repo.WriteFile(updatedRecord);

                    break;
                case 5:
                    Car carToDelate = repo.GetCar(RegistrationNumberInput());
                    var delatedRecord = repo.DelateCar(carToDelate);
                    Console.WriteLine($"Registration number: {carToDelate.RegistrationNumber} " +
                        $"delated from database.");
                    repo.WriteFile(delatedRecord);

                    break;
                default:
                    Console.WriteLine("Wrong Choice");
                    break;
            }
        }

    }
}

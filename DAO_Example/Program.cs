using System;
using System.IO;

namespace DAO_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endProgram = false;

            while (!endProgram)
            {
                ICarRepo repo = new CarRepoFromFile();

                var allCars = repo.GetAllCars();

                ConsoleMainMenu menu = new ConsoleMainMenu();

                menu.ShowMenu();

                var userChoice = menu.UserInputReader();

                while (!(int.TryParse(userChoice, out _)))
                {
                    menu.WrongInputInfo();
                    userChoice = menu.UserInputReader();
                }

                switch (int.Parse(userChoice))
                {
                    case 1:
                        foreach (var car in allCars)
                        {
                            menu.PrintCar(car);
                        }

                        break;
                    case 2:
                        menu.PrintCar(repo.GetCar(menu.RegistrationNumberInput()));

                        break;
                    case 3:
                        var createdRecord = repo.CreateCar(menu.CreateCarInput());
                        allCars.Add(createdRecord);
                        repo.WriteFile(allCars);

                        break;
                    case 4:
                        var recordToUpdate = repo.GetCar(menu.RegistrationNumberInput());
                        repo.UpdateCar(recordToUpdate, menu.UpdateCarInput(recordToUpdate), allCars);
                        repo.WriteFile(allCars);

                        break;
                    case 5:
                        Car carToDelate = repo.GetCar(menu.RegistrationNumberInput());
                        repo.DelateCar(carToDelate, allCars);
                        menu.DelatedCarInfo(carToDelate);
                        repo.WriteFile(allCars);

                        break;
                    case 6:
                        endProgram = true;

                        break;
                    default:
                        menu.WrongInputInfo();
                        break;
                }

                //if (userChoice == "6")
                //{
                //    endProgram = true;
                //}
                //else if (int.TryParse(userChoice, out _))
                //{
                //    menu.ConsoleClear();
                //    menu.UserChoice(int.Parse(userChoice), repo);
                //}
                //else
                //{
                //    throw new ArgumentException("You need to chose one of the available options!");
                //}
            }
        }
    }
}

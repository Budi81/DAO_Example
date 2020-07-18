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
                        foreach (var car in repo.GetAllCars())
                        {
                            menu.PrintCar(car);
                        }

                        break;
                    case 2:
                        var registrationNumberToFind = menu.RegistrationNumberInput();
                        if (repo.CheckIfCarExists(repo.GetCar(registrationNumberToFind)))
                        {
                            menu.PrintCar(repo.GetCar(menu.RegistrationNumberInput()));
                        }
                        else
                        {
                            menu.NoRecordInDatabaseInfo();
                        }

                        break;
                    case 3:
                        repo.CreateCar(menu.CreateCarInput());

                        break;
                    case 4:
                        var recordToUpdate = repo.GetCar(menu.RegistrationNumberInput());
                        repo.UpdateCar(recordToUpdate, menu.UpdateCarInput(recordToUpdate)); 

                        break;
                    case 5:
                        var carToDelate = repo.GetCar(menu.RegistrationNumberInput());
                        repo.DelateCar(carToDelate);
                        menu.DelatedCarInfo(carToDelate);

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

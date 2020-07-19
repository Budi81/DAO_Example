using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_Example
{
    public class ProgramLogic
    {
        private bool endProgram = false;

        private ICarRepo repo = new CarRepoFromFile();

        private ConsoleControler menu = new ConsoleControler();

        public void ProgramRunning()
        {
            while (!endProgram)
            {
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
                        if (repo.GetCar(registrationNumberToFind) != null)
                        {
                            menu.PrintCar(repo.GetCar(registrationNumberToFind));
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
                        if (recordToUpdate != null)
                        {
                            repo.UpdateCar(recordToUpdate, menu.UpdateCarInput(recordToUpdate));
                        }
                        else
                        {
                            menu.NoRecordInDatabaseInfo();
                        }

                        break;
                    case 5:
                        var carToDelate = repo.GetCar(menu.RegistrationNumberInput());
                        if (carToDelate != null)
                        {
                            repo.DelateCar(carToDelate);
                            menu.DelatedCarInfo(carToDelate);
                        }
                        else
                        {
                            menu.NoRecordInDatabaseInfo();
                        }

                        break;
                    case 6:
                        endProgram = true;

                        break;
                    default:
                        menu.WrongInputInfo();

                        break;
                }
            }
        }
    }
}

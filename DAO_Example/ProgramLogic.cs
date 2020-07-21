using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DAO_Example
{
    public class ProgramLogic
    {
        private bool endProgram = false;

        private ICarRepo repo;

        private ConsoleControler menu = new ConsoleControler();

        public ProgramLogic(ICarRepo repo)
        {
            this.repo = repo;
        }

        private void ShowAllCars()
        {
            try
            {
                foreach (var car in repo.GetAllCars())
                {
                    menu.PrintCar(car);
                }
        }
            catch(Exception ex)
            {
                menu.DisplayError("Wystąpił błąd, aplikacja zostanie zamknięta");
                menu.Sleep(1500);

            }
            finally
            {
                endProgram = true;
            }

}

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
                        ShowAllCars();

                        break;
                    case 2:
                        var result = repo.GetCar(menu.RegistrationNumberInput());
                        if (result.IsFound)
                        {
                            menu.PrintCar(result.FoundEntry);
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
                        if (recordToUpdate.IsFound)
                        {
                            repo.UpdateCar(recordToUpdate.FoundEntry, menu.UpdateCarInput(recordToUpdate.FoundEntry));
                        }
                        else
                        {
                            menu.NoRecordInDatabaseInfo();
                        }

                        break;
                    case 5:
                        var carToDelate = repo.GetCar(menu.RegistrationNumberInput());
                        if (carToDelate.IsFound)
                        {
                            repo.DelateCar(carToDelate.FoundEntry);
                            menu.DelatedCarInfo(carToDelate.FoundEntry);
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

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

        private IControler controler;

        public ProgramLogic(ICarRepo repo, IControler controler)
        {
            this.repo = repo;
            this.controler = controler;
        }

        private void ShowAllCars()
        {
            try
            {
                foreach (var car in repo.GetAllCars())
                {
                    controler.PrintRecord(car);
                }
        }
            catch(Exception ex)
            {
                controler.DisplayError("Wystąpił błąd, aplikacja zostanie zamknięta", 1500);
                endProgram = true;
            }


}

        private void ShowCar()
        {
            try
            {
                var result = repo.GetCar(controler.ChooseRecord());
                if (result.IsFound)
                {
                    controler.PrintRecord(result.FoundEntry);
                }
                else
                {
                    controler.NoRecordInDatabaseInfo();
                }
            }
            catch
            {
                controler.DisplayError("This function is not availble at the moment", 1500);
            }
        }

        private void CreateCar()
        {
            try
            {
                repo.CreateCar(controler.RecordToCreateInformation());
            }
            catch
            {
                controler.DisplayError("This function is not availble at the moment", 1500);
            }
        }

        private void UpdateCar()
        {
            try
            {
            var recordToUpdate = repo.GetCar(controler.ChooseRecord());
                if (recordToUpdate.IsFound)
                {
                    repo.UpdateCar(recordToUpdate.FoundEntry, controler.RecordToUpdateInformation(recordToUpdate.FoundEntry));
                }
                else
                {
                    controler.NoRecordInDatabaseInfo();
                }
            }
            catch
            {
                controler.DisplayError("This function is not availble at the moment", 1500);
            }
        }

        private void DelateCar()
        {
            try
            {
                var carToDelate = repo.GetCar(controler.ChooseRecord());
                if (carToDelate.IsFound)
                {
                    repo.DelateCar(carToDelate.FoundEntry);
                    controler.DelatedRecordInfo(carToDelate.FoundEntry);
                }
                else
                {
                    controler.NoRecordInDatabaseInfo();
                }
            }
            catch
            {
                controler.DisplayError("This function is not availble at the moment", 1500);
            }
        }

        public void ProgramRunning()
        {
            while (!endProgram)
            {
                controler.ShowMenu();

                switch (controler.UserChoice())
                {
                    case 1:
                        ShowAllCars();

                        break;
                    case 2:
                        ShowCar();

                        break;
                    case 3:
                        CreateCar();

                        break;
                    case 4:
                        UpdateCar();

                        break;
                    case 5:
                        DelateCar();

                        break;
                    case 6:
                        endProgram = true;

                        break;
                    default:
                        controler.DisplayError("There is no such option!", 1000);

                        break;
                }
            }
        }
    }
}

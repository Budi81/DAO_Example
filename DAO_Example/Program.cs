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

                if (userChoice == "6")
                {
                    endProgram = true;
                }
                else if (int.TryParse(userChoice, out _))
                {
                    menu.ConsoleClear();
                    menu.UserChoice(int.Parse(userChoice), repo);
                }
                else
                {
                    throw new ArgumentException("You need to chose one of the available options!");
                }
            }
        }
    }
}

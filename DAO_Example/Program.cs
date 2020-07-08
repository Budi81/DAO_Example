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
                var userChoice = int.Parse(Console.ReadLine());

                menu.ConsoleClear();
                var allCars = repo.GetAllCars();

                menu.UserChoice(userChoice, allCars, repo, endProgram);
            }
        }
    }
}

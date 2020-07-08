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

                MainMenu menu = new MainMenu();

                menu.ShowMenu();
                var userChoice = int.Parse(Console.ReadLine());

                Console.Clear();
                var allCars = repo.GetAllCars();

                menu.UserChoice(userChoice, allCars, repo, endProgram);
            }
        }
    }
}

using System;
using System.IO;

namespace DAO_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramLogic programRunning = new ProgramLogic(new CarRepoFromFile());

            programRunning.ProgramRunning();
        }
    }
}

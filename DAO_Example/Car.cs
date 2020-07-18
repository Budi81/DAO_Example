using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace DAO_Example
{
    public class Car
    {
        private string registrationNumber;
        private string make;
        private string model;

        private int yearOfProduction;

        public string RegistrationNumber { get => registrationNumber; private set => registrationNumber = value; }
        public string Make { get => make; private set => make = value; }
        public string Model { get => model; private set => model = value; }

        public int YearOfProduction { get => yearOfProduction; private set => yearOfProduction = value; }

        public Car(string registrationNumber, string make, string model, int yearOfProduction)
        {
            RegistrationNumber = registrationNumber;
            Make = make;
            Model = model;
            YearOfProduction = yearOfProduction;
        }

        public void ModifyRegistrationNumber(string registrationNumber)
        {
            this.RegistrationNumber = registrationNumber;
        }

        public void ModifyMake(string make)
        {
            this.Make = make;
        }

        public void ModifyModel(string model)
        {
            this.Model = model;
        }

        public void ModifyYearOfProduction(int yearOfProduction)
        {
            this.YearOfProduction = yearOfProduction;
        }
    }
}

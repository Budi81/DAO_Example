using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace DAO_Example
{

    /// Value object
    public class Car
    {
        private string registrationNumber;
        private string name;
        private string model;

        private int yearOfProduction;


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                this.model = value;
            }
        }
        public string RegistrationNumber
        {
            get
            {
                return registrationNumber;
            }
            set
            {
                this.registrationNumber = value;
            }
        }

        public int YearOfProduction 
        {
            get
            {
                return yearOfProduction;
             }
            set
            {
                this.yearOfProduction = value;
            }
        }


        public Car()
        {
          
        }


    }
}

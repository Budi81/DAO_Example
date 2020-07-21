using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_Example
{
    public class GetCarResult
    {
        private Car car;

        private GetCarResult(bool isFound, Car foundEntry)
        {
            IsFound = isFound;
            car = foundEntry;
        }

        public GetCarResult(Car foundEntry)
            :this(true, foundEntry)
        {
            
        }

        public GetCarResult()
            :this(false, null)
        {

        }

        public bool IsFound { get; private set; }

        public Car FoundEntry { 
            get
            {
                if (this.IsFound == true)
                {
                    return this.car;
                }
                else
                {
                    throw new InvalidOperationException("Car not found!");
                }
            }
            private set
            {
                this.car = value;               
            } 
        }
        
    }
}

using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Contracts
{
    public class Pilot : IPilot
    {
        private string fullName;
        private int numberOfWins;
        private IFormulaOneCar car;
        private bool canRace = false;

        public Pilot(string fullName)
        {
            FullName = fullName;
            
            
            
        }

        public string FullName
        {
            get
            {
                return this.fullName;

            }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPilot, fullName));
                }
                this.fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get
            {
                return this.car;
            }
            set
            {
                if(value == null)
                {
                    throw new NullReferenceException(String.Format(ExceptionMessages.InvalidCarForPilot));
                }
                this.car = value;
                    
                

                
            }
        }

        public int NumberOfWins { get { return this.numberOfWins; } }

        public bool CanRace { get { return this.canRace; } }

        public void AddCar(IFormulaOneCar car)
        {
            var pilot = new Pilot(FullName);
            Car = car;
            pilot.Car = car;
            canRace = true;
            
        }

        public void WinRace()
        {
            int newNumberOfWins = NumberOfWins + 1;
            numberOfWins = newNumberOfWins;
        }
    }
}

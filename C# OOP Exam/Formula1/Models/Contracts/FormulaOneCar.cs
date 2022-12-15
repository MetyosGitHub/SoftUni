using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Contracts
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsepower;
        private double engineDisplacement;

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            Model = model;
            Horsepower = horsepower;
            EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get
            {
                return this.model;

            }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length<3)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1CarModel, model));
                }
                this.model = value;
            }
        }

        public int Horsepower
        {
            get
            {
                return this.horsepower;

            }
            private set
            {
                if (value<900||value>1050)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1HorsePower, horsepower));
                }
                this.horsepower = value;
            }
        }

        public double EngineDisplacement
        {
            get
            {
                return this.engineDisplacement;

            }
            private set
            {
                if (value < 1.6 || value > 2.0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1EngineDisplacement, engineDisplacement));
                }
                this.engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            return engineDisplacement / horsepower * laps;
        }
    }
}

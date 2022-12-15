using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Utilities;
using System.Linq;

namespace Formula1.Core.Contracts
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;
        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = pilotRepository.FindByName(pilotName);
            if(pilot==null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            else
            {
                var car = carRepository.FindByName(carModel);
                if (car == null)
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
                }
                else
                {
                    pilot.AddCar(car);
                    return String.Format(OutputMessages.SuccessfullyPilotToCar,pilot.FullName,car.GetType().Name ,carModel);
                }
            }
            
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            else
            {
                var pilot = pilotRepository.FindByName(pilotFullName);
                if (pilot == null||!pilot.CanRace||race.Pilots.Contains(pilot))
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
                }
                else
                {
                    race.AddPilot(pilot);
                    return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
                }
            }
            
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            
            if(type=="Ferrari")
            {
                var car = new Ferrari(model, horsepower, engineDisplacement);
                bool hasIt = false;
                foreach(var newCar in carRepository.Models)
                {
                    if (newCar.Model == model)
                    {
                        hasIt = true;
                    }
                }
                if (hasIt)
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
                }
                else
                {
                    return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
                }
            }
            else if(type =="Williams")
            {
                var car = new Williams(model, horsepower, engineDisplacement);
                bool hasIt = false;
                foreach (var newCar in carRepository.Models)
                {
                    if (newCar.Model == model)
                    {
                        hasIt = true;
                    }
                    else
                    {
                        carRepository.Add(car);
                        return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
                    }
                }
                if(hasIt)
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
                }
                else
                {
                    carRepository.Add(car);
                    return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
                }
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar,type));
            }
            
        }

        public string CreatePilot(string fullName)
        {
            var pilot = new Pilot(fullName);
            bool hasIt = false;
            foreach(var newPilot in pilotRepository.Models)
            {
                if(newPilot.FullName==fullName)
                {
                    hasIt = true;
                }
                
            }
            if (hasIt)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            else
            {
                pilotRepository.Add(pilot);
                return $"Pilot {fullName} is created.";
            }


           
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            var race = new Race(raceName, numberOfLaps);
            bool hasIt = false;
            foreach (var newRace in raceRepository.Models)
            {
                if (newRace.RaceName == raceName)
                {
                    hasIt = true;
                }

            }
            if (hasIt)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            else
            {
                raceRepository.Add(race);
                return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
            }


            
        }

        public string PilotReport()

        {
            pilotRepository.Models.OrderByDescending(p => p.NumberOfWins);
            StringBuilder result = new StringBuilder();
            foreach(var pilot in pilotRepository.Models)
            {
                result.AppendLine($"{pilot.FullName} has {pilot.NumberOfWins}");  
            }
            string toReturn = result.ToString();
            return toReturn;
        }

        public string RaceReport()
        {


            foreach(var race in raceRepository.Models)
            {
                Console.WriteLine(race.RaceInfo()); 
            }
            throw new NotImplementedException();
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));

            }
            else if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            else if (race.TookPlace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }
            else
            {
                
                StringBuilder result = new StringBuilder();
                pilotRepository.Models.OrderByDescending(s => s.Car.RaceScoreCalculator(race.NumberOfLaps));

               
                var firstPilot = pilotRepository.Models.ElementAt(0);
                var secondPilot = pilotRepository.Models.ElementAt(1);
                var thirdPilot = pilotRepository.Models.ElementAt(2);
                result.AppendLine($"Pilot {firstPilot} wins the {race.RaceName} race.");
                result.AppendLine($"Pilot {secondPilot} is second in the {race.RaceName} race.");

                result.AppendLine($"Pilot {thirdPilot} is third in the {race.RaceName} race.");
                string toReturn = result.ToString();
                return toReturn;


            }
            
        }
    }
}

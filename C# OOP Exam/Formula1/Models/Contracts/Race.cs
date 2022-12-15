using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Contracts
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            TookPlace = false;
            Pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get
            {
                return this.raceName;

            }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidRaceName, raceName));
                }
                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get
            {
                return this.numberOfLaps;

            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers, numberOfLaps));
                }
                this.numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots { get;  }

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            //"The { race name } race has:
            // Participants: { number of participants }
            //Number of laps: { number of laps }
            //Took place: { Yes / No }
            //"
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The {RaceName} race has:");
            result.AppendLine($"Participants: {Pilots.Count}");
            result.AppendLine($"Number of laps: {NumberOfLaps}");
            if(TookPlace)
            {
                result.AppendLine($"Took place: Yes");
            }
            else
            {
                result.AppendLine($"Took place: No");
            }
            string final = result.ToString();
            return final;
        }
    }
}

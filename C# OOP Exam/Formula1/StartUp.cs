namespace Formula1
{
    using Formula1.Core;
    using Formula1.Core.Contracts;
    using Formula1.Models.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
            //IFormulaOneCar newcar = new Ferrari("ABasddsa", 1000, 1.8);
            //var pilot = new Pilot("Metyo");
            //pilot.AddCar(newcar);
            //Race race = new Race("GrandPrix", 6);
            //race.AddPilot(pilot);
            //System.Console.WriteLine(race.RaceInfo());
            //Controller controller = new Controller();
            //System.Console.WriteLine(controller.CreatePilot("Metyonceto"));

            //System.Console.WriteLine(controller.CreatePilot("Metyonceto"));
        }
    }
    }


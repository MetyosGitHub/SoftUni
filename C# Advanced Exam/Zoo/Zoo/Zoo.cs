using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public List<Animal> Animals { get; set; } = new List<Animal>();
        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            if(Animals.Count==Capacity)
            {
                return $"The zoo is full.";
            }
            if(animal.Species==""||animal.Species==null)
            {
                return "Invalid animal species.";
            }  
            if(animal.Diet!= "herbivore" && animal.Diet!="carnivore")
            {
                return "Invalid animal diet.";
            }
            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int count = Animals.Count;
            List<Animal> nqkuvList = new List<Animal>();

            foreach(var animal in Animals)
            {
                if (animal.Species == species) 
                {
                    nqkuvList.Add(animal);
                }
            }
            foreach(var animal in nqkuvList)
            {
                if (Animals.Contains(animal))
                {
                    Animals.Remove(animal);
                }
            }
            count -= Animals.Count;
            return count;
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> listToReturn = new List<Animal>();
            foreach(var animal in Animals)
            {
                if(animal.Diet==diet)
                {
                    listToReturn.Add(animal);
                }
            }
            return listToReturn;
        }
        public Animal GetAnimalByWeight(double weight)
        {
            Animal animal = Animals.FirstOrDefault(x => x.Weight == weight);
            return animal;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            List<Animal> needCount = new List<Animal>();
            foreach(var animal in Animals)
            {
                if(animal.Length>=minimumLength&&animal.Length<=maximumLength)
                {
                    needCount.Add(animal);
                }
            }
            return $"There are {needCount.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}

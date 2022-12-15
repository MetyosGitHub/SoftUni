using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MealPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();
            Queue<string> meals = new Queue<string>(list);
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Stack<int> calories = new Stack<int>(numbers);
            int count = meals.Count;
            while (meals.Count > 0 && calories.Count > 0)
            {


                int dailyCalories = calories.Pop();
                string meal = meals.Dequeue();
                if (meal == "salad")
                {
                    if (dailyCalories > 350)
                    {
                        dailyCalories -= 350;
                        calories.Push(dailyCalories);
                    }
                    else
                    {
                        int difference = 350 - dailyCalories;
                        if (calories.Count > 0)
                        {
                            dailyCalories = calories.Pop();
                            dailyCalories -= difference;
                            calories.Push(dailyCalories);
                        }
                        else
                        {

                        }

                    }
                }
                else if (meal == "pasta")
                {
                    if (dailyCalories > 680)
                    {
                        dailyCalories -= 680;
                        calories.Push(dailyCalories);
                    }
                    else
                    {
                        int difference = 680 - dailyCalories;
                        if (calories.Count > 0)
                        {
                            dailyCalories = calories.Pop();
                            dailyCalories -= difference;
                            calories.Push(dailyCalories);
                        }
                        else
                        {

                        }
                    }
                }
                else if (meal == "steak")
                {
                    if (dailyCalories > 790)
                    {
                        dailyCalories -= 790;
                        calories.Push(dailyCalories);
                    }
                    else
                    {
                        int difference = 790 - dailyCalories;
                        if (calories.Count > 1)
                        {
                            dailyCalories = calories.Pop();
                            dailyCalories -= difference;
                            calories.Push(dailyCalories);
                        }
                        else
                        {

                        }

                    }

                }
                else if (meal == "soup")
                {
                    if (dailyCalories > 490)
                    {
                        dailyCalories -= 490;
                        calories.Push(dailyCalories);
                    }
                    else
                    {
                        int difference = 490 - dailyCalories;
                        if (calories.Count > 0)
                        {
                            dailyCalories = calories.Pop();
                            dailyCalories -= difference;
                            calories.Push(dailyCalories);
                        }
                        else
                        {

                        }
                    }
                }
            }
            if (calories.Count == 0)
            {
                StringBuilder result = new StringBuilder();
                result.AppendLine($"John ate enough, he had {count - meals.Count} meals.");
                result.Append("Meals left: ");
                result.Append(String.Join(", ", meals));
                result.Append(".");
                string toReturn = result.ToString();
                Console.WriteLine(toReturn);

            }
            else
            {
                StringBuilder result = new StringBuilder();
                result.AppendLine($"John had {count - meals.Count} meals.");
                result.Append($"For the next few days, he can eat ");
                result.Append(String.Join(", ", calories));
                result.Append(" calories.");
                string toReturn = result.ToString();
                Console.WriteLine(toReturn);
            }

        }
    }
}

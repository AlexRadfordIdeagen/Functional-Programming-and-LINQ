using System.Collections.Generic;
using System.Linq;
using System;
namespace Functional_Programming_and_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Program program = new Program();

            //Check for the poisonedApples
            var poisonedApples = program.PickApples()
                .Take(10000)
                .Where(a => a.Poisoned == true)
                .Count()
                .ToString();
            Console.WriteLine(poisonedApples);

            //Check for the second most poisoned apple
            var secondMostPoisonedApple = program.PickApples()
                .Take(10000)
                .Where(a => a.Poisoned == true)
                .GroupBy(a => a.Colour)
                .OrderBy(grouping => grouping.Count())
                .ElementAt(1)
                .Key
                .ToString();
            
            Console.WriteLine(secondMostPoisonedApple);


            Console.ReadLine();
        }


        private IEnumerable<Apple> PickApples()
        {
            int colourIndex = 1;
            int poisonIndex = 7;

            while (true)
            {
                yield return new Apple
                {
                    Colour = GetColour(colourIndex),
                    Poisoned = poisonIndex % 41 == 0
                };

                colourIndex += 5;
                poisonIndex += 37;
            }
        }

        private string GetColour(int colourIndex)
        {
            if (colourIndex % 13 == 0 || colourIndex % 29 == 0)
            {
                return "Green";
            }

            if (colourIndex % 11 == 0 || colourIndex % 19 == 0)
            {
                return "Yellow";
            }

            return "Red";
        }

        class Apple
        {
            public string Colour { get; set; }
            public bool Poisoned { get; set; }

            public override string ToString()
            {
                return $"{Colour} apple{(Poisoned ? " (poisoned!)" : "")}";
            }
        }
    }
}
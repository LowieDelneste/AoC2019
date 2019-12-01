using System;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt").Select(x => double.Parse(x));

            // Part 1
            var sumFuelRequirements = input.Sum(x => CalculateFuel(x));
            Console.WriteLine($"Fuel requirements: {sumFuelRequirements}");

            // Part 2
            var sumFuelRequirementsWithMass = input.Sum(x => CalculateFuel(x, 0));
            Console.WriteLine($"Fuel requirements with mass: {sumFuelRequirementsWithMass}");
        }

        private static double CalculateFuel(double mass) => Math.Floor(mass / 3) - 2;

        private static double CalculateFuel(double mass, double totalFuel)
        {
            var currentMass = CalculateFuel(mass);
            if(currentMass <= 0)
            {
                return totalFuel;
            }
            return CalculateFuel(currentMass, totalFuel + currentMass) ;
        }
    }
}

using System;
using System.IO;
using System.Linq;

namespace day_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var squareFeet = 0;
            foreach (var line in File.ReadAllLines("input.txt"))
            {
                var dimensions = line.Split("x").Select(x => int.Parse(x)).ToArray();
                var surfaces = new int[]
                {
                    dimensions[0] * dimensions[1],
                    dimensions[1] * dimensions[2],
                    dimensions[0] * dimensions[2]
                };

                squareFeet += 2 * surfaces.Sum() + surfaces.Min();
            }

            Console.WriteLine(squareFeet);
        }
    }
}
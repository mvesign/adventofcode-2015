using System;
using System.IO;
using System.Linq;

namespace day_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = 0;
            foreach (var line in File.ReadAllLines("input.txt"))
            {
                var dimensions = line.Split("x").Select(x => int.Parse(x)).ToArray();
                length += 2 * dimensions.Where(x => x != dimensions.Max()).Sum();
                length += dimensions[0] * dimensions[1] * dimensions[2];
            }

            Console.WriteLine(length);
        }
    }
}

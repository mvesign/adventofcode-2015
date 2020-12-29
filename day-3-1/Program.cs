using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = 0;
            var y = 0;
            var houses = new List<(int, int)>();
            foreach(var direction in File.ReadAllText("input.txt"))
            {
                var house = direction switch
                {
                    '^' => (x, y++),
                    '>' => (x++, y),
                    'v' => (x, y--),
                    '<' => (x--, y),
                    _ => (x, y)
                };

                if (!houses.Contains(house))
                    houses.Add(house);
            }

            Console.WriteLine(houses.Count());
        }
    }
}
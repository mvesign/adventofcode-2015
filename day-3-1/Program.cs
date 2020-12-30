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
            (int x, int y) NextHouse(int x, int y, char direction) =>
                direction switch
                {
                    '^' => (x, y+1),
                    '>' => (x+1, y),
                    'v' => (x, y-1),
                    '<' => (x-1, y),
                    _ => (x, y)
                };

            var current = NextHouse(0, 0, ' ');
            var houses = new List<(int, int)>();
            foreach(var direction in File.ReadAllText("input.txt"))
            {
                if (!houses.Contains(current))
                    houses.Add(current);

                current = NextHouse(current.x, current.y, direction);
            }

            Console.WriteLine(houses.Count());
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var santa = NextHouse(0, 0, ' ');
            var roboSanta = NextHouse(0, 0, ' ');
            var santasTurn = false;
            var houses = new List<(int, int)>();
            
            foreach(var direction in File.ReadAllText("input.txt"))
                if (santasTurn ^= true)
                    santa = ProcessDirection(santa, direction);
                else
                    roboSanta = ProcessDirection(roboSanta, direction);

            Console.WriteLine(houses.Count);

            (int x, int y) NextHouse(int x, int y, char direction) =>
                direction switch
                {
                    '^' => (x, y+1),
                    '>' => (x+1, y),
                    'v' => (x, y-1),
                    '<' => (x-1, y),
                    _ => (x, y)
                };
            
            (int x, int y) ProcessDirection((int x, int y) current, char direction)
            {
                if (!houses.Contains(current))
                    houses.Add(current);

                return NextHouse(current.x, current.y, direction);
            }
        }
    }
}
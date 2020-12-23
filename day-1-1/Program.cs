using System;
using System.IO;

namespace day_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var floor = 0;
            foreach(var parentheses in File.ReadAllText("input.txt"))
                floor += parentheses == '(' ? 1 : -1;

            Console.WriteLine(floor);
        }
    }
}
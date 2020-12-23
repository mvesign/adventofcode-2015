using System;
using System.IO;

namespace day_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var floor = 0;
            var position = 0;
            foreach(var parentheses in File.ReadAllText("input.txt"))
            {
                floor += parentheses == '(' ? 1 : -1;
                position++;
                if (floor == -1)
                    break;
            }

            Console.WriteLine(position);
        }
    }
}

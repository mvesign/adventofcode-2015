using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var vowels = "a e i o u".Split(" ").ToArray();
            var disallowed = new [] 
            {
                "ab", "cd", "pq", "xy"
            };

            Console.WriteLine(vowels);

            var niceStrings = new List<string>();
            foreach(var line in File.ReadAllLines("input.txt"))
            {
                if (disallowed.Any(line.Contains))
                    continue;

                if (vowels.Where(line.Contains).Count() < 3)
                    continue;
                
                //TODO It contains at least one letter that appears twice in a row.

                niceStrings.Add(line);
            }

            Console.WriteLine(niceStrings.Count());
        }
    }
}
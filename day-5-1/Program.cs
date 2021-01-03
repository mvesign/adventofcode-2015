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
            const string vowels = "aeiou";
            var disallowed = new [] { "ab", "cd", "pq", "xy" };

            var niceStrings = new List<string>();
            foreach(var line in File.ReadAllLines("input.txt"))
            {
                if (disallowed.Any(line.Contains))
                    continue;

                if (line.Count(c => vowels.Contains(c)) < 3)
                    continue;
                
                var prev = 0;
                for(var cur = 1; cur < line.Length; cur++, prev++)
                    if (line[cur].Equals(line[prev]))
                    {
                        niceStrings.Add(line);
                        break;
                    }
            }

            Console.WriteLine(niceStrings.Count());
        }
    }
}
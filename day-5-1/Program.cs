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

            var numberOfNice = File.ReadAllLines("input.txt")
                .Count(line =>
                    !disallowed.Any(line.Contains)
                    && line.Count(character => vowels.Contains(character)) >= 3
                    && Enumerable.Range(0, line.Length - 1).Any(character => line[character] == line[character + 1])
                );

            Console.WriteLine(numberOfNice);
        }
    }
}
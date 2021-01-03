using System;
using System.IO;
using System.Linq;

namespace day_5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfNice = File.ReadAllLines("input.txt")
                .Count(line =>
                    Enumerable.Range(0, line.Length - 1).Any(c => line.IndexOf(line.Substring(c, 2), c + 2) >= 0)
                    && Enumerable.Range(0, line.Length - 2).Any(c => line[c] == line[c + 2])
                );
            
            Console.WriteLine(numberOfNice);
        }
    }
}

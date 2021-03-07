using System;
using System.IO;
using System.Linq;

namespace day_8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = File.ReadAllLines("input.txt")
                .Select(x =>
                    new
                    {
                        Original = x,
                        Escaped = "\"" + // Add the beginning double qoute character
                            x.Replace("\\", "\\\\") // Representing the single backslash
                                .Replace("\"", "\\\"") // Representing the lone double-quote character
                            + "\"" // Add the ending double qoute character
                    }
                )
                .Sum(x => x.Escaped.Length - x.Original.Length);

            Console.WriteLine(count);
        }
    }
}

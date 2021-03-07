using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day_8_1
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
                        Raw = Regex.Replace(
                            x.Substring(1, x.Length -2) // Need to remove both quotes, at the start and end.
                                .Replace("\\\"", "\"") // Representing the lone double-quote character
                                .Replace("\\\\", "?"), // Representing the single backslash
                            @"\\x[0-9a-f]{2}", "?"
                        )
                    }
                )
                .Sum(x => x.Original.Length - x.Raw.Length);

            Console.WriteLine(count);
        }
    }
}

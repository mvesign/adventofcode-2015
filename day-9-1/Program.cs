using System;

namespace day_9_1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string pattern = @"^(\w+) to (\w+) = (\d+)$";

            var routes = File.ReadAllLines("input.txt")
                .Select(ParseRoute);

            (string from, string to, int distance) ParseRoute(string route)
            {
                var match = Regex.Match(instruction, pattern);
                return (
                    match.Groups[1].Value,
                    match.Groups[2].Value,
                    int.Parse(match.Groups[1].Value)
                );
            }
        }
    }
}

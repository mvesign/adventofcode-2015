using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day_9_1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string pattern = @"^(\w+) to (\w+) = (\d+)$";

            var routes = File.ReadAllLines("input.txt").Select(Parse);
            
            var permutations = Permute(
                routes.SelectMany(route => route.Item1).Distinct()
            );
            
            var distance = permutations.Select(p => GetDistance(p, routes)).Min();

            Console.WriteLine(distance);

            Tuple<string[], int> Parse(string route)
            {
                var match = Regex.Match(route, pattern);
                return Tuple.Create(
                    new []
                    {
                        match.Groups[1].Value,
                        match.Groups[2].Value
                    },
                    int.Parse(match.Groups[3].Value)
                );
            }

            IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> sequence)
            {
                var list = sequence.ToList();
                if (!list.Any())
                    yield return Enumerable.Empty<T>();

                var startingIndex = 0;

                foreach (var element in sequence)
                {
                    var index = startingIndex;
                    var remaining = sequence.Where((e, i) => i != index);

                    foreach (var remainder in Permute(remaining))
                        yield return remainder.Prepend(element);

                    startingIndex++;
                }
            }

            int GetDistance(IEnumerable<string> cities, IEnumerable<Tuple<string[], int>> routes)
            {
                var array = cities.ToArray();

                var distance = 0;
                for(var i = 0; i < array.Length - 1; i++)
                {
                    var matches = routes.Where(r => r.Item1[0] == array[i] && r.Item1[1] == array[i+1])
                        .Select(r => r.Item2)
                        .ToArray();
                    if (matches.Length > 0)
                        distance += matches.First();
                }
                return distance;
            }
        }
    }
}

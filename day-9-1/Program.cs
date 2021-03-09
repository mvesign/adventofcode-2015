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

            var routes = File.ReadAllLines("input.txt").Select(ParseRoute);
            var cities = GetCities(routes).Distinct().ToArray();
            var permutations = GetPermutations(cities, 0, cities.Length - 1);

            var distance = permutations.Select(p => GetDistance(p, routes)).Min();

            Console.WriteLine(distance);

            Tuple<string, string, int> ParseRoute(string route)
            {
                var match = Regex.Match(route, pattern);
                return Tuple.Create(
                    match.Groups[1].Value,
                    match.Groups[2].Value,
                    int.Parse(match.Groups[3].Value)
                );
            }

            IEnumerable<string> GetCities(IEnumerable<Tuple<string, string, int>> routes)
            {
                foreach (var (from, to, distance) in routes)
                {
                    yield return from;
                    yield return to;
                }
            }

            List<string[]> GetPermutations(string[] cities, int start, int end)
            {
                var result = new List<string[]>();
                if (start == end)
                    result.Add(cities);
                else
                    for(var i = start; i <= end; i++)
                    {
                        Swap(ref cities[start], ref cities[i]);
                        result = result.Union(
                                GetPermutations(cities, start + 1, end)
                            )
                            .ToList();
                        Swap(ref cities[start], ref cities[i]);
                    }

                return result;
            }

            void Swap(ref string a, ref string b)
            {
                var temp = a;
                a = b;
                b = temp;
            }

            int GetDistance(string[] cities, IEnumerable<Tuple<string, string, int>> routes)
            {
                var distance = 0;
                for(var i = 0; i < cities.Length - 1; i++)
                    distance += routes.Where(r => r.Item1 == cities[i] && r.Item2 == cities[i+1])
                        .Select(r => r.Item3)
                        .Single();

                return distance;
            }
        }
    }
}

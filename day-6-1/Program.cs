using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day_6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string pattern = @"^(.+) (\d+),(\d+) through (\d+),(\d+)$";

            var grid = new bool[1000 * 1000];
            
            File.ReadAllLines("input.txt")
                .Select(ParseInstruction)
                .ToList()
                .ForEach(HandleInstruction);

            Console.WriteLine(grid.Count(x => x));
            
            int ParseType(string type) =>
                type switch
                {
                    "turn off" => 0,
                    "turn on" => 1,
                    "toggle" => 2,
                    _ => throw new Exception("ERROR!") // This will never happen.
                };
            
            (int type, int fromX, int fromY, int toX, int toY) ParseInstruction(string instruction)
            {
                var match = Regex.Match(instruction, pattern);
                return (
                    ParseType(match.Groups[1].Value),
                    int.Parse(match.Groups[2].Value),
                    int.Parse(match.Groups[3].Value),
                    int.Parse(match.Groups[4].Value),
                    int.Parse(match.Groups[5].Value)
                );
            }

            void HandleInstruction((int type, int fromX, int fromY, int toX, int toY) instruction)
            {
                for (var row = instruction.fromX; row <= instruction.toX; row++)
                    for (var col = instruction.fromY; col <= instruction.toY; col++)
                        grid[1000 * row + col] = instruction.type == 0
                            ? false
                            : instruction.type == 1
                                ? true
                                : !grid[1000 * row + col];
            }
        }
    }
}
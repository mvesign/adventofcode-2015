﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_7_1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var signal = File.ReadAllLines("input.txt")
                .Select(x => x.Split(' '))
                .ToDictionary(x => x.Last())
                .GetSignal("a");
            
            Console.WriteLine(signal);
        }

        static int GetSignal(this Dictionary<string, string[]> instructions, string input)
        {
            int Evaluate(string x) =>
                Char.IsLetter(x[0]) ? instructions.GetSignal(x) : int.Parse(x);

            var instruction = instructions[input];
            var signal = instruction[1] switch
            {
                "->" => Evaluate(instruction[0]),
                "AND" => Evaluate(instruction[0]) & Evaluate(instruction[2]),
                "OR" => Evaluate(instruction[0]) | Evaluate(instruction[2]),
                "LSHIFT" => Evaluate(instruction[0]) << Evaluate(instruction[2]),
                "RSHIFT" => Evaluate(instruction[0]) >> Evaluate(instruction[2]),
                _ => ~Evaluate(instruction[1]) // Otherwise it is the NOT operator.
            };

            instructions[input] = new [] { signal.ToString(), "->", input };

            return signal;
        }
    }
}
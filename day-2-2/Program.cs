using System;
using System.IO;
using System.Linq;

namespace day_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                File.ReadAllLines("input.txt")
                    .Select(s => s.Split('x'))
                    .Select(x => x.Select(int.Parse))
                    .Select(w => w.OrderBy(x => x).ToArray())
                    .Select(w => 2 * w[0] + 2 * w[1] + w[0] * w[1] * w[2])
                    .Sum()
            );
        }
    }
}

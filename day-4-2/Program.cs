using System;
using System.Security.Cryptography;
using System.Text;

namespace day_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var secret = "iwrupvqb";

            using var md5 = MD5.Create();

            for(var count = 0; ; count++)
                if (
                    BitConverter.ToString(
                        md5.ComputeHash(
                            Encoding.UTF8.GetBytes($"{secret}{count}")
                        )
                    )
                    .Replace("-","")
                    .StartsWith(new string('0', 6))
                )
                {
                    Console.WriteLine(count);
                    break;
                }
        }
    }
}

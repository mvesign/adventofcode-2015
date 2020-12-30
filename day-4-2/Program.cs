using System;
using System.Security.Cryptography;
using System.Text;

namespace day_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string secret = "iwrupvqb";
            var startingValue = new string('0', 6);

            using var md5 = MD5.Create();

            for(var count = 0; ; count++)
                if (
                    BitConverter.ToString(
                        md5.ComputeHash(
                            Encoding.UTF8.GetBytes($"{secret}{count}")
                        )
                    )
                    .Replace("-","")
                    .StartsWith(startingValue)
                )
                {
                    Console.WriteLine(count);
                    break;
                }
        }
    }
}

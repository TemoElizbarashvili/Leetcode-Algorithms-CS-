using System.Diagnostics.CodeAnalysis;
using System.Formats.Asn1;
using static leetcode.Easy;

namespace leetcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string k = "kakao";
            Console.WriteLine(char.ToUpper(k[0]) + k.Substring(1));
        }
    }
}
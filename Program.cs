using System.Diagnostics.CodeAnalysis;


namespace leetcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr =
            {
               1,2,3,3

            };
            int[] arr1 =
            {
               1,1,2,2

            };
            Console.WriteLine(Easy.FindDifference(arr, arr1));
        }
    }
}
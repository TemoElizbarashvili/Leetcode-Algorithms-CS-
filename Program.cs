using System.Diagnostics.CodeAnalysis;


namespace leetcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr =
            {
                0,1,2,2,3,0,4,2
            };

            Console.WriteLine(Easy.RemoveElement(arr, 2));
        }
    }
}
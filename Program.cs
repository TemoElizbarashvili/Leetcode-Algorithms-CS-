using System.Diagnostics.CodeAnalysis;


namespace leetcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] arr =
            {
                new[] { 0,1,2} ,
                new[]{ 1,2,4 },
                new[]{2,0,8 },
                new[]{ 1,0,16 },

            };
            int[][] arr1 =
            {
                new[] { 0, 1, 2 } ,
                new[]{ 0,2,5 },
            };
            Console.WriteLine(Hard.DistanceLimitedPathsExist(3,arr,arr1));
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using static leetcode.Easy;

namespace leetcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode K = new TreeNode(1);
            TreeNode d = K;
            K.left = new TreeNode(2);
            K.right = new TreeNode(3);
            K.right.left = new TreeNode(6);
            K.left.right = new TreeNode(5);
            K.left.left = new TreeNode(4);
            K.left.left.left = new TreeNode(8);
            Console.WriteLine(Easy.IsBalanced(d));

        }
    }
}
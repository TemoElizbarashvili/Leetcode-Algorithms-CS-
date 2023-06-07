using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    internal static class Easy
    {
        public static int AddDigits(int num)
        {
            while (num / 10 != 0)
            {
                num = num.ToString().Select(x => Convert.ToInt32(x.ToString())).ToList().Sum();
            }
            return num;

        }

        public static int RomanToInt(string s)
        {
            var romanianNum = s.ToCharArray();
            var result = 0;
            for (int i = 0; i < romanianNum.Length; i++)
            {
                switch (romanianNum[i])
                {
                    case 'M':
                        {
                            result += 1000;
                            break;
                        }
                    case 'D':
                        {
                            result += 500;
                            break;
                        }
                    case 'C':
                        {
                            if (i != romanianNum.Length - 1 && romanianNum[i + 1] == 'D')
                            {
                                result += 400;
                                i++;
                            }
                            else
                            {
                                if (i != romanianNum.Length - 1 && romanianNum[i + 1] == 'M')
                                {
                                    result += 900;
                                    i++;
                                }
                                else
                                {
                                    result += 100;
                                }
                            }
                            break;
                        }
                    case 'L':
                        {
                            result += 50;

                            break;

                        }
                    case 'X':
                        {
                            if (i != romanianNum.Length - 1 && romanianNum[i + 1] == 'L')
                            {
                                result += 40;
                                i++;
                            }
                            else
                            {
                                if (i != romanianNum.Length - 1 && romanianNum[i + 1] == 'C')
                                {
                                    result += 90;
                                    i++;
                                }
                                else
                                {
                                    result += 10;
                                }
                            }
                            break;
                        }
                    case 'V':
                        {
                            result += 5;
                            break;
                        }
                    case 'I':
                        {
                            if (i != romanianNum.Length - 1 && romanianNum[i + 1] == 'V')
                            {
                                result += 4;
                                i++;
                            }
                            else
                            {
                                if (i != romanianNum.Length - 1 && romanianNum[i + 1] == 'X')
                                {
                                    result += 9;
                                    i++;
                                }
                                else
                                {
                                    result++;
                                }
                            }

                            break;
                        }
                    default:
                        break;





                }
            }
            return result;


        }

        public static int LastStoneWeight(int[] stones)
        {
            var stonesList = stones.ToList();
            int max1 = 0, max2 = 0;
            while (stonesList.Count() > 1)
            {

                foreach (var item in stonesList)
                {
                    if (item >= max1)
                    {
                        max2 = max1;
                        max1 = item;
                    }
                    else if (item >= max2)
                    {
                        max2 = item;
                    }
                }
                if (max1 == max2)
                {
                    stonesList.Remove(max1);
                    stonesList.Remove(max2);
                }
                else
                {
                    if (max1 > max2)
                    {
                        int index = stonesList.FindIndex(x => x == max1);
                        if (index != -1)
                        {

                            stonesList[index] = max1 - max2;
                            stonesList.Remove(max2);
                        }
                    }
                    else
                    {
                        int index = stonesList.FindIndex(x => x == max2);
                        if (index != -1)
                        {

                            stonesList[index] = max2 - max1;
                            stonesList.Remove(max1);
                        }
                    }
                }
                max1 = 0; max2 = 0;
            }
            if (stonesList.Count() == 1)
            {
                return stonesList[0];
            }
            else
                return 0;
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            var result = "";
            var min = strs.Min().Length;
            for (int j = 0; j < min; j++)
            {

                for (int i = 0; i < strs.Length; i++)
                {
                    if (strs[i][j] != strs[0][j])
                    {
                        return result;
                    }
                }
                result += strs[0][j];
            }
            return result;

        }

        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            List<int> list = new();
            var result = new ListNode();
            var final = result;
            while (list1 != null)
            {
                list.Add(list1.val);
                list1 = list1.next;
            }
            while (list2 != null)
            {
                list.Add(list2.val);
                list2 = list2.next;
            }
            list.Sort();
            if (list.Count > 0)
            {

                result.val = list[0];
                for (int i = 1; i < list.Count; i++)
                {
                    result.next = new ListNode(list[i]);
                    result = result.next;
                }
                return final;
            }
            else return null;
        }

        public static bool IsValid(string s)
        {

            var k = new Stack<char>();

            foreach (char c in s)
            {

                if (c == '(') { k.Push(')'); continue; }

                if (c == '{') { k.Push('}'); continue; }

                if (c == '[') { k.Push(']'); continue; }

                if (k.Count == 0 || c != k.Pop()) return false;
            }

            return k.Count == 0;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            var result = nums.Distinct().ToArray();
            for (int i = 0; i < result.Length; i++)
            {
                nums[i] = result[i];
            }
            return result.Length;
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int j = 0;
            for (int i = m; i < n + m; i++)
            {
                nums1[i] = nums2[j];
                j++;
            }
            Array.Sort(nums1);


        }

        public static int MaximizeSum(int[] nums, int k)
        {
            Array.Sort(nums);
            int res = 0;
            for (int i = 0; i < k; i++)
            {
                res += nums.Last() + i;
            }
            return res;
        }

        public static double Average(int[] salary)
        {
            return salary.Where(x => x > salary.Min() && x < salary.Max()).Average();
        }

        public static int ArraySign(int[] nums)
        {
            int negativeCounter = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                    negativeCounter++;
                else
                    if (nums[i] == 0)
                    return 0;
            }
            return negativeCounter % 2 == 0 ? 1 : -1;
        }

        //2215. Find the Difference of Two Arrays
        public static IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            var n1 = nums1.ToList();
            var n2 = nums2.ToList();
            n1 = n1.Distinct().ToList();
            n2 = n2.Distinct().ToList();
            for (int i = 0; i < n2.Count; i++)
            {
                if (n1.Contains(n2[i]))
                {
                    n1.Remove(n2[i]);
                    n2.Remove(n2[i]);
                    i = 0;
                }
            }
            return new List<IList<int>>() { n1, n2 };
        }

        //27. Remove Element
        public static int RemoveElement(int[] nums, int val)
        {
            var res = nums.Where(x => x != val).ToArray();
            for (int i = 0; i < res.Length; i++)
            {
                nums[i] = res[i];
            }
            return res.Length;
        }

        //28. Find the Index of the First Occurrence in a String
        public static int StrStr(string haystack, string needle)
        {
            if (!haystack.Contains(needle))
                return -1;
            int count = 0;
            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[count])
                {
                    count++;
                    if (count == needle.Length)
                    {
                        return i - (needle.Length - 1);
                    }
                }
                else
                {
                    i -= count;
                    count = 0;
                }
            }
            return 0;

        }

        //35. Search Insert Position
        public static int BinarySearch(int[] nums, int left, int right, int target)
        {
            if (left > right) return left;

            int half = (right + left) / 2;
            if (nums[half] == target)
                return half;
            if (target < nums[half]) return BinarySearch(nums, left, half - 1, target);
            return BinarySearch(nums, half + 1, right, target);
        }
        public static int SearchInsert(int[] nums, int target)
        {
            return BinarySearch(nums, 0, nums.Length - 1, target);
        }

        //58. Length of Last Word
        public static int LengthOfLastWord(string s)
        {
            s = s.TrimEnd();
            var indexOfBlankSpace = s.LastIndexOf(" ");
            if (indexOfBlankSpace > -1)
            {
                return s.Length - 1 - indexOfBlankSpace;
            }
            else
            {
                return s.Length;
            }
        }

        //66. Plus One
        public static int[] PlusOne(int[] digits)
        {
            int n = digits.Length;
            for (int i = n - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }
                digits[i] = 0;
            }
            int[] newNumber = new int[n + 1];
            newNumber[0] = 1;

            return newNumber;
        }

        //67. Add Binary
        public static string AddBinary(string a, string b)
        {
            long firstBinary = Convert.ToInt64(a, 2);
            long secondBinary = Convert.ToInt64(b, 2);

            long sum = firstBinary + secondBinary;

            return (string)Convert.ToString(sum, 2);
        }

        //69. Sqrt(x)
        public static int MySqrt(int x)
        {
            for (int i = 1; i <= x; i++)
            {
                long squareI = i * i;
                if (squareI == x)
                {
                    return i;
                }
                if (squareI > x)
                {
                    return i - 1;
                }
            }
            return 0;

        }

        //70. Climbing Stairs
        public static int ClimbStairs(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 2;
            }
            int a = 1, b = 2, c = 0;
            for (int i = 2; i < n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c;
        }

        //83. Remove Duplicates from Sorted List
        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
            {
                return head;
            }
            ListNode newList = new ListNode();
            newList.val = head.val;
            ListNode resList = newList;
            while (head != null)
            {
                if (head.val != newList.val)
                {
                    newList.next = new ListNode(head.val);
                    newList = newList.next;
                }
                head = head.next;
            }
            return resList;
        }

        //94. Binary Tree Inorder Traversal
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public static List<int> result = new();
        public static IList<int> InorderTraversal(TreeNode root)
        {

            if (root != null)
            {
                InorderTraversal(root.left);
                result.Add(root.val);
                InorderTraversal(root.right);
            }
            return result;
        }

        //1502. Can Make Arithmetic Progression From Sequence
        public static bool CanMakeArithmeticProgression(int[] arr)
        {
            Array.Sort(arr);
            int diff = arr[1] - arr[0];
            for(int i=0; i<arr.Length; i++)
            {
                if(i+1 < arr.Length)
                {
                    if (arr[i+1] - arr[i] != diff)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //100. Same Tree
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            return (p == null && q == null) || ((p?.val == q?.val) && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right));
        }

        //104. Maximum Depth of Binary Tree
        public static int MaxDepth(TreeNode root)
        {
            return (root != null) ? Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1 : 0;
        }

        //108. Convert Sorted Array to Binary Search Tree
        public static TreeNode SortedArrayToBST(int[] nums)
        {
            return InsertTheNumInBST(0, nums.Length - 1);

            TreeNode InsertTheNumInBST(int left, int right)
            {
                if (left > right)
                {
                    return null;
                }
                int mid = left + (right - left) / 2;
                return new TreeNode(nums[mid], InsertTheNumInBST(left, mid - 1), InsertTheNumInBST(mid + 1, right));
            }
        }

        //110. Balanced Binary Tree
        public static int Findepth(TreeNode root)
        {
            return (root != null) ? Math.Max(Findepth(root.left), Findepth(root.right)) + 1 : 0;
        }
        public static bool IsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            int heightOfLeft = (root != null) ? Findepth(root.left) + 1 : 0;
            int heightOfRight = (root != null) ? Findepth(root.right) + 1 : 0;
            if(Math.Abs(heightOfLeft - heightOfRight) <= 1)
            {
                return IsBalanced(root.left) && IsBalanced(root.right);
            }
            return false;
        }

        //111. Minimum Depth of Binary Tree
        public static int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            int lDepth = MinDepth(root.left);
            int rDepth = MinDepth(root.right);
            if (lDepth == 0)
                return rDepth + 1;
            if (rDepth == 0)
                return lDepth + 1;
            return lDepth > rDepth ? rDepth + 1 : lDepth + 1;
        }

        //191. Number of 1 Bits
        public static int HammingWeight(uint n)
        {
            uint c = 0;

            while (n > 0)
            {
                c += n & 1; // or: c += n % 2;
                n >>= 1;    // or: n /= 2;
            }

            return (int)c;
        }
    }

}


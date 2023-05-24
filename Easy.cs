﻿using System;
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
                        return i - (needle.Length - 1) ;
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


    }

}


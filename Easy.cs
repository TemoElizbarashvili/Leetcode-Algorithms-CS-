using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
    }
}

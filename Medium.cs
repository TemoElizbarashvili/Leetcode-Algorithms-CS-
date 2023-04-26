using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static leetcode.Program;

namespace leetcode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    internal class Medium
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0); // head of newly generated list
            ListNode curr = dummyHead;
            int sum = 0;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0) //carry!=0 for the last node
            {
                sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + carry;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                carry = sum / 10;

                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
            }

            return dummyHead.next;
        }


        public static int LengthOfLongestSubstring(string s)
        {
            var stringArray = s.ToList();
            int dummyResult = 0, result = 0;
            for (int i = 0; i < stringArray.Count(); i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (j < stringArray.Count())
                    {
                        if (stringArray[i] == stringArray[j] && i != j)
                        {
                            if (dummyResult > result)
                                result = dummyResult;
                            dummyResult = 0;
                        }
                    }
                }
                dummyResult++;
                if (dummyResult > result)
                {
                    result = dummyResult;
                }

            }
            return result;
        }

        public static int Reverse(int x)
        {
            int result = 0;
            var revers = "";

            var reversList = x.ToString().Reverse().ToList();
            for (int i = 0; i < reversList.Count; i++)
            {
                if (x < 0 && i == reversList.Count() - 1)
                {
                    continue;
                }
                revers = revers + reversList[i];
            }

            if (x < 0)
            {

                if (Int32.TryParse(revers, out result))
                {
                    return -1 * result;
                }
                else
                    return 0;

            }

            if (Int32.TryParse(revers, out result))
            {
                return result;
            }
            else
                return 0;

        }


        public static int MyAtoi(string s)
        {
            List<char> chars = new();
            s = s.TrimStart(' ');
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsDigit(s[i]))
                {
                    chars.Add(s[i]);
                    continue;
                }
                if (i == 0 && s[0] == '-')
                    continue;
                if (i == 0 && s[0] == '+')
                    continue;
                break;
            }
            if (chars.Count == 0)
                return 0;
            bool cor = int.TryParse(String.Join("", chars), out int result);
            if (cor && s[0] == '-')
                return -result;
            if (cor)
                return result;
            if (!cor && s[0] == '-')
                return int.MinValue;
            else
                return int.MaxValue;

        }

        public static string IntToRoman(int num)
        {
            List<char> romanianNum = new List<char>();
            var result = "";
            if (num / 1000 != 0)
            {
                for (int i = 0; i < num / 1000; i++)
                {
                    romanianNum.Add('M');
                }
                num -= (num / 1000) * 1000;
            }
            if (num / 500 != 0)
            {
                if (num >= 900)
                {
                    romanianNum.Add('C');
                    romanianNum.Add('M');
                    num -= 900;
                }
                else
                {
                    romanianNum.Add('D');
                    num -= (num / 500) * 500;
                }
            }
            if (num / 100 != 0)
            {
                if (num >= 400)
                {
                    romanianNum.Add('C');
                    romanianNum.Add('D');
                    num -= 400;
                }
                else
                {
                    for (int i = 0; i < num / 100; i++)
                    {
                        romanianNum.Add('C');
                    }
                    num -= (num / 100) * 100;
                }
            }
            if (num / 50 != 0)
            {
                if (num >= 90)
                {
                    romanianNum.Add('X');
                    romanianNum.Add('C');
                    num -= 90;
                }
                else
                {
                    romanianNum.Add('L');
                    num -= (num / 50) * 50;
                }
            }
            if (num / 10 != 0)
            {
                if (num >= 40)
                {
                    romanianNum.Add('X');
                    romanianNum.Add('L');
                    num -= 40;
                }
                else
                {
                    for (int i = 0; i < num / 10; i++)
                    {
                        romanianNum.Add('X');
                    }
                    num -= (num / 10) * 10;
                }
            }
            if (num / 5 != 0)
            {
                if (num >= 9)
                {
                    romanianNum.Add('I');
                    romanianNum.Add('X');
                    num -= 9;
                }
                else
                {
                    romanianNum.Add('V');
                    num -= (num / 5) * 5;
                }
            }
            if (num / 1 != 0)
            {
                if (num >= 4)
                {
                    romanianNum.Add('I');
                    romanianNum.Add('V');
                    num -= 4;
                }
                else
                {
                    for (int i = 0; i < num / 1; i++)
                    {
                        romanianNum.Add('I');
                    }
                    num -= (num / 1) * 1;
                }
            }

            foreach (var item in romanianNum)
            {
                result += item;
            }
            return result;
        }

        public static int MaxArea(int[] height)
        {
            int area = 0;
            int x = 0, y = height.Length - 1;
            while (x < y)
            {
                int tmpMax = Math.Min(height[x], height[y]) * (y - x);
                if (tmpMax > area)
                {
                    area = tmpMax;
                }
                if (height[x] < height[y])
                {
                    x++;
                }
                else
                {
                    y--;
                }
            }

            return area;
        }
    }
}

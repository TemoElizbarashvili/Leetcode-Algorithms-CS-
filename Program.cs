using System.Diagnostics.CodeAnalysis;


namespace leetcode
{
    internal class Program
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
                        if (stringArray[i] == stringArray[j] && i!=j)
                        {
                            if(dummyResult > result)
                                result = dummyResult;
                            dummyResult = 0;
                        }
                    }
                }
                dummyResult++;
                if(dummyResult > result)
                {
                    result = dummyResult;
                }

            }
            return result;
        }


        public  static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var marged = nums1.ToList();
            foreach(var item in nums2)
            {
                marged.Add(item);
            }
            marged.Sort();
            if(marged.Count() % 2 == 0)
            {
                return (marged[marged.Count() / 2] + marged[(marged.Count() / 2) - 1]) / 2.0;
            }
            else
            {
                return marged[marged.Count() / 2];
            }

        }

        public static int Reverse(int x)
        {
            int result = 0;
            var revers = "";
            
            var reversList = x.ToString().Reverse().ToList();
            for (int i = 0; i < reversList.Count; i++)
            {
                if(x<0 && i == reversList.Count()-1)
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

       

        
        




        static void Main(string[] args)
        {

            Console.WriteLine(IntegerToRoman.RomanToInt("DCXXI"));


        }
    }
}
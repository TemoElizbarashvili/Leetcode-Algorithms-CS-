using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    internal static class Hard
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var marged = nums1.ToList();
            foreach (var item in nums2)
            {
                marged.Add(item);
            }
            marged.Sort();
            if (marged.Count() % 2 == 0)
            {
                return (marged[marged.Count() / 2] + marged[(marged.Count() / 2) - 1]) / 2.0;
            }
            else
            {
                return marged[marged.Count() / 2];
            }

        }

    }
}

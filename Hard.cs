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


        //----------------------NumSimilarGroups ----------------------
        //initialize parent and rank arrays
        private static int[] parent;
        private static int[] rank;

        public static int NumSimilarGroups(string[] strs)
        {
            
            parent = new int[strs.Length];
            rank = new int[strs.Length];
            int numberOfSets = 0;
            //make all element their own parent and give them rank 1
            for(int i = 0; i < strs.Length; i++)
            {
                parent[i] = i;
                rank[i] = 1;
            }
            //compare strings in strs array if they are similar then union
            for(int i=0; i < strs.Length; i++)
            {
                for(int j =i + 1; j < strs.Length; j++)
                {
                    if (IsSimilar(strs[i], strs[j])) 
                        Union(i, j);
                }
            }
            //if parent[i] = i, it means that it is whole set, so we should incrase our result by 1
            for(int i =0; i< strs.Length; i++)
            {
                if (parent[i] == i)
                    numberOfSets++;
            }
            return numberOfSets;
           
        }

        public static int FindParent(int x)
        {
            if(parent[x] != x) 
                parent[x] = FindParent(parent[x]);
            return parent[x];
        }

        public static void Union(int x, int y)
        {
            //find the main parent of set which x and y are part of
            int setOfX = FindParent(x);
            int setOfY = FindParent(y);
            //if they are in the same set return
            if (setOfX == setOfY) return;
            //if x set rank is less, join set X to set Y
            if (rank[setOfX] < rank[setOfY]) parent[setOfX] = setOfY;
            else
            {
                //otherwise do opossite
                if (rank[setOfX] > rank[setOfY]) parent[setOfY] = setOfX;
                else
                {
                    parent[setOfY] = setOfX;
                    rank[setOfX]++;
                }
            }
        }

        public static bool IsSimilar(string str1, string str2)
        {
            //variable to calculate difference it should be equal 2
            int diff = 0;
            //check if this two string is equal
            if (str1 == str2) return true;

            
            for(int i = 0; i< str1.Length; i++)
            {
                if (str1[i] != str2[i])
                    diff++;
                if (diff > 2) return false;
            }
            //returns true if difference is equal 2
            return diff == 2;

        }

        //---------------------- End of NumSimilarGroups ----------------------


        public static bool[] DistanceLimitedPathsExist(int n, int[][] edgeList, int[][] queries)
        {
            bool[] result = new bool[queries.Length];
            for(int i=0; i< result.Length; i++)
            {
                result[i] = true;
            }
            for(int i = 0; i < queries.Length; i++)
            {
                int firstVertex = queries[i][0];
                int secondVertex = queries[i][1];
                int weight = queries[i][2];
                bool done = true;
                while (done == true)
                {

                    for(int j=0; j < edgeList.Length; j++)
                    {
                        if (edgeList[j][0] == firstVertex)
                        {
                            if (edgeList[j][2] >= weight)
                            {
                                result[i] = false;
                                done = false;
                                break;
                            }
                            firstVertex = edgeList[j][1];
                        }
                        if(firstVertex == secondVertex)
                        {
                            done = false;
                            break;
                        }
                            
                    }
                }
                
            }
           
            return result;

        }

    }
}

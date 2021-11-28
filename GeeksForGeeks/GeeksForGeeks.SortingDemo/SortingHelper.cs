using System;
using System.Collections.Generic;

namespace GeeksForGeeks.SortingDemo
{
    public class SortingHelper
    {
        public SortingHelper()
        {
            Console.WriteLine("SortingHelper learning is start");
            //UnionOfTwoSortedArray();
            //new QuickSorting();
            _ = new SolvingProblems();
            Console.WriteLine("SortingHelper learning is ende");
        }
        /// <summary>
        /// Method to find out union of two sorted array.
        /// </summary>
        private void UnionOfTwoSortedArray()
        {
            int[] arr1 = { 2, 10, 20, 20 };
            int[] arr2 = { 3, 20, 40 };
            int[] unionArray = GetUnionArray(arr1, arr2);
            Console.WriteLine("After union :" + string.Join(" ,", unionArray));
        }

        private int[] GetUnionArray(int[] arr1, int[] arr2)
        {
            int m = arr1.Length, n = arr2.Length;
            List<int> temp = new List<int>();
            int i = 0, j = 0, k = 0;
            while (i < m && j < n)
            {
                if (i > 0 && arr1[i - 1] == arr1[i])
                {
                    i++;
                    continue;
                }
                if (j > 0 && arr2[j - 1] == arr2[j])
                {
                    j++;
                    continue;
                }
                if (arr1[i] < arr2[j])
                {
                    temp.Add(arr1[i]);
                    i++;
                    k++;
                }
                else if (arr2[j] < arr1[i])
                {
                    temp.Add(arr2[j]);
                    j++;
                    k++;
                }
                else
                {
                    temp.Add(arr2[j]);
                    i++; j++; k++;
                }
            }
            return temp.ToArray();
        }
    }
}

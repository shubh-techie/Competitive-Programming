using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.SortingDemo
{
    public class QuickSorting
    {
        public QuickSorting()
        {
            int[] arr = { 15, 6, 12, 34, 4, 55, 42, 8, 15, 6, 12, 34, 4, 55, 42, 8 };
            Console.WriteLine("Before :" + string.Join(", ", arr));
            int left = 0, right = arr.Length;


            QuickSort(arr, left, right - 1);
            Console.WriteLine("After :" + string.Join(", ", arr));
        }

        private void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pIndex = GetPivotNumber(arr, left, right);
                QuickSort(arr, left, pIndex - 1);
                QuickSort(arr, pIndex + 1, right);
            }
        }

        private int GetPivotNumber(int[] arr, int left, int right)
        {
            int pivotNumber = arr[right], pIndex = left - 1;
            for (int i = left; i <= right; i++)
            {
                if (arr[i] <= pivotNumber)
                {
                    pIndex++;
                    Swapping(arr, pIndex, i);
                }
            }
            return pIndex;
        }

        private void Swapping(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}

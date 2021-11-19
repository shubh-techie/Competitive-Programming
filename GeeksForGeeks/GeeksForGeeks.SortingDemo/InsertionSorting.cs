using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.SortingDemo
{
    class InsertionSorting
    {
        private void InsertionSortDemo()
        {
            int[] arr = { 185, 165, 150, 170, 145 };
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;
                int temp = arr[i];
                while (j > 0 && arr[j - 1] > temp)
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = temp;
            }
        }
    }
}

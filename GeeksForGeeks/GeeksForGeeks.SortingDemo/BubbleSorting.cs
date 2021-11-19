using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.SortingDemo
{
    class BubbleSorting
    {
        private void BubbleSortingDemo()
        {
            int[] heights = { 185, 165, 150, 170, 145 };
            int size = heights.Length;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1 - i; j++)
                {
                    if (heights[j] > heights[j + 1])
                    {
                        SwapArray(heights, j, j + 1);
                    }
                }
            }
            Console.WriteLine("After sorting ... : " + string.Join(", ", heights));
        }
        private void SwapArray(int[] heights, int i, int j)
        {
            int temp = heights[i];
            heights[i] = heights[j];
            heights[j] = temp;
        }
    }
}

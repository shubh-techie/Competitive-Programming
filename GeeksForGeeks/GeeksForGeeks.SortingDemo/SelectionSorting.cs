using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.SortingDemo
{
    class SelectionSorting
    {
        private void SelectionSortingDemo()
        {
            int[] heights = { 185, 165, 150, 170, 145 };
            int size = heights.Length;
            bool isSwap;
            for (int i = 0; i < size - 1; i++)
            {
                isSwap = false;
                for (int j = i; j < size; j++)
                {
                    if (heights[i] > heights[j])
                    {
                        SwapArray(heights, i, j);
                        isSwap = true;
                    }
                }
                if (!isSwap) break;
            }
        }
        private void SwapArray(int[] heights, int i, int j)
        {
            int temp = heights[i];
            heights[i] = heights[j];
            heights[j] = temp;
        }
    }
}

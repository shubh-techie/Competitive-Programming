using System;

namespace GeeksForGeeks.SortingDemo
{
    public class SortingHelper
    {
        public SortingHelper()
        {
            Console.WriteLine("SortingHelper learning is start");

            //SelectionSortingDemo();
            //BubbleSortingDemo();
            //InsertionSortDemo();
            Console.WriteLine("SortingHelper learning is ende");
        }

        private void InsertionSortDemo()
        {
            int[] arr = { 185, 165, 150, 170, 145 };
            int size = arr.Length;
            int temp = arr[1];
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;
                temp = arr[i];
                while (j > 0 && arr[j - 1] > temp)
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = temp;
            }
        }

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

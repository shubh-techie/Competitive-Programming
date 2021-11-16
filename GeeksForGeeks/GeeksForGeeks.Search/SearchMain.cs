using System;

namespace GeeksForGeeks.Search
{
    public class SearchMain
    {
        public SearchMain()
        {
            Console.WriteLine("Search learning is start");


            BinarySearchTesting();
            Console.WriteLine("Search learning is ende");
        }

        private void BinarySearchTesting()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int key = 5;
            Array.Sort(arr);
            int index = BinearySearch(arr, key);
            Console.WriteLine($"Index is :{index}");
        }

        private int BinearySearch(int[] arr, int key)
        {
            int leftIndex = 0, rightIndex = arr.Length - 1, midIndex;
            while (leftIndex <= rightIndex)
            {
                midIndex = leftIndex + (rightIndex - leftIndex) / 2;
                if (arr[midIndex] == key) return midIndex;
                else if (key < arr[midIndex]) rightIndex = midIndex - 1;
                else leftIndex = midIndex + 1;
            }
            throw new Exception("Number is not present in this array.");
        }
    }
}

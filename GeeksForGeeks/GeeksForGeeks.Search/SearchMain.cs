using System;

namespace GeeksForGeeks.Search
{
    public class SearchMain
    {
        public SearchMain()
        {
            Console.WriteLine("Search learning is start");
            MedianOfTwoSortedArrayDemo();
            //majorityElementTesting();

            BinarySearchTesting();
            Console.WriteLine("Search learning is ende");
        }

        public void merge(int[] arr1, int[] arr2, int n, int m)
        {
            int i = n - 1, j = m - 1, k = 0;
            while (j >= k && i >= 0)
            {
                if (arr2[j] > arr1[i])
                {
                    j--;
                }
                else
                {
                    int temp = arr1[i];
                    arr1[i] = arr2[k];
                    arr2[k] = temp;
                    i--;
                    k++;
                }
            }
            Array.Sort(arr1);
            Array.Sort(arr2);
        }

        private void MedianOfTwoSortedArrayDemo()
        {
            int n = 5, m = 6;
            int[] arr = { 1, 2, 3, 4, 5 };
            int[] brr = { 3, 4, 5, 6, 7, 8 };
            Console.WriteLine(FindMedianUsingBinarySerach(arr, n, brr, m));
        }

        private int FindMedianUsingBinarySerach(int[] arr, int n, int[] brr, int m)
        {
            int begin = 0, end = 0;
            if (n < m)
                end = n;
            else
                end = m;

            int mergeLength = m + n;

            while (begin <= end)
            {
                int midA = (begin + end) / 2;
                int midB = (mergeLength + 1) / 2 - midA;

                int maxA = midA == n ? int.MaxValue : arr[midA];
                int minA = midA == 0 ? int.MinValue : arr[midA];

                int maxB = midB == m ? int.MaxValue : brr[midB];
                int minB = midB == 0 ? int.MinValue : brr[midB];

                if (maxA <= minB && minB <= minA)
                {
                    if (mergeLength % 2 == 0)
                        return (Math.Max(maxA, maxB) + Math.Min(minA, minB)) / 2;
                    else
                        return Math.Max(maxA, maxB);

                }
                else if (minA > minB)
                {
                    end = midA - 1;
                }
                else
                {
                    begin = midA + 1;
                }
            }

            throw new Exception("No median found");
        }

        public int findMedian(int[] arr, int n, int[] brr, int m)
        {
            int[] temp = new int[m + n - 1];
            int k = 0, i = 0, j = 0;

            while (i < n && j < m)
            {
                if (arr[i] <= brr[j])
                {
                    temp[k] = arr[i];
                    i++;
                    k++;
                }
                else
                {
                    temp[k] = brr[j];
                    j++;
                    k++;
                }
            }

            while (i < n)
            {
                temp[k] = arr[i];
                i++;
                k++;
            }

            while (j < m)
            {
                temp[k] = brr[j];
                j++;
                k++;
            }

            int median = GetMedian(temp, temp.Length);
            return median;
        }

        private int GetMedian(int[] temp, int length)
        {
            int mid = length / 2;
            if (mid % 2 == 0)
                return temp[mid - 1] + temp[mid] / 2;
            else
                return temp[mid];
        }

        private void majorityElementTesting()
        {
            int[] arr = { 3, 1, 3, 3, 2 };
            Console.WriteLine(majorityElement(arr, arr.Length));
        }

        public int majorityElement(int[] a, int size)
        {
            int major = FindMostElement(a, size);
            Console.WriteLine(major);
            int count = 0;
            foreach (var item in a)
            {
                if (item == major)
                    count++;

                if (count > size / 2)
                {
                    return major;
                }
            }
            return -1;
        }

        public int FindMostElement(int[] arr, int size)
        {
            int most = arr[0], count = 0;
            foreach (var item in arr)
            {
                if (item == most)
                    count++;
                else
                    count--;

                if (count == 0)
                {
                    most = item;
                    count = 1;
                }
            }
            return most;
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

        private int BinearySearch(int[] arr, int leftIndex, int rightIndex, int key)
        {
            if (leftIndex > rightIndex) return -1;

            int midIndex = leftIndex + rightIndex / 2;
            if (arr[midIndex] == key)
                return midIndex;
            if (key < arr[midIndex])
                return BinearySearch(arr, leftIndex, midIndex - 1, key);
            else
                return BinearySearch(arr, midIndex + 1, rightIndex, key);
        }
    }
}

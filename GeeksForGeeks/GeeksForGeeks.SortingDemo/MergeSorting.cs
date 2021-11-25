using System;

namespace GeeksForGeeks.SortingDemo
{
    public class MergeSorting
    {
        public MergeSorting()
        {
            int[] arr = { 15, 6, 12, 34, 4, 55, 42, 8 };
            Console.WriteLine("Before :" + string.Join(", ", arr));
            int left = 0, right = arr.Length;


            MergeSort(arr, left, right - 1);
            Console.WriteLine("After :" + string.Join(", ", arr));
        }

        private void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                MergeSortTwoSortedArray(arr, left, mid, right);
            }
        }

        private void MergeSortTwoSortedArray(int[] arr, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];
            int i = left, j = mid + 1, k = 0;
            while (i <= mid && j <= right)
            {
                if (arr[i] < arr[j])
                {
                    temp[k] = arr[i];
                    i++;
                    k++;
                }
                else
                {
                    temp[k] = arr[j];
                    j++;
                    k++;
                }
            }
            while (i <= mid)
            {
                temp[k++] = arr[i++];
            }
            while (j <= right)
            {
                temp[k++] = arr[j++];
            }
            Console.WriteLine(string.Join(", ", temp));
            k = 0;
            for (i = left; i <= right; i++)
            {
                arr[i] = temp[k++];
            }
        }

        void MergeSolution(int[] Arr, int start, int mid, int end)
        {

            // create a temp array
            int[] temp = new int[end - start + 1];

            // crawlers for both intervals and for temp
            int i = start, j = mid + 1, k = 0;

            // traverse both arrays and in each iteration add smaller of both elements in temp 
            while (i <= mid && j <= end)
            {
                if (Arr[i] <= Arr[j])
                {
                    temp[k] = Arr[i];
                    k += 1; i += 1;
                }
                else
                {
                    temp[k] = Arr[j];
                    k += 1; j += 1;
                }
            }

            // add elements left in the first interval 
            while (i <= mid)
            {
                temp[k] = Arr[i];
                k += 1; i += 1;
            }

            // add elements left in the second interval 
            while (j <= end)
            {
                temp[k] = Arr[j];
                k += 1; j += 1;
            }
            k = 0;
            // copy temp to original interval
            for (i = start; i <= end; i += 1)
            {
                Arr[i] = temp[k++];
            }
        }
    }
}

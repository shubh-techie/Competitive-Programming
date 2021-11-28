using System;

namespace GeeksForGeeks.ArrayDemo
{
    public class ArrayDemoHelper
    {
        public ArrayDemoHelper()
        {
            //MaxInCircularArrayDemoTesting();
            //TrappingWaterDemo();
            //ReArrange();
            //MissingNumberDemo();
            //MaxOccuredDemo();
            //InsertAtEndDemo();
            Console.WriteLine("Press press <enter> to exit from console.");
            Console.ReadLine();
        }

        private void MaxInCircularArrayDemoTesting()
        {
            int[] arr = { 5, -2, 3, 4 };
            Console.WriteLine(MaxInCircularArrayDemo(arr, arr.Length));
        }

        int MaxSum(int[] arr, int n)
        {
            int currSum = arr[0];
            int MaxSum = arr[0];
            for (int i = 1; i < n; i++)
            {
                currSum = Math.Max(currSum + arr[i], arr[i]);
                MaxSum = Math.Max(currSum, MaxSum);
            }
            return MaxSum;
        }

        int MinMin(int[] arr, int n)
        {
            int currSum = arr[0];
            int MaxSum = arr[0];
            for (int i = 1; i < n; i++)
            {
                currSum = Math.Min(currSum + arr[i], arr[i]);
                MaxSum = Math.Min(currSum, MaxSum);
            }
            return MaxSum;
        }

        private int MaxInCircularArrayDemo(int[] arr, int n)
        {
            int maxNormalSum = MaxSum(arr, n);
            if (maxNormalSum < 0) return maxNormalSum;
            Console.WriteLine(maxNormalSum);
            int sum = 0;
            foreach (var item in arr)
            {
                sum += item;
            }

            return Math.Max(maxNormalSum, sum - MinMin(arr, n));
        }

        private void TrappingWaterDemo()
        {
            int[] arr = { 7, 4, 0, 9 };
            Console.WriteLine(TrappingWater(arr, arr.Length));
        }

        public long TrappingWater(int[] arr, int n)
        {
            long result = 0;
            if (arr == null || n < 3) return 0;
            int lMax = arr[0], rMax = arr[n - 1], left = 0, right = n - 1;
            while (left <= right)
            {
                if (arr[left] < arr[right])
                {
                    lMax = Math.Max(lMax, arr[left]);
                    result += lMax - arr[left];
                    left++;
                }
                else
                {
                    rMax = Math.Max(rMax, arr[right]);
                    result += rMax - arr[right];
                    right--;
                }
            }
            return result;
        }


        private void ReArrange()
        {
            int[] arr = { 3, 2, 0, 1 };
            int n = arr.Length;
            PrintArray(arr);

            for (int i = 0; i < n; i++)
            {
                arr[i] += (arr[arr[i]] % n) * n;
                PrintArray(arr);
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
                arr[i] /= n;
            PrintArray(arr);

        }

        private void MissingNumberDemo()
        {
            int[] arr = { 2, 3, 7, 6, 8, -1, -10, 15 };
            int N = arr.Length;
            Console.WriteLine(MissingNumber(arr, N));
        }

        public int MissingNumber(int[] arr, int n)
        {
            bool[] present = new bool[n + 1];
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > 0 && arr[i] <= n)
                    present[arr[i]] = true;
            }
            for (int i = 1; i <= n; i++)
            {
                if (!present[i])
                    return i;
            }
            return n + 1;
        }
        private void MaxOccuredDemo()
        {
            int[] L = { 1, 5, 9, 13, 21 };
            int[] R = { 15, 8, 12, 20, 30 };
            int n = 5;
            int maxx = 0;
            maxOccured(L, R, n, maxx);
        }
        public int maxOccured(int[] L, int[] R, int n, int maxx)
        {
            int min = L[0], max = R[0];
            for (int i = 1; i < n; i++)
                min = Math.Min(min, L[i]);
            for (int i = 1; i < n; i++)
                max = Math.Max(max, R[i]);

            int[] arr = new int[max + 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = L[i]; j <= R[i]; j++)
                {
                    arr[j]++;
                }
            }
            Console.WriteLine(string.Join(", ", arr));
            int top = 0;
            foreach (var item in arr)
            {
                top = Math.Max(item, top);
            }

            return top;
        }

        private static void InsertAtEndDemo()
        {
            int[] arr = { 1, 2, 3, 4, 5, 0 };
            int size = arr.Length;
            int element = 90;
            int index = 5;
            PrintArray(arr);
            InsertAtIndex(arr, size, index, element);
            PrintArray(arr);
        }

        private static void InsertAtIndex(int[] arr, int sizeOfArray, int index, int element)
        {

            ShiftArrayToRight(arr, index, sizeOfArray);
            arr[index] = element;
        }

        private static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(",", arr));
        }

        private static void ShiftArrayToRight(int[] arr, int index, int sizeOfArray)
        {
            for (int i = sizeOfArray - 1; i >= index; i--)
            {
                arr[i] = arr[i - 1];
            }
        }
    }
}
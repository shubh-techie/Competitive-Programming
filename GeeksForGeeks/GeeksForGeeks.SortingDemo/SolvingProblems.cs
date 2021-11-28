using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.SortingDemo
{
    public class SolvingProblems
    {
        public SolvingProblems()
        {
            //FindUnionDemo();
            TripletSumDemo();
        }

        private void TripletSumDemo()
        {
            int[] arr = { 1, 2, 4, 3, 6 };
            Console.WriteLine(find3Numbers(arr, arr.Length, 10));
        }

        public bool find3Numbers(int[] arr, int n, int X)
        {
            Array.Sort(arr);
            for (int i = 0; i < n - 2; i++)
            {
                if (IsPresent(arr, i, n, X))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsPresent(int[] arr, int index, int size, int sum)
        {
            int leftIndex = index + 1, rightIndex = size - 1;
            while (leftIndex < rightIndex)
            {
                int currSum = arr[index] + arr[leftIndex] + arr[rightIndex];
                if (currSum == sum)
                {
                    leftIndex++;
                    rightIndex++;
                    return true;
                }
                else if (currSum < sum)
                    leftIndex++;
                else
                    rightIndex--;
            }
            return false;
        }

        private void FindUnionDemo()
        {
            int n = 5; int[] arr1 = { 2, 2, 3, 4, 5 };
            int m = 5; int[] arr2 = { 1, 1, 2, 3, 4 };
            Console.WriteLine(string.Join(" ", findUnion(arr1, arr2, n, m)));
        }

        public List<int> findUnion(int[] arr1, int[] arr2, int length1, int length2)
        {
            int i = 0, j = 0;
            List<int> output = new List<int>();
            while (i < length1 && j < length2)
            {
                if (arr1[i] == arr2[j])
                {
                    if ((i == 0 || arr1[i] != arr1[i - 1]) && (j == 0 || arr2[j] != arr2[j - 1]))
                        output.Add(arr1[i]);
                    i++;
                    j++;
                }
                else if (arr1[i] < arr2[j])
                {
                    if (i == 0 || arr1[i] != arr1[i - 1])
                        output.Add(arr1[i]);
                    i++;
                }
                else
                {
                    if (j == 0 || arr2[j] != arr2[j - 1])
                        output.Add(arr2[j]);
                    j++;
                }
            }

            while (i < length1)
            {
                if (i == 0 || arr1[i] != arr1[i - 1])
                {
                    output.Add(arr1[i]);
                }
                i++;
            }

            while (j < length2)
            {
                if (j == 0 || arr2[j] != arr2[j - 1])
                {
                    output.Add(arr2[j]);
                }
                j++;
            }
            return output;
        }
    }
}

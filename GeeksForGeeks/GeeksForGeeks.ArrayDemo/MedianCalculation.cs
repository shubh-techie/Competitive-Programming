using System;

namespace GeeksForGeeks.ArrayDemo
{
    public class MedianCalculation
    {
        int mergeLength;

        double GetMedianOfTwoSortedArray(int[] arr, int[] brr, int arrLength, int brrLength)
        {
            mergeLength = arrLength + brrLength;
            int begin = 0;
            int end = arrLength < brrLength ? arrLength : brrLength;
            while (begin <= end)
            {
                int partitionA = (begin + end) / 2;
                int partitionB = (mergeLength + 1) / 2 - partitionA;

                int minA = partitionA == arrLength ? int.MaxValue : arr[partitionA];
                int maxA = partitionA == 0 ? int.MinValue : arr[partitionA];
                int minB = partitionB == brrLength ? int.MaxValue : arr[partitionB];
                int maxB = partitionB == 0 ? int.MinValue : brr[partitionB];

                if (minA <= maxB && minB <= maxA)
                {
                    return GetMedian(maxA, minA, maxB, minB);
                }
                if (minA > maxB)
                    end = minA - 1;
                else
                    begin = minA + 1;
            }
            throw new Exception("No Median found.");
        }

        double GetMedian(int maxA, int minA, int maxB, int minB)
        {
            if (mergeLength % 2 == 0)
            {
                int leftMax = Math.Max(minA, minB);
                int rightMin = Math.Min(maxA, maxB);
                return (leftMax + rightMin) / 2.0;
            }
            else
                return Math.Min(maxA, maxB);
        }
    }
}

using System;
using System.Collections.Generic;

namespace GeeksForGeeks.HashingDemo
{
    class HashSetsHelper
    {
        public HashSetsHelper()
        {
            SumExistsDemo();
            //CheckEqualDemo();
            //NumberofElementsInIntersectionDemo();
            //CountNonRepeatedDemo();
            //linearProbingDemo();
            //SeparateChainingDemo();
        }

        private void SumExistsDemo()
        {
            int[] arr = { 13, 87, 91, 62, 37, 56, 68, 56, 75, 32, 53, 51, 51, 42, 25, 67, 31, 8, 92 };
            Console.WriteLine(SumExists(arr, arr.Length, 14));


        }

        public int SumExists1(int[] arr, int N, int sum)
        {
            if (arr == null || N < 3) return 0;
            HashSet<int> sets = new HashSet<int>();
            foreach (var item in arr)
            {
                if (sets.Contains(sum - item))
                    return 1;
                else
                    sets.Add(item);
            }
            return 0;
        }

        public int SumExists(int[] arr, int sizeOfArray, int sum)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < sizeOfArray; i++)
            {
                int otherPair = sum - arr[i];
                if (set.Contains(otherPair))
                    return 1;
                else
                    set.Add(arr[i]);
            }
            return 0;
        }

        private void CheckEqualDemo()
        {
            int n = 5;
            long[] A = { 1, 2, 5, 4, 0 };
            long[] B = { 2, 4, 5, 0, 1 };
            Console.WriteLine(CheckEqual(A, B, n));
        }

        public bool CheckEqual(long[] A, long[] B, int n)
        {
            Dictionary<long, long> fq = new Dictionary<long, long>();
            foreach (var item in A)
            {
                if (!fq.ContainsKey(item))
                    fq.Add(item, 1);
                else
                    fq[item]++;
            }

            foreach (var item in B)
            {
                if (!fq.ContainsKey(item))
                    return false;
                else
                    fq[item]--;
            }

            foreach (var item in fq)
            {
                if (item.Value != 0)
                    return false;
            }
            return true;
        }

        private void NumberofElementsInIntersectionDemo()
        {
            int n = 5, m = 3;
            int[] a = { 89, 24, 75, 11, 23 };
            int[] b = { 89, 2, 4 };
            Console.WriteLine(NumberofElementsInUnion(a, b, n, m));
        }

        private int NumberofElementsInUnion(int[] a, int[] b, int n, int m)
        {
            HashSet<int> sets = new HashSet<int>(a);
            foreach (var item in b)
            {
                sets.Add(item);
            }
            return sets.Count;
        }
        private void CountNonRepeatedDemo()
        {
            int[] arr = { 1, 5, 3, 4, 3, 5, 6 };
            int size = arr.Length;
            CountNonRepeated(arr, size);
        }

        public int CountNonRepeated(int[] arr, int n)
        {
            Dictionary<int, int> fq = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                if (!fq.ContainsKey(arr[i]))
                    fq.Add(arr[i], i + 1);
                else
                    fq[arr[i]]++;
            }
            int index = 0;
            foreach (var item in fq)
            {
                Console.WriteLine($"{item.Key}-{item.Value}");
                if (item.Value > 1)
                {
                    index++;
                    return index;
                }
                index++;
            }
            return -1;
        }

        private void linearProbingDemo()
        {
            int hasSize = 10, sizeOfArray = 6;
            int[] arr = { 92, 4, 14, 24, 44, 91 };
            Console.WriteLine(string.Join(" ", linearProbing(hasSize, arr, sizeOfArray)));
        }

        public List<int> linearProbing(int hashSize, int[] arr, int sizeOfArray)
        {
            List<int> table = new List<int>(hashSize);
            for (int i = 0; i < hashSize; i++)
            {
                table[i] = -1;
            }
            for (int i = 0; i < sizeOfArray; i++)
            {
                int key = arr[i];
                int position = key % hashSize;
                if (table[position] != -1)
                    table[position] = arr[i];
                else
                {
                    int counter = 0;
                    while ((table[position] != -1 && counter <= hashSize))
                    {
                        if (table[position] == key) break;
                        position = (position + 1) % hashSize;
                        counter++;
                    }
                    if (table[key] == -1)
                        table[key] = key;
                }
            }
            return table;
        }

        private void SeparateChainingDemo()
        {
            int hasSize = 10, sizeOfArray = 6;
            int[] arr = { 92, 4, 14, 24, 44, 91 };
            List<List<int>> output = SeparateChaining(hasSize, arr, sizeOfArray);

        }

        public List<List<int>> SeparateChaining(int hashSize, int[] arr, int sizeOfArray)
        {
            List<List<int>> table = BuildHashTable(hashSize);
            for (int i = 0; i < sizeOfArray; i++)
            {
                table[arr[i] % hashSize].Add(arr[i]);
            }
            return table;
        }

        private List<List<int>> BuildHashTable(int hashSize)
        {
            List<List<int>> table = new List<List<int>>();
            for (int i = 0; i < hashSize; i++)
            {
                table.Add(new List<int>());
            }
            return table;
        }
    }
}

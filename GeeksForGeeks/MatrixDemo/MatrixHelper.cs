using System;
using System.Collections.Generic;

namespace GeeksForGeeks.MatrixDemo
{
    public class MatrixHelper
    {
        public MatrixHelper()
        {
            Console.WriteLine("MatrixHelper learning is start");

            int[,] arr = { { 1, 2, 3, 3 }, { 4, 5, 6, 7 }, { 7, 8, 9, 9 } };
            PrintMatrixInSnakePatter(arr);
            //JaggedArrayDemo();
            //Array2DDemo();
            TestSubMatrix();
            Console.WriteLine("MatrixHelper learning is ende");
        }

        private void TestSubMatrix()
        {
            List<List<int>> A = new List<List<int>>();
            A.Add(new List<int> { 1, 2 });
            A.Add(new List<int> { 3, 4 });
            A.Add(new List<int> { 5, 6 });

            List<List<int>> B = new List<List<int>>();
            A.Add(new List<int> { 1, 3 });
            A.Add(new List<int> { 3, 2 });
            A.Add(new List<int> { 3, 3 });

            var temp = SumMatrix(A, B);
            foreach (var item in temp)
            {
                Console.WriteLine(string.Join(", ",item.ToArray()));
            }
        }

        public List<List<int>> SumMatrix(List<List<int>> A, List<List<int>> B)
        {
            if (A == null || A.Count == 0) return B;
            if (B == null || B.Count == 0) return A;
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = 0; j < A[i].Count; j++)
                {
                    B[i][j] = B[i][j] + A[i][j];
                }
            }
            return B;
        }

        private void PrintMatrixInSnakePatter(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write(arr[i, j]);
                    }
                }
                else
                {
                    for (int j = cols - 1; j >= 0; j--)
                    {
                        Console.Write(arr[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        private void Array2DDemo()
        {
            int[,] arr = { { 1, 2, 3, 3 }, { 4, 5, 6, 7 }, { 7, 8, 9, 9 } };
            Print2DArray(arr);

        }

        public void Print2DArray(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            int totalNumber = arr.Length;
            Console.WriteLine("Total Number :{0}", totalNumber);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{arr[i, j]},");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void JaggedArrayDemo()
        {
            int[][] arr = new int[5][];

            arr[0] = new int[] { 0 };
            arr[1] = new int[] { 1, 2 };
            arr[2] = new int[] { 1, 2, 3 };
            arr[3] = new int[] { 1, 2, 3, 4 };
            arr[4] = new int[] { 1, 2, 3, 4, 5 };

            Print2DJaggedArray(arr);


        }

        private void Print2DJaggedArray(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{arr[i][j]},");
                }
                Console.WriteLine();
            }
        }
    }
}

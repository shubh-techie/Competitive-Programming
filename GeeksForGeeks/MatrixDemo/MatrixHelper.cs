using System;
using System.Collections.Generic;

namespace GeeksForGeeks.MatrixDemo
{
    public class MatrixHelper
    {
        public MatrixHelper()
        {
            Console.WriteLine("MatrixHelper learning is start");

            //int[,] arr = { { 1, 2, 3, 3 }, { 4, 5, 6, 7 }, { 7, 8, 9, 9 } };
            //PrintMatrixInSnakePatter(arr);
            //JaggedArrayDemo();
            //Array2DDemo();
            //TestSubMatrix();
            //Print(5);
            //TransposeMatrix();
            //rotateby90Testing();
            //boundryTesting();
            SpirallyTraversingMaxtrix();
            Console.WriteLine("MatrixHelper learning is ende");
        }

        private void SpirallyTraversingMaxtrix()
        {
            List<List<int>> matrix = new List<List<int>>();
            matrix.Add(new List<int> { 1, 2, 3, 4 });
            matrix.Add(new List<int> { 5, 6, 7, 8 });
            matrix.Add(new List<int> { 9, 10, 11, 12 });
            matrix.Add(new List<int> { 13, 14, 15, 16 });
            var result = spirallyTraverse(matrix, 4, 4);
            Print2DArrayListCollection(matrix);
            Console.WriteLine(string.Join(" ,", result.ToArray()));
        }

        public List<int> spirallyTraverse(List<List<int>> matrix, int r, int c)
        {
            List<int> result = new List<int>();
            if (matrix.Count == 0)
            {
                return result;
            }
            int top = 0, left = 0, bottom = r - 1, right = c - 1;

            while (left <= right && top <= bottom)
            {
                for (int col = left; col <= right; col++)
                    result.Add(matrix[top][col]);
                top++;

                for (int row = top; row <= bottom; row++)
                    result.Add(matrix[row][right]);
                right--;

                for (int col = right; top <= bottom && col >= left; col--)
                    result.Add(matrix[bottom][col]);
                bottom--;

                for (int row = bottom; left <= right && row >= top; row--)
                    result.Add(matrix[row][left]);
                left++;
            }
            return result;
        }

        public void boundryTesting()
        {
            List<List<int>> matrix = new List<List<int>>();
            matrix.Add(new List<int> { 1, 2, 3, 4 });
            matrix.Add(new List<int> { 5, 6, 7, 8 });
            matrix.Add(new List<int> { 9, 10, 11, 12 });
            matrix.Add(new List<int> { 13, 14, 15, 16 });

            var result = boundaryTraversal(matrix, matrix.Count, matrix[0].Count);
            Console.WriteLine(string.Join(" ", result.ToArray()));
        }
        public List<int> boundaryTraversal(List<List<int>> matrix, int n, int m)
        {
            List<int> result = new List<int>();
            int rows = n, cols = m;
            int top = 0, left = 0;

            for (int col = 0; col < cols; col++)
                result.Add(matrix[top][col]);
            top++;
            for (int row = top; row < rows; row++)
                result.Add(matrix[row][cols - 1]);
            cols--;
            for (int col = cols - 1; col >= 0; col--)
                result.Add(matrix[rows - 1][col]);
            rows--;
            for (int row = rows - 1; row >= top; row--)
                result.Add(matrix[row][left]);

            return result;
        }

        public List<int> sumTriangles(List<List<int>> matrix, int n)
        {
            List<int> result = new List<int>();
            int upperSum = 0, lowerSum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j <= i)
                        lowerSum += matrix[i][j];
                    if (j >= i)
                        upperSum += matrix[i][j];
                }
            }
            result.Add(upperSum);
            result.Add(lowerSum);
            return result;
        }

        public void rotateby90Testing()
        {
            List<List<int>> matrix = new List<List<int>>();
            matrix.Add(new List<int> { 1, 2, 3 });
            matrix.Add(new List<int> { 4, 5, 6 });
            matrix.Add(new List<int> { 7, 8, 9 });

            //var output = sumTriangles(matrix, matrix.Count);
            //Console.WriteLine(string.Join(", ", output.ToArray()));

            Console.WriteLine("Before Rotate");
            Print2DArrayListCollection(matrix);
            rotateby90(matrix, matrix.Count);
        }
        public void rotateby90(List<List<int>> matrix, int n)
        {
            Transpose(matrix, n);
            Console.WriteLine("After Traspose");
            Print2DArrayListCollection(matrix);
            //roverse the cols

            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[n - 1 - i][j];
                    matrix[n - 1 - i][j] = temp;
                }
            }

        }

        public void Transpose(List<List<int>> matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
        }

        public List<int> snakePattern(List<List<int>> matrix)
        {
            List<int> result = new List<int>();
            int rows = matrix.Count, cols = matrix[0].Count;
            for (int i = 0; i < rows; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < cols; j++)
                        result.Add(matrix[i][j]);
                }
                else
                {
                    for (int j = cols - 1; j >= 0; j--)
                        result.Add(matrix[i][j]);
                }
            }
            return result;
        }


        private void TransposeMatrix()
        {
            int[,] arr = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            Print2DArray(arr);
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    //Console.Write(arr[i, j]);
                    int temp = arr[i, j];
                    arr[i, j] = arr[j, i];
                    arr[j, i] = temp;
                }
                Console.WriteLine();
            }

            Print2DArray(arr);
        }

        private void Print(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        private void TestSubMatrix()
        {
            List<List<int>> A = new List<List<int>>();
            A.Add(new List<int> { 1, 2 });
            A.Add(new List<int> { 3, 4 });
            A.Add(new List<int> { 5, 6 });

            List<List<int>> B = new List<List<int>>();
            B.Add(new List<int> { 1, 3 });
            B.Add(new List<int> { 3, 2 });
            B.Add(new List<int> { 3, 3 });

            var temp = SumMatrix(A, B);
            Print2DArrayListCollection(temp);
        }

        private void Print2DArrayListCollection(List<List<int>> temp)
        {
            foreach (var item in temp)
            {
                Console.WriteLine(string.Join(", ", item.ToArray()));
            }
        }

        public List<List<int>> SumMatrix(List<List<int>> A, List<List<int>> B)
        {
            if (A == null || A.Count == 0) return B;
            if (B == null || B.Count == 0) return A;
            int m = A.Count, n = A[0].Count;
            int p = B.Count, q = B[0].Count;
            if (m == p && n == q)
            {
                for (int i = 0; i < A.Count; i++)
                {
                    for (int j = 0; j < A[i].Count; j++)
                    {
                        B[i][j] = B[i][j] + A[i][j];
                    }
                }
                return B;
            }
            return new List<List<int>>() { new List<int> { -1 } };
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

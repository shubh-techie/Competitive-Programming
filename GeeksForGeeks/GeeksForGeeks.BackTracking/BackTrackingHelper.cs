using System;

namespace GeeksForGeeks.BackTracking
{
    public class BackTrackingHelper
    {
        public BackTrackingHelper()
        {
            //PermutationAbcDemo();
            //RatInMazeDemo();
            SudokoProblemDemo();
        }

        private void SudokoProblemDemo()
        {
            int[,] sudokoBoard =  {
            { 3, 0, 6, 5, 0, 8, 4, 0, 0 },
            { 5, 2, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 8, 7, 0, 0, 0, 0, 3, 1 },
            { 0, 0, 3, 0, 1, 0, 0, 8, 0 },
            { 9, 0, 0, 8, 6, 3, 0, 0, 5 },
            { 0, 5, 0, 0, 9, 0, 6, 0, 0 },
            { 1, 3, 0, 0, 0, 0, 2, 5, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 7, 4 },
            { 0, 0, 5, 2, 0, 6, 3, 0, 0 }
            };

            int rows = sudokoBoard.GetLength(0);
            int cols = sudokoBoard.GetLength(1);
            bool result = SolveSudoko(sudokoBoard, rows);
            if (result)
            {
                Console.WriteLine("Yes there is solution.");
                Print2DArray(sudokoBoard);
            }
            else
            {
                Console.WriteLine("No, solution");
                Print2DArray(sudokoBoard);
            }
        }

        private bool SolveSudoko(int[,] sudokoBoard, int size)
        {
            int i = 0, j = 0;
            bool isEmptyCell = false;
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    if (sudokoBoard[i, j] == 0)
                    {
                        isEmptyCell = true;
                        break;
                    }
                }
                if (isEmptyCell)
                    break;
            }

            if (!isEmptyCell && i == size && j == size)
                return true;

            for (int no = 1; no <= size; no++)
            {
                if (IsValidNumber(sudokoBoard, i, j, size, no))
                {
                    sudokoBoard[i, j] = no;
                    if (SolveSudoko(sudokoBoard, size))
                        return true;
                    sudokoBoard[i, j] = 0;
                }
            }
            return false;
        }

        private bool IsValidNumber(int[,] sudokoBoard, int row, int col, int size, int number)
        {
            for (int k = 0; k < size; k++)
            {
                if (sudokoBoard[k, col] == number || sudokoBoard[row, k] == number)
                    return false;
            }

            int sqrt = (int)Math.Sqrt(size);
            int rowStart = row - row % sqrt;
            int colStart = col - col % sqrt;

            for (int p = 0; p < sqrt; p++)
            {
                for (int q = 0; q < sqrt; q++)
                {
                    if (sudokoBoard[p + rowStart, q + colStart] == number)
                        return false;
                }
            }
            return true;
        }

        public void Print2DArray(int[,] arr)
        {
            Console.WriteLine();
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Join(" ", arr[i, j]) + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void RatInMazeDemo()
        {
            int[,] maze = {
               { 1, 0, 0, 0 },
               { 1, 1, 0, 1 },
               { 0, 1, 0, 0 },
               { 1, 1, 1, 1 }
               };

            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);
            int[,] visited = new int[rows, cols];

            bool hasPath = CheckPath(0, 0, maze, visited, rows, cols);

            Print2DArray(maze);
            Console.WriteLine($"Path present :{hasPath}");
            Console.WriteLine("Solution is here.");
            Print2DArray(visited);
        }

        private bool CheckPath(int i, int j, int[,] maze, int[,] visited, int rows, int cols)
        {
            if (i == rows - 1 && j == cols - 1)
            {
                visited[i, j] = 1;
                return true;
            }

            if (IsValidCall(i, j, maze, rows, cols))
            {
                visited[i, j] = 1;
                if (CheckPath(i + 1, j, maze, visited, rows, cols))
                    return true;
                else if (CheckPath(i, j + 1, maze, visited, rows, cols))
                    return true;
                visited[i, j] = 0;
            }
            return false;
        }

        private bool IsValidCall(int i, int j, int[,] maze, int rows, int cols)
        {
            return i >= 0 && j >= 0 && i < rows && j < cols && maze[i, j] == 1;
        }

        private void PermutationAbcDemo()
        {
            string str = "ABCABCABCABCAB";
            PrintPermutation(str, 0, str.Length);
        }

        private void PrintPermutation(string str, int leftIndex, int length)
        {
            if (leftIndex == length)
            {
                if (!str.Contains("AB"))
                    Console.WriteLine(str);
                return;
            }

            for (int i = leftIndex; i < length; i++)
            {
                str = SwappingString(str, leftIndex, i);
                if (IsValidCall(str, leftIndex, i))
                    PrintPermutation(str, leftIndex + 1, length);
                str = SwappingString(str, leftIndex, i);
            }
        }

        private static bool IsValidCall(string str, int leftIndex, int i)
        {
            if (i != 0 && str[i - 1] == 'A' && str[i] == 'B')
                return false;
            else
                return true;
        }

        public string SwappingString(string str, int index1, int index2)
        {
            char[] charArr = str.ToCharArray();
            char temp = charArr[index1];
            charArr[index1] = charArr[index2];
            charArr[index2] = temp;
            return new string(charArr);
        }
    }
}

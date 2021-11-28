using System;

namespace GeeksForGeeks.TimeSpaceComplexityAnalysis
{
    public class TimeSpaceComplexity
    {
        public TimeSpaceComplexity()
        {
            Console.WriteLine("TimeSpaceComplexityAnalysis learning is start");

            CheckComplexity();

            Console.WriteLine("TimeSpaceComplexityAnalysis learning is ende");
        }

        private void CheckComplexity1()
        {
            int n = 5, k = 10;

            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < k; j++)
                {
                    Console.Write(i + j + " ");
                }
                Console.WriteLine();
            }
        }

        private void CheckComplexity()
        {
            int n = 10;
            while (n > 0)
            {
                int j = n;
                while (j > 1)
                {
                    j -= 1;
                    Console.Write("J " + " ");
                }
                n /= 2;
                Console.WriteLine();
            }
        }
    }
}

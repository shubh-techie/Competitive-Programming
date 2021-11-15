using System;

namespace GeeksForGeeks.Mathematics
{
    public class MathematicsHelper
    {
        public MathematicsHelper()
        {
            Console.WriteLine("MathematicsHelper learning is start");
            Console.WriteLine(GetPower(3, 4));
            //Console.WriteLine(GetLCM(24, 20));
            //Console.WriteLine(GetFactorial(5));
            //Console.WriteLine(IsPalindromeNumbers(345));
            //Console.WriteLine(GetDigitCount(10111));
            Console.WriteLine("MathematicsHelper learning is ende");
        }

        private int GetPower(int number, int pow)
        {
            int result = 1;
            for (int i = 0; i < pow; i++)
            {
                result *= number;
            }
            return result;
        }

        private bool IsPrimeNumber(int number)
        {
            if (number <= 1) return false;
            if (number == 2 || number == 3) return false;
            if (number % 2 == 0 || number % 3 == 0) return false;
            for (int i = 5; i * 1 <= number; i = i + 6)
            {
                if (number % i == 0 || number % (i + 2) == 0) return false;
            }
            return true;
        }

        private int GetLCM(int v1, int v2)
        {
            int result = Math.Max(v1, v2);
            while (true)
            {
                if (result % v1 == 0 && result % v2 == 0) return result;
                result++;
            }
            return -1;
        }

        private int GetFactorial(int number)
        {
            if (number == 1) return 1;
            return number * GetFactorial(number - 1);
        }

        private bool IsPalindromeNumbers(int number)
        {
            bool isPol = false;
            int rev = 0;
            int decPosition = 0;
            while (number > rev)
            {
                int mod = number % 10;
                rev = rev * 10 + mod;
                if (rev == number) return true;
                number = number / 10;
                decPosition++;
            }

            return isPol;
        }

        private int GetDigitCount(int number)
        {
            int result = 0;
            while (number > 0)
            {
                result++;
                number = number / 10;
            }
            return result;
        }
    }
}

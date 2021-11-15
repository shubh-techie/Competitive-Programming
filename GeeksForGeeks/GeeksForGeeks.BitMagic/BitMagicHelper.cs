using System;

namespace GeeksForGeeks.BitMagic
{
    public class BitMagicHelper
    {
        public BitMagicHelper()
        {
            Console.WriteLine("BitMagicHelper learning is start");

            BitWiseOperatorDemo();
            Console.WriteLine("BitMagicHelper learning is ende");
        }

        private void BitWiseOperatorDemo()
        {
            int x = 3, y = 6;
            Console.WriteLine(x ^ y);
            Console.WriteLine(x & y);
            Console.WriteLine(x | y);
            Console.WriteLine(0 | 1);
            Console.WriteLine(x << 2);
            Console.WriteLine(y >> 1);
            Console.WriteLine(2 >> 1);
            Console.WriteLine(5 >> 2);
            UInt32 u = 10;
            Console.WriteLine(~u);
        }
    }
}

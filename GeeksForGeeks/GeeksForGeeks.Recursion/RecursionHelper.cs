using System;

namespace GeeksForGeeks.Recursion
{
    public class RecursionHelper
    {
        public RecursionHelper()
        {
            Console.WriteLine("RecursionHelper learning is start");

            PrintingPrintingAllPermitution();

            Console.WriteLine("RecursionHelper learning is ende");
        }

        public void PrintingPrintingAllPermitution()
        {
            string str = "ABC";
            Printing(str, 0, str.Length);
        }

        private void Printing(string str, int l, int r)
        {
            if (l == r)
                Console.WriteLine(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = SwappingStringArra(str, l, i);
                    SwappingStringArra(str, l + 1, r);
                    str = SwappingStringArra(str, l, i);
                }
            }
        }

        private string SwappingStringArra(string str, int i, int fixedIndex)
        {
            char[] arr = str.ToCharArray();
            char temp = arr[i];
            arr[i] = arr[fixedIndex];
            arr[fixedIndex] = temp;
            return new string(arr);
        }
    }
}

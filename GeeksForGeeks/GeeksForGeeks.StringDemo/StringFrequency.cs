using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.StringDemo
{
    public class StringFrequency
    {
        public StringFrequency()
        {
            string str = "geeksforgeeks";
            PrintFrequency(str);
        }

        private void PrintFrequency(string str)
        {
            int[] arr = new int[26];
            foreach (var item in str)
            {
                arr[item - 'a']++;
            }
            for (int i = 0; i < 26; i++)
            {
                if (arr[i] > 0)
                    Console.WriteLine($"{Convert.ToChar(i + 'a')}-{arr[i]}");
            }
        }
    }
}

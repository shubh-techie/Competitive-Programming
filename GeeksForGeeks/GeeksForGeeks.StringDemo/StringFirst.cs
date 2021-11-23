using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Search
{
    public class StringFirst
    {
        public StringFirst()
        {
            ReverseDemoCheck();
            //SearchAnagramInString();
            //SearchAString();
            //ReverseAStringDemo();
            //LeftmostNotRepeatingCharacter();
            //LeftmostRepeatingCharacter();
            //AnagramDemo();
            //SubsequenceCheckDemo();
            //PowerSetDemo();
            //PalindromeChecking();
            //StringDemoFunction();
            //ASCIIDemo();
        }

        private void ReverseDemoCheck()
        {
            char[] arr = { 'A', 'B', 'C', 'D' };
            Console.WriteLine(string.Join(" ", arr));
            ReverseStringRecursion(arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(" ", arr));
        }

        private void ReverseStringRecursion(char[] s, int left, int right)
        {
            if (left > right)
            {
                return;
            }
            char temp = s[left];
            s[left] = s[right];
            s[right] = temp;
            ReverseStringRecursion(s, left + 1, right - 1);
        }

        public void ReverseString(char[] s)
        {
            if (s == null || s.Length == 0) return;
            int left = 0, right = s.Length - 1;
            while (left <= right)
            {
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
            }
        }

        private void SearchAnagramInString()
        {
            string text = "geeksforgeeksfrogfrog";
            string pattern = "frog";
            Console.WriteLine(IsAnagramFound(text, pattern));

        }

        private bool IsAnagramFound(string text, string pattern)
        {
            if (text == null || pattern == null) return false;
            if (text == "" && pattern == "") return true;
            int textLength = text.Length, pLength = pattern.Length;
            if (pLength > textLength) return false;

            int[] textTable = new int[256];
            int[] patternTable = new int[256];

            for (int pIndex = 0; pIndex < pLength; pIndex++)
            {
                textTable[text[pIndex]]++;
                patternTable[pattern[pIndex]]++;
            }

            for (int index = pLength; index < textLength - pLength + 1; index++)
            {
                if (TableSame(textTable, patternTable))
                    return true;

                textTable[text[index]]++;
                textTable[text[index - pLength]]--;
            }
            return false;
        }

        private bool TableSame(int[] textTable, int[] patternTable)
        {
            for (int i = 0; i < 256; i++)
            {
                if (textTable[i] != patternTable[i])
                    return false;
            }
            return true;
        }

        private void SearchAnagramInString1()
        {
            string text = "geeksforgeeksfrogfrog";
            string pattern = "frog";
            int m = text.Length, n = pattern.Length;
            for (int i = 0; i < m - n + 1; i++)
            {
                if (IsCheckAnagram(pattern, text.Substring(i, n)))
                {
                    Console.WriteLine($"Yes its anagram, index is :{i}");
                }
            }
            Console.WriteLine("No Anagram");
        }

        private bool IsCheckAnagram(string str1, string str2)
        {
            int[] table = new int[256];
            for (int i = 0; i < str2.Length; i++)
            {
                table[str1[i]]++;
                table[str2[i]]--;
            }
            foreach (var item in table)
            {
                if (item != 0) return false;
            }
            return true;
        }
        private void SearchAString()
        {
            string text = "ABABABCD";
            string pattern = "ABAB";
            int textLength = text.Length, pLength = pattern.Length;
            for (int i = 0; i < textLength - pLength + 1; i++)
            {
                int pIndex;
                for (pIndex = 0; pIndex < pLength; pIndex++)
                {
                    if (text[i + pIndex] != pattern[pIndex]) break;
                }
                if (pIndex == pLength)
                    Console.WriteLine(i);
            }
        }

        private void ReverseAStringDemo()
        {
            string str = "i.like.this.program.very.much";
            ReverseASting(str.ToCharArray());
        }

        private void ReverseASting(char[] str)
        {
            int start = 0;
            for (int end = 0; end < str.Length; end++)
            {
                if (str[end] == '.')
                {
                    Reverse(str, start, end - 1);
                    start = end + 1;
                }
            }
            Reverse(str, start, str.Length - 1);
            Reverse(str, 0, str.Length - 1);
            Console.WriteLine(string.Join("", str));
        }

        private void Reverse(char[] str, int start, int end)
        {
            while (start <= end)
            {
                char temp = str[start];
                str[start] = str[end];
                str[end] = temp;
                start++;
                end--;
            }
        }

        private void ReverseAStingWithStack(string str)
        {
            Console.WriteLine(str);
            Stack<string> stack = new Stack<string>();

            foreach (var item in str.Split(' '))
            {
                stack.Push(item);
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in stack)
            {
                sb.Append(item + " ");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private void LeftmostNotRepeatingCharacter()
        {
            string s = "happleh";
            int[] track = new int[256];
            char output = '$';
            foreach (var item in s)
            {
                track[item]++;
            }
            foreach (var item in s)
            {
                if (track[item] == 1)
                    Console.WriteLine(track[item]);
            }
            Console.WriteLine($"{output}");
        }

        private void LeftmostRepeatingCharacter()
        {
            string str = "abacbbbcd";
            int[] table = new int[26];
            foreach (var item in str)
            {
                table[item - 'a']++;
            }
            int result = 0, resultIndex = -1;
            for (int index = 0; index < str.Length; index++)
            {
                if (table[str[index] - 'a'] > result)
                {
                    result = table[str[index] - 'a'];
                    resultIndex = index;
                }

            }
            Console.WriteLine($"most repeated : {resultIndex} and char : {str[resultIndex]}");
        }

        private void AnagramDemo()
        {
            string str1 = "listena", str2 = "silent";
            bool result = IsAnagram(str1, str2);
        }

        private bool IsAnagram(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;

            int[] table = new int[26];
            for (int i = 0; i < str1.Length; i++)
            {
                table[str1[i] - 'a']++;
                table[str2[i] - 'a']--;
            }
            foreach (var item in table)
            {
                if (item != 0)
                    return false;
            }
            return true;
        }

        private void SubsequenceCheckDemo()
        {
            string str1 = "ABCDEF";
            string str2 = "ABCDEF";
            bool result = IsSubsequenceRecurstion(str1, str2, str1.Length - 1, str2.Length - 1);
            Console.WriteLine($"{str1}-{str2} is {result}");
        }

        public bool IsSubsequenceRecurstion(string str1, string str2, int m, int n)
        {
            if (n == 0) return true;
            if (m == 0) return false;

            if (str1[m] == str2[n])
                return IsSubsequenceRecurstion(str1, str2, m - 1, n - 1);
            else
                return IsSubsequenceRecurstion(str1, str2, m - 1, n);
        }

        private bool IsSubsequence(string str1, string str2)
        {
            int m = str1.Length, n = str2.Length;
            if (n > m)
                return false;
            int i = 0, j = 0;
            while (i < m && j < n)
            {
                if (str1[i] == str2[j])
                {
                    i++;
                    j++;
                }
                else
                    i++;
            }
            return j == n;
        }

        private void PowerSetDemo()
        {
            Console.WriteLine(string.Join(" ", PowerSet("ABC")));
        }

        public string[] PowerSet(string str)
        {
            List<string> powersets = new List<string>();
            GetPowerSets(str, "", powersets, 0);
            powersets.Sort();
            return powersets.ToArray();
        }
        private void GetPowerSets(string str, string subSet, List<string> powersets, int index)
        {
            if (index == str.Length)
            {
                powersets.Add(subSet);
                Console.WriteLine(subSet);
                return;
            }
            GetPowerSets(str, subSet, powersets, index + 1);
            GetPowerSets(str, subSet + str[index], powersets, index + 1);
        }

        private void PalindromeChecking()
        {
            string str = "abccba";
            bool isPol = IsPolindrome(str);
            Console.WriteLine($"{str} - is polindrome : {isPol}");
        }

        private bool IsPolindrome(string str)
        {
            int left = 0, right = str.Length - 1;
            while (left < right)
            {
                if (str[left++] != str[right--]) return false;
            }
            return true;
        }

        private void StringDemoFunction()
        {
            string str1 = "Hello";
            string str2 = "Hello";
            if (str1 == str2)
                Console.WriteLine("str1 and str2 are same");
            else
                Console.WriteLine("str1 and str2 are not same");

            string str3 = new string("Helloa");
            if (str1 == str3)
                Console.WriteLine("str1 and str3 are same");
            else
                Console.WriteLine("str1 and str3 are not same");

            Console.WriteLine(str1.Equals(str2));
            Console.WriteLine(str1.CompareTo(str3));
            Console.WriteLine(str1.IndexOf("lo"));
            Console.WriteLine(str3.Contains("ll"));



            string str = "GeeksForGeeks";
            Console.WriteLine(str.Length);
            Console.WriteLine(str.IndexOf('F'));
            Console.WriteLine(str.Substring(5, 3));
            Console.WriteLine(str.Substring(5));
            Console.WriteLine(str[5]);
            Console.WriteLine();
        }

        private void StringDemoFunction1()
        {
            StringBuilder sb = new StringBuilder("Hello World!");
            Console.WriteLine(sb);

            string message1;
            string message2 = null;
            string message3 = string.Empty;
            string oldPath = "c:\\program files\\hello.exe";
            string newPath = @"c:\progrm files\hello.exe";

            String greeting = "Hello World!";
            var temp = "I'm writing string";
            const string message4 = "this is for testing";
            char[] arr = { 'A', 'B', 'C' };
            string alpha = new string(arr);
        }

        private void ASCIIDemo()
        {
            Console.WriteLine("ASCII");
            for (int i = 0; i < Byte.MaxValue; i++)
            {
                char ch = Convert.ToChar(i);
                if (char.IsLetterOrDigit(ch))
                    Console.Write($"{i}-{ch} ");
            }
            Console.WriteLine("UTF-16");
            for (int i = 0; i < UInt16.MaxValue; i++)
            {
                char ch = Convert.ToChar(i);
                if (char.IsLetterOrDigit(ch))
                    Console.Write($"{i}-{ch} ");
            }
        }
    }
}

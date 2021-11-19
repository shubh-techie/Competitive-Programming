using System;
using System.Collections.Generic;

namespace GeeksForGeeks.StackDemo
{
    public class StackHelper
    {
        public StackHelper()
        {
            //MyStackSolutionDemo();
            //StackDSDemo();
            IsBalancedParenthesisDemo();
        }

        private void IsBalancedParenthesisDemo()
        {
            Console.WriteLine(IsBalancedParenthesis("([])"));
        }

        private bool IsBalancedParenthesis(string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            Stack<char> stack = new Stack<char>();

            foreach (char ch in str)
            {
                switch (ch)
                {
                    case '(':
                        stack.Push(')');
                        break;
                    case '{':
                        stack.Push('}');
                        break;
                    case '[':
                        stack.Push(']');
                        break;
                    default:
                        if (stack.Count == 0 || stack.Pop() != ch) return false;
                        break;
                }
            }

            return stack.Count == 0;
        }

        private bool IsBalancedParenthesis1(string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            Stack<char> track = new Stack<char>();
            foreach (var item in str)
            {
                if (item == ')' || item == '}' || item == ']')
                {
                    if (track.Count == 0 || !isMatching(track.Peek(), item)) return false;
                    track.Pop();
                }
                else track.Push(item);
            }

            return track.Count == 0;
        }

        private bool isMatching(char open, char close)
        {
            return ((close == '}' && open == '{') || (close == ']' && open == '[') || (close == ')' && open == '('));
        }

        private void StackDSDemo()
        {
            Stack<int> stack = new Stack<int>();
            Console.WriteLine(stack.Pop());
            stack.Push(100);
            stack.Push(200);
            stack.Push(300);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            stack.Push(400);
            stack.Push(500);
            stack.Push(600);
            stack.Push(700);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Count == 0);
            Console.WriteLine(stack.Count);

        }

        private void MyStackSolutionDemo()
        {
            MyStack<int> myStack = new MyStack<int>(3);
            Console.WriteLine(myStack.Pull());
            myStack.Push(100);
            myStack.Push(200);
            myStack.Push(300);
            Console.WriteLine(myStack.Pull());
            Console.WriteLine(myStack.Pull());
            myStack.Push(400);
            myStack.Push(500);
            myStack.Push(600);
            myStack.Push(700);
            Console.WriteLine(myStack.Pull());
            Console.WriteLine(myStack.IsEmpty());
            Console.WriteLine(myStack.Count);
        }
    }
}

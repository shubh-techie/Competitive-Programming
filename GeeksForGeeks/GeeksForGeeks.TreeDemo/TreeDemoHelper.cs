using System;
using System.Collections.Generic;

namespace GeeksForGeeks.TreeDemo
{
    public class TreeDemoHelper
    {
        public TreeDemoHelper()
        {
            BinaryNode root = BinaryTreeUtility.GetTreeRoot();
            //PrintBinaryTreeUsingIterative(root);
            //ShowAllTraversalOperation(root);
            //PrintKthPosition(root);
            zigZagTraversal(root);
        }

        public List<int> zigZagTraversal(BinaryNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
                return result;

            Queue<BinaryNode> queue = new Queue<BinaryNode>();
            queue.Enqueue(root);
            int level = 0;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                bool odd = false;
                for (int i = 0; i < count; i++)
                {
                    BinaryNode curr = queue.Dequeue();
                    Stack<int> temp = new Stack<int>();
                    if (level % 2 == 0)
                    {

                        result.Add(curr.Data);
                    }
                    else
                    {
                        odd = true;
                        temp.Push(curr.Data);
                    }

                    if (odd)
                    {
                        while (temp.Count > 0)
                            result.Add(temp.Pop());
                    }

                    if (curr.Left != null)
                        queue.Enqueue(curr.Left);
                    if (curr.Right != null)
                        queue.Enqueue(curr.Right);
                }

                level++;
            }


            return result;
        }

        private void PrintBinaryTreeUsingIterative(BinaryNode root)
        {
            Console.WriteLine();
            Console.WriteLine("in Order iterative");
            InOrder(root);
            Console.WriteLine("-------------------");
            InOrderIterative(root);

            Console.WriteLine();
            Console.WriteLine("Pre order iterative.");
            PreOrder(root);
            Console.WriteLine("-------------------");
            PreOrderIterative(root);

            Console.WriteLine();
            Console.WriteLine("Post Order iterative");
            postOrder(root);
            Console.WriteLine("-------------------");
            PostOrderIterative(root);
            Console.WriteLine();
        }
        private void InOrderIterative(BinaryNode root)
        {
            Stack<BinaryNode> stack = new Stack<BinaryNode>();
            BinaryNode currNode = root;
            while (currNode != null || stack.Count > 0)
            {
                if (currNode != null)
                {
                    stack.Push(currNode);
                    currNode = currNode.Left;
                }
                else
                {
                    currNode = stack.Pop();
                    Console.Write(currNode.Data + " ");
                    currNode = currNode.Right;
                }
            }
        }

        private void PostOrderIterative(BinaryNode root)
        {
            Stack<BinaryNode> stack = new Stack<BinaryNode>();
            BinaryNode currNode = root;
            List<int> result = new List<int>();
            while (currNode != null || stack.Count > 0)
            {
                if (currNode != null)
                {
                    result.Add(currNode.Data);
                    stack.Push(currNode.Left);
                    currNode = currNode.Right;
                }
                else
                {
                    currNode = stack.Pop();
                }
            }
            result.Reverse();
            Console.WriteLine(string.Join(" ", result));
        }

        private void PreOrderIterative(BinaryNode root)
        {
            Stack<BinaryNode> stack = new Stack<BinaryNode>();
            BinaryNode currNode = root;
            while (currNode != null || stack.Count > 0)
            {
                if (currNode != null)
                {
                    Console.Write(currNode.Data + " ");
                    stack.Push(currNode.Right);
                    currNode = currNode.Left;
                }
                else
                {
                    currNode = stack.Pop();
                }
            }
        }

        private void PrintKthPosition(BinaryNode root)
        {
            PrintKth(root, 2);
        }

        private void PrintKth(BinaryNode root, int k)
        {
            if (root == null) return;
            if (k == 0)
                Console.WriteLine(root.Data);
            PrintKth(root.Left, k - 1);
            PrintKth(root.Right, k - 1);
        }

        private void ShowAllTraversalOperation(BinaryNode root)
        {
            Console.WriteLine();
            Console.WriteLine("Pre Order.");
            PreOrder(root);
            Console.WriteLine();
            Console.WriteLine("in Order.");
            InOrder(root);
            Console.WriteLine();
            Console.WriteLine("Post Order.");
            postOrder(root);
            Console.WriteLine();
            Console.WriteLine("BFS level traversal.");
            LevelOrderTraversal(root);
        }

        private void LevelOrderTraversal(BinaryNode root)
        {
            Queue<BinaryNode> queue = new Queue<BinaryNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    BinaryNode currNode = queue.Dequeue();
                    if (currNode != null)
                    {
                        Console.Write(currNode.Data + " ");
                        queue.Enqueue(currNode.Left);
                        queue.Enqueue(currNode.Right);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("----");
            }
        }

        private void PreOrder(BinaryNode root)
        {
            if (root != null)
            {
                Console.Write(root.Data + " ");
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
        }

        private void InOrder(BinaryNode root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                Console.Write(root.Data + " ");
                InOrder(root.Right);
            }
        }

        private void postOrder(BinaryNode root)
        {
            if (root != null)
            {
                postOrder(root.Left);
                postOrder(root.Right);
                Console.Write(root.Data + " ");
            }
        }
    }
}

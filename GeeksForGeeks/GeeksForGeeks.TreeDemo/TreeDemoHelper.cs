using System;

namespace GeeksForGeeks.TreeDemo
{
    public class TreeDemoHelper
    {
        public TreeDemoHelper()
        {
            BinaryNode root = BinaryTreeUtility.GetTreeRoot();
            ShowAllTraversalOperation(root);
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

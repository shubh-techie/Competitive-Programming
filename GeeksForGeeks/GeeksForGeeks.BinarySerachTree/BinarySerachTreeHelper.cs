using System;

namespace GeeksForGeeks.BinarySerachTree
{
    public class BinarySerachTreeHelper
    {
        public BinarySerachTreeHelper()
        {
            TreeNode root = GetBinarySearchTree();

            TraversalOfBst(root);
            InsertInBinarySerachTreeDemo(root);
            Console.WriteLine();
            Console.WriteLine("found key :" + SerachBSTDemo(root, 80));
            Console.WriteLine("found key :" + SerachBSTDemoIterative(root, 80));
        }

        private void InsertInBinarySerachTreeDemo(TreeNode root)
        {
            Insert(root, 80);
            Insert(root, 80);
            Insert(root, 100);
            InOrder(root);
        }

        private TreeNode Insert(TreeNode root, int key)
        {
            if (root == null)
                return new TreeNode(key);

            if (key < root.Data)
                root.Left = Insert(root.Left, key);
            else if (key > root.Data)
                root.Right = Insert(root.Right, key);

            return root;
        }

        private TreeNode GetBinarySearchTree()
        {
            TreeNode root = new TreeNode(20)
            {
                Left = new TreeNode(15),
                Right = new TreeNode(35)
            };

            root.Left.Left = new TreeNode(12);
            root.Left.Right = new TreeNode(18);
            root.Right.Left = new TreeNode(30);
            root.Right.Right = new TreeNode(40);

            return root;
        }

        private bool SerachBSTDemo(TreeNode root, int key)
        {
            if (root == null)
                return false;
            if (root != null && root.Data == key)
                return true;

            if (key < root.Data)
                return SerachBSTDemo(root.Left, key);
            else
                return SerachBSTDemo(root.Right, key);
        }

        private bool SerachBSTDemoIterative(TreeNode root, int key)
        {
            if (root == null)
                return false;

            TreeNode currNode = root;
            while (currNode != null)
            {
                if (currNode.Data == key)
                    return true;

                if (key < currNode.Data)
                    currNode = currNode.Left;
                else
                    currNode = currNode.Right;
            }

            return false;
        }

        private void TraversalOfBst(TreeNode root)
        {
            Console.WriteLine("Pre Order");
            PreOrder(root);
            Console.WriteLine();
            Console.WriteLine("In Order");
            InOrder(root);
            Console.WriteLine();
            Console.WriteLine("Post Order");
            PostOrder(root);
            Console.WriteLine();
        }

        private void PreOrder(TreeNode root)
        {
            if (root != null)
            {
                Console.Write(root.Data + " ");
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
        }
        private void InOrder(TreeNode root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                Console.Write(root.Data + " ");
                InOrder(root.Right);
            }
        }

        private void PostOrder(TreeNode root)
        {
            if (root != null)
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                Console.Write(root.Data + " ");
            }
        }
    }
}

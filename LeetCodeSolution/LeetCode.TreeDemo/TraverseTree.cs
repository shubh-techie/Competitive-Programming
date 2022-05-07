using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.TreeDemo
{
    public class TraverseBinaryTree
    {
        public void PreOrder(TreeNode root)
        {
            if (root != null)
            {
                Console.WriteLine(root.val);
                PreOrder(root.left);
                PreOrder(root.right);
            }
        }

        public void InOrder(TreeNode root)
        {
            if (root != null)
            {
                InOrder(root.left);
                Console.WriteLine(root.val);
                InOrder(root.right);
            }
        }

        public void PostOrder(TreeNode root)
        {
            if (root != null)
            {
                PostOrder(root.left);
                PostOrder(root.right);
                Console.WriteLine(root.val);
            }
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            IList<int> result = new List<int>();
            if (root == null) return result;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            TreeNode currNode = root;

            while (currNode != null || stack.Count > 0)
            {

                if (currNode != null)
                {
                    result.Add(currNode.val);
                    currNode = currNode.left;
                    stack.Push(currNode.right);
                }
                else if (stack.Count > 0)
                {
                    currNode = stack.Pop();
                }
            }

            return result;
        }

        public IList<int> PostorderTraversal(TreeNode root)
        {
            IList<int> result = new List<int>();
            if (root == null)
                return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode curr = root;
            while (curr != null || stack.Count > 0)
            {
                if (curr != null)
                {
                    result.Add(curr.val);
                    stack.Push(curr.left);
                    curr = curr.right;
                }
                else
                {
                    curr = stack.Pop();
                }
            }

            return result.Reverse().ToList();
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int counter = queue.Count;
                List<int> temp = new List<int>();
                for (int i = 0; i < counter; i++)
                {
                    TreeNode currNode = queue.Dequeue();
                    temp.Add(currNode.val);
                    if (currNode.left != null)
                        queue.Enqueue(currNode.left);
                    if (currNode.right != null)
                        queue.Enqueue(currNode.right);
                }
                result.Add(temp);
            }

            return result;
        }

        int key;
        public int CountUnivalSubtrees(TreeNode root)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            CountUnivalSubtreesHelper(root, map);
            return key;
        }

        private void CountUnivalSubtreesHelper(TreeNode root, Dictionary<int, int> map)
        {
            if (root == null)
                return;
            map[root.val]++;
            key = Math.Max(key, map[root.val]);
            CountUnivalSubtreesHelper(root.left, map);
            CountUnivalSubtreesHelper(root.right, map);
        }
    }
}

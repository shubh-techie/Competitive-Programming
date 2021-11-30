using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.TreeDemo
{
    public class BinaryTreeUtility
    {
        public static BinaryNode GetTreeRoot()
        {
            BinaryNode root = new(10)
            {
                Left = new BinaryNode(20),
                Right = new BinaryNode(30)
            };

            root.Left.Left = new BinaryNode(40);
            root.Left.Right = new BinaryNode(50);

            root.Right.Left = new BinaryNode(60);
            root.Right.Right = new BinaryNode(70);

            return root;
        }
    }
}

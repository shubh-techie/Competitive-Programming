using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.BinarySerachTree
{
    public class TreeNode
    {
        public TreeNode Left;

        public TreeNode Right;
        public int Data { get; set; }
        public TreeNode(int data)
        {
            this.Data = data;
            Left = Right = null;
        }
    }
}

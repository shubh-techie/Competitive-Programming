using System;

namespace GeeksForGeeks.LinkListDemo
{
    public class ListNode
    {
        public int Value;
        public ListNode Next;
        public ListNode(int value)
        {
            this.Value = value;
            this.Next = null;
        }

        public static void Print(ListNode head)
        {
            while (head != null)
            {
                Console.Write(head.Value + " ");
                head = head.Next;
            }
            Console.WriteLine();
        }

        public ListNode InsertAtBeginning(ListNode head, int x)
        {
            ListNode newNode = new ListNode(x);
            if (head == null)
                return newNode;

            newNode.Next = head;
            return newNode;
        }

        public ListNode InsertAtEnd(ListNode head, int x)
        {
            ListNode newNode = new ListNode(x);
            if (head == null)
                return newNode;

            ListNode curr = head;
            while (curr.Next != null)
            {
                curr = curr.Next;
            }
            curr.Next = newNode;
            return head;
        }

        public ListNode DeleteHead(ListNode head)
        {
            if (head == null || head.Next == null) return null;
            return head.Next;
        }

        public ListNode DeleteLast(ListNode head)
        {
            if (head == null || head.Next == null) return null;
            ListNode curr = head;
            while (curr.Next != null)
            {
                curr = curr.Next;
            }
            curr = null;
            return head;
        }

        public ListNode InsertAtEnd(ListNode head, int x, int position)
        {
            ListNode newNode = new ListNode(x);
            if (position == 0)
                return newNode;

            ListNode curr = head;
            while (position > 0)
            {
                curr = curr.Next;
                position--;
            }
            if (curr == null)
                return head;
            newNode.Next = curr.Next;
            curr.Next = newNode;
            return head;
        }

        public int Search(ListNode head, int x)
        {
            if (head == null) return -1;
            if (head.Value == x) return 1;
            int position = 0;
            while (head.Next != null)
            {
                if (head.Value == x)
                    return position;
                position++;
            }
            return -1;
        }
    }
}

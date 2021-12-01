using System;

namespace GeeksForGeeks.LinkListDemo
{
    public interface IDoubleLinkList
    {
        public DoubleLinkListNode InsertBegin(int x);
        public DoubleLinkListNode InsertEnd(int x);
        public DoubleLinkListNode InsertAtPosition(int x);
        public DoubleLinkListNode InsertMiddle(int x);
    }
    public class DoubleLinkListNode
    {
        public DoubleLinkListNode Prev;
        public int Value;
        public DoubleLinkListNode Next;
        public DoubleLinkListNode(int value)
        {
            Prev = null;
            Next = null;
            this.Value = value;
        }
    }

    public class DoubleLinkList : IDoubleLinkList
    {
        DoubleLinkListNode Head;
        public DoubleLinkList()
        {
        }
        public DoubleLinkListNode InsertAtPosition(int x)
        {
            throw new NotImplementedException();

        }

        public DoubleLinkListNode InsertBegin(int x)
        {
            DoubleLinkListNode temp = new DoubleLinkListNode(x);
            temp.Next = Head;
            if (Head != null)
                Head.Prev = temp;
            return temp;
        }

        public DoubleLinkListNode InsertEnd(int x)
        {
            DoubleLinkListNode temp = new DoubleLinkListNode(x);
            if (Head == null)
                return temp;

            DoubleLinkListNode curr = Head;
            while (curr.Next != null)
            {
                curr = curr.Next;
            }

            curr.Next = temp;
            temp.Prev = curr;

            return Head;
        }

        public DoubleLinkListNode InsertMiddle(int x)
        {
            throw new NotImplementedException();
        }

        public void AddNode(DoubleLinkListNode head, int pos, int data)
        {
            DoubleLinkListNode newNode = new DoubleLinkListNode(data);
            DoubleLinkListNode curr = head;
            while (pos > 0)
            {
                curr = curr.Next;
                pos--;
            }
            newNode.Next = curr.Next;
            newNode.Prev = curr;
            curr.Next = newNode;
            if (newNode.Next != null)
                curr.Next.Prev = newNode;
        }

    }
}

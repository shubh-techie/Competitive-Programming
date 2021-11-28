using System;

namespace GeeksForGeeks.StackDemo
{
    class MyStack<T>
    {
        T[] list;
        int Size;
        public int Count { get; set; }

        public MyStack(int size)
        {
            this.Size = size;
            this.Count = 0;
            list = new T[this.Size];
        }
        public void Push(T no)
        {
            if (IsFull()) throw new Exception("Stack is overflow");
            list[Size] = no;
            Count++;
        }

        public T Pull()
        {
            if (IsEmpty()) throw new Exception("Stack is underflow.");
            this.Count--;
            T tempNumber = list[Count];
            return tempNumber;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new Exception("Stack is underflow.");
            return list[Count];
        }

        public bool IsFull()
        {
            return this.Count == this.Size;
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }
    }
}

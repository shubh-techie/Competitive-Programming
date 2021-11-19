using System;
using System.Collections.Generic;

namespace GeeksForGeeks.QueueDemo
{
    public class QueueHelper
    {
        public QueueHelper()
        {
            CSharpQueueDemo();
        }

        private void CSharpQueueDemo()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(100);
            queue.Dequeue();
            queue.Peek();
        }
    }
}

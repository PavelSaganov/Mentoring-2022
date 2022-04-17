using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        public DoublyLinkedList<T> DoublyLinkedList { get; set; } = new DoublyLinkedList<T>();

        public T Dequeue()
        {
            if (DoublyLinkedList.Length <= 0)
                throw new InvalidOperationException();

            return DoublyLinkedList.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            DoublyLinkedList.Add(item);
        }

        public T Pop()
        {
            if (DoublyLinkedList.Length <= 0)
                throw new InvalidOperationException();

            return DoublyLinkedList.ElementAt(DoublyLinkedList.Length - 1);
        }

        public void Push(T item)
        {
            DoublyLinkedList.Add(item);
        }
    }
}

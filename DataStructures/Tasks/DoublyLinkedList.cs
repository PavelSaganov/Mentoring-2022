using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>, IEnumerable<T>
    {
        private DoublyLinkedListNode<T> Head { get; set; }

        public int Length
        {
            get
            {
                var node = Head;
                int countOfNodes = 0;

                while (node != null)
                {
                    node = node.Next;
                    countOfNodes++;
                }
                return countOfNodes;
            }
        }

        public void Add(T e)
        {
            DoublyLinkedListNode<T> previousNode = null;
            var node = Head;

            while (node != null)
            {
                previousNode = node;
                node = node.Next;
            }

            if (Head == null)
            {
                Head = new DoublyLinkedListNode<T>(e);
                Head.Data = e;
            }
            else if (node == null)
            {
                node = new DoublyLinkedListNode<T>(e);
                node.Previous = previousNode;
                previousNode.Next = node;
            }
            else
            {
                node.Data = e;
            }
        }

        public void AddAt(int index, T e)
        {
            DoublyLinkedListNode<T> previousNode = null;
            var node = Head;

            for (int i = 0; i < index; i++)
            {
                previousNode = node;
                node = node.Next;
            }

            if (Head == null)
            {
                Head = new DoublyLinkedListNode<T>(e);
                Head.Data = e;
            }
            else if (node == null)
            {
                node = new DoublyLinkedListNode<T>(e);
                node.Previous = previousNode;
                previousNode.Next = node;
                node.Data = e;
            }
            else
            {
                node.Data = e;
            }
        }

        public T ElementAt(int index)
        {
            var node = Head;

            if (index < 0 || index >= Length || node == null)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node.Data;
        }

        public void Remove(T item)
        {
            DoublyLinkedListNode<T> previousNode = null;
            var node = Head;

            while (node != null && !node.Data.Equals(item))
            {
                previousNode = node;
                node = node.Next;
            }

            if (previousNode == null)
            {
                Head = Head.Next;
                Head.Previous = null;
            }
        }

        public T RemoveAt(int index)
        {
            DoublyLinkedListNode<T> previousNode = null;
            var node = Head;

            if (index < 0 || index >= Length || node == null)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Previous = previousNode;
            }

            if (previousNode != null)
            {
                previousNode.Next = node.Next;
            }
            return Head.Data;
        }

        private DoublyLinkedList<T> GetNodeAt(int index)
        {
            var node = this;

            for (int i = 0; i < index; i++)
            {
                if (node == null)
                {
                    throw new IndexOutOfRangeException();
                }

                //node = node.Next;
            }

            return node;
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;
using Tasks.Enumerators;

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
            var node = Head;

            if (Head == null)
                return;

            if (Head.Data.Equals(item))
            {
                Head.Next.Previous = null;
                Head = Head.Next;
            }

            while (node.Next != null && !node.Data.Equals(item))
            {
                if (node.Next.Data.Equals(item))
                {
                    if (node.Next.Next != null)
                    {
                        node.Next.Next.Previous = node;
                    }

                    node.Next = node.Next.Next;
                }
                else node = node.Next;
            }
        }

        public T RemoveAt(int index)
        {
            if (Head == null)
            {
                throw new IndexOutOfRangeException();
            }

            T returnedData = Head.Data;
            DoublyLinkedListNode<T> previousNode = null;
            var node = Head;

            if (index < 0 || index >= Length || node == null)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
                returnedData = node.Data;
            }

            if (node.Next != null)
            {
                node.Next.Previous = previousNode;
            }
            else
            {
                node.Previous.Next = null;
            }

            if (previousNode != null)
            {
                previousNode.Next = node.Next;
            }
            return returnedData;
        }

        private DoublyLinkedListNode<T> GetNodeAt(int index)
        {
            if (Head == null || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            var node = Head;

            for (int i = 0; i < index; i++)
            {
                if (node == null)
                {
                    throw new IndexOutOfRangeException();
                }
            }

            return node;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

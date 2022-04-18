using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;
using Tasks.Enumerators;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private DoublyLinkedListNode<T> Head { get; set; }

        private DoublyLinkedListNode<T> Tail { get; set; }

        public int Length { get; private set; } = 0;

        public void Add(T e)
        {
            var newNode = new DoublyLinkedListNode<T>(e);

            if (Head == null)
            {
                Head = newNode;
                Tail = Head;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Previous = Tail;
            }

            UpdateTail();
            UpdateLength();
        }

        public void AddAt(int index, T e)
        {
            var newNode = new DoublyLinkedListNode<T>(e);
            var node = GetNodeAt(index);

            if (index == 0)
            {
                Head = new DoublyLinkedListNode<T>(e);
                UpdateLength();
                UpdateTail();
                return;
            }

            if (node == null)
            {
                var prevNode = GetNodeAt(index - 1);
                prevNode.Next = newNode;
                UpdateLength();
                UpdateTail();
                return;
            }

            if (node.Previous != null)
            {
                newNode.Next = node.Previous.Next;
                node.Previous.Next = newNode;
            }

            if (newNode.Next != null)
            {
                newNode.Next.Previous = newNode;
            }
            newNode.Previous = node.Previous;
            node.Data = newNode.Data;

            UpdateLength();
            UpdateTail();
        }

        public T ElementAt(int index)
        {
            ValidateIndex(index);
            var node = GetNodeAt(index);
            return node.Data;
        }

        public void Remove(T item)
        {
            RemoveNode(Head, item);
            UpdateLength();
            UpdateTail();
        }

        public T RemoveAt(int index)
        {
            ValidateIndex(index);
            var node = GetNodeAt(index);
            var returnedData = RemoveNode(node, node.Data);
            
            UpdateLength();
            UpdateTail();
            return returnedData;
        }

        private T RemoveNode(DoublyLinkedListNode<T> firstNode, T item)
        {
            var returnedData = firstNode.Data;
            if (firstNode != null && firstNode.Data.Equals(item))
            {
                if (firstNode.Next != null)
                {
                    firstNode.Next.Previous = firstNode.Previous;
                }
                if (firstNode.Previous != null)
                {
                    firstNode.Previous.Next = firstNode.Next;
                }
                else
                {
                    Head = firstNode.Next;
                }

                return returnedData;
            }
            while (firstNode != null && !firstNode.Data.Equals(item))
            {
                firstNode = firstNode.Next;
            }
            if (firstNode == null)
            {
                return returnedData;
            }
            if (firstNode.Next != null)
            {
                firstNode.Next.Previous = firstNode.Previous;
            }
            if (firstNode.Previous != null)
            {
                firstNode.Previous.Next = firstNode.Next;
            }

            return returnedData;
        }

        private DoublyLinkedListNode<T> GetNodeAt(int index)
        {
            var node = Head;

            if (node == null)
            {
                return Head;
            }

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node;
        }

        private void ValidateIndex(int index)
        {
            if (Head == null || index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void UpdateLength()
        {
            var node = Head;
            int countOfNodes = 0;

            while (node != null)
            {
                node = node.Next;
                countOfNodes++;
            }
            Length = countOfNodes;
        }

        private void UpdateTail()
        {
            var temp = Head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            Tail = temp;
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

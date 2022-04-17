using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Enumerators
{
    public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
    {
        public DoublyLinkedList<T> _doublyLinkedList;

        private int position = -1;

        public DoublyLinkedListEnumerator(DoublyLinkedList<T> list)
        {
            _doublyLinkedList = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _doublyLinkedList.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public T Current
        {
            get
            {
                try
                {
                    return _doublyLinkedList.ElementAt(position);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void Dispose()
        {

        }
    }
}

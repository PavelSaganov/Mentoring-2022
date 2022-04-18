namespace Tasks
{
    public class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public DoublyLinkedListNode<T> Next { get; set; }

        public DoublyLinkedListNode<T> Previous { get; set; }
    }
}

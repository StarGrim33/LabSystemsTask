namespace FileReader
{
    internal class Node<T>
    {
        public T Data { get; set; }

        public Node<T> Next { get; set; }
    }

    internal class LinkedList<T>
    {
        private Node<T> _head;

        public void Add(T data)
        {
            Node<T> newNode = new() { Data = data };

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                Node<T> current = _head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }
        }

        public Node<T> Find(Func<T, bool> predicate)
        {
            Node<T> current = _head;

            while (current != null)
            {
                if (predicate(current.Data))
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        public void ForEach(Action<T> action)
        {
            Node<T> current = _head;

            while (current != null)
            {
                action(current.Data);
                current = current.Next;
            }
        }

        public List<T> ToList()
        {
            List<T> list = [];
            Node<T> current = _head;

            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }

            return list;
        }
    }
}

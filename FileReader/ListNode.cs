namespace FileReader
{
    internal class ListNode
    {
        public string Data { get; set; }

        public ListNode Next { get; set; }
    }

    internal class LinkedList
    {
        private ListNode _head;

        public void Add(string data)
        {
            ListNode newNode = new(){ Data = data };

            if(_head == null)
            {
                _head = newNode;
            }
            else
            {
                ListNode current = _head;

                while(current.Next != null) 
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }
        }

        public List<string> ToList()
        {
            List<string> list = [];
            ListNode current = _head;

            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }

            return list;
        }
    }
}

namespace Algorithms.data_structures
{
    public class Stack
    {
        private readonly LinkedList list;

        private int count;

        public int Count { get => count; set => count = value; }

        public Stack()
        {
            list = new LinkedList();
            Count = 0;
        }

        public void Push(object value)
        {
            Count++;
            //empty list, add a new node
            if (list.Head == null)
            {
                list.Head = new ListNode(value);
            }
            else
            {
                //replace head with the new node and point its next value to the new node
                var currentHead = list.Head;
                list.Head = new ListNode(value);
                list.Head.Next = currentHead;
            }

        }

        public object Peek()
        {
            return list.Head?.Value;
        }

        public object Pop()
        {
            Count--;
            var headValue = list.Head?.Value;

            list.Head = list.Head?.Next;

            return headValue;
        }
    }
}

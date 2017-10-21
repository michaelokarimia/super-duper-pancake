namespace Algorithms.data_structures
{
    public class Queue
    {
        private LinkedList list;

        public int count { get; private set; }

        public Queue()
        {
            list = new LinkedList();
            this.count = 0;
        }

        public void Enqueue(object value)
        {
            list.Append(value);
            count++;
        }

        public object Peek()
        {
            if (list.Head != null)
            {
                return list.Head.Value;
            }
            else
            {
                return null;
            }

        }

        public object Dequeue()
        {
            var headValue = this.Peek();

            if (headValue != null)
            {
                count--;
                list.Remove(list.Head);
            }
            return headValue;
        }
    }
}
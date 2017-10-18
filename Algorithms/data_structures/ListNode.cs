namespace Algorithms.data_structures
{
    public class ListNode
    {
        public ListNode(object value)
        {
            this.Value = value;
            this.Next = null;
        }

        public ListNode(int value, ListNode next)
        {
            this.Value = value;
            Next = next;
        }

        public object Value { get; }
        public ListNode Next { get; set; }

        public ListNode AddNext(int val)
        {
            this.Next = new ListNode(val);
            return this.Next;
        }

    }
}

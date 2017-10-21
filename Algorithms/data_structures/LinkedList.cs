using System;
using System.Text;

namespace Algorithms.data_structures
{
    public class LinkedList
    {
        public ListNode Head { get; set; }

        public ListNode Traverse(Func<ListNode, bool> expression)
        {
            var current = this.Head;
            ListNode last = null;

            while (current != null)
            {
                var result = expression(current);
                last = current;
                current = current.Next;
                if (result)
                { break; }
            }

            return last;
        }

        public ListNode Append(object value)
        {
            var insertNode = new ListNode(value);

            //if list is empty insert new node at head
            if (this.Head == null)
            {
                this.Head = insertNode;
            }
            else
            {
                //traverse list to get to the end, and insert new node there
                var lastNode = this.Traverse((n) => n.Next == null);
                lastNode.Next = insertNode;
            }

            return insertNode;
        }

        public void Remove(ListNode itemToRemove)
        {
            //check if head value is the node to remove
            if (this.Head.Value.Equals(itemToRemove.Value))
            {
                this.Head = Head.Next;
            }
            else
            {
                //traverse through the list until you find the node with your value to remove

                var current = this.Traverse((n) => n.Next.Value == itemToRemove.Value);

                if (current != null)
                {
                    //we have found the node
                    current.Next = current.Next.Next;
                }
            }
        }

        public ListNode InsertAt(ListNode node, int value)
        {
            var insertNode = new ListNode(value, node.Next);

            node.Next = insertNode;

            return insertNode;
        }

        public override string ToString()
        {
            var current = this.Head;

            int counter = 0;
            StringBuilder sb = new StringBuilder();

            while (current != null)
            {
                sb.AppendLine(string.Format("Index: {0}, Value: {1}", counter, current.Value));
                current = current.Next;
                counter++;
            }
            return sb.ToString();

        }

    }

}

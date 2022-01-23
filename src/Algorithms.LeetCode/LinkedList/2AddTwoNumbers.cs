namespace Algorithms.LeetCode.LinkedList
{
    public class AddTwoNumbers
    {
        public ListNode Numbers(ListNode l1, ListNode l2)
        {
            var (value, carry) = Sum(l1, l2, false);
            var result = new ListNode(value);
            var current = result;
            l1 = l1.Next;
            l2 = l2.Next;

            while (l1 != null || l2 != null)
            {
                (value, carry) = Sum(l1, l2, carry);
                current.Next = new ListNode(value);
                current = current.Next;
                l1 = l1?.Next;
                l2 = l2?.Next;
            }
            
            if (carry)
            {
                current.Next = new ListNode(1);
            }

            return result;
        }

        private static (int sum, bool carry) Sum(ListNode l1, ListNode l2, bool carry)
        {
            var value = (l1?.Val ?? 0) + (l2?.Val ?? 0) + (carry ? 1 : 0);

            return value >= 10 ? (value % 10, true) : (value, false);
        }

        public class ListNode
        {
            public int Val { get; }

            public ListNode Next { get; set; }

            public ListNode(int val = 0, ListNode next = null)
            {
                Val = val;
                Next = next;
            }
        }
    }
}
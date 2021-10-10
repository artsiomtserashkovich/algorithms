using System.Collections.Generic;

namespace Algorithms.LeetCode.LinkedList
{
    public class PalindromeLinkedList 
    {
        public bool IsPalindrome(ListNode head) {
            var stack = new Stack<int>();
        
            var fastPointer = head;
            while(fastPointer != null)
            {
                stack.Push(fastPointer.val);
                fastPointer = fastPointer.next;
            }

            var slowPointer = head;
            
            while(slowPointer != null)
            {
                var val = stack.Pop();
                if (val != slowPointer.val)
                {
                    return false;
                }
                slowPointer = slowPointer.next;
            }

            return true;
        }
        
        public bool IsPalindromeV2(ListNode head)
        {
            ListNode reverse = null;
            var slowPointer = head;
            var fastPointer = head;
            while(fastPointer != null && fastPointer.next != null)
            {
                var temp = slowPointer;
                slowPointer = slowPointer.next;
                temp.next = reverse;
                reverse = temp;

                fastPointer = fastPointer.next.next;
            }

            if (fastPointer != null)
            {
                slowPointer = slowPointer.next;
            }

            while(reverse != null && reverse.val == slowPointer.val)
            {
                reverse = reverse.next;
                slowPointer = slowPointer.next;
            }

            return reverse == null;
        }

        private static ListNode Reverse(ListNode head)
        {
            var iterator = head;
            var previous = head;
            
            
            while(iterator != null)
            {
                var next = iterator.next;
                
                iterator.next = previous;
                previous = iterator;
                iterator = next; 
            }

            return iterator; 
        }
        
        public class ListNode {
           public int val;
                 public ListNode next;
                 public ListNode(int val=0, ListNode next=null) {
                     this.val = val;
                     this.next = next;
                 }
        }
    }
}
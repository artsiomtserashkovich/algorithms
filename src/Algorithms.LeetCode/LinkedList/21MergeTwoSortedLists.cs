namespace Algorithms.LeetCode.LinkedList
{
    public class MergeTwoSortedLists 
    {
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
    
        public ListNode MergeTwoLists(ListNode list1, ListNode list2) 
        {
            if(list1 == null && list2 == null)
            {
                return null;
            }
        
            ListNode GetLowestAndIterate()
            {
                ListNode lowest;
            
                if(
                    (list1 != null && list2 == null) 
                    || 
                    (list1 != null && list1.Val < list2.Val))
                {
                    lowest = list1;
                    list1 = list1.Next;
                }
                else
                {
                    lowest = list2;
                    list2 = list2.Next;
                }
                
                return lowest;
            }
        
            var result = GetLowestAndIterate();
            var iterator = result;
        
            while(list1 != null || list2 != null)
            {
                iterator.Next = GetLowestAndIterate();
                iterator = iterator.Next;
            }
            
            return result;
        }

        public ListNode MergeTwoListsRec(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            if (list1.Val > list2.Val)
            {
                list2.Next = MergeTwoListsRec(list1, list2.Next);
                return list2;
            }
            else
            {
                list1.Next = MergeTwoListsRec(list1.Next, list2);
                return list1;
            }
        }
    }
}
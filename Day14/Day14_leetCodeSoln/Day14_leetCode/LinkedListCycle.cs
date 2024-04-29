using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}

public class Linked_list_Cycle
{
    public async Task<bool> HasCycle(ListNode head)
    {
        HashSet<ListNode> visited = new HashSet<ListNode>();

        while (head != null)
        {
            if (visited.Contains(head))
            {
                return true;
            }
            else
            {
                visited.Add(head);
                head = head.next;
            }
        }

        return false;
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        Linked_list_Cycle solution = new Linked_list_Cycle();

        ListNode head1 = new ListNode(3);
        ListNode node1 = new ListNode(2);
        ListNode node2 = new ListNode(0);
        ListNode node3 = new ListNode(-4);

        head1.next = node1;
        node1.next = node2;
        node2.next = node3;
        node3.next = node1;

        bool hasCycle = await solution.HasCycle(head1);
        Console.WriteLine("Does the linked list have a cycle? " + hasCycle);
    }
}

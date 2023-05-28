using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            
            ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(5)));
            ListNode l2 = new ListNode(3, new ListNode(4, new ListNode(9)));
            DateTime now = DateTime.Now;
            SumOfTwoLists s = new SumOfTwoLists();
            ListNode l = s.SumTwo(l1, l2);
            DateTime end = DateTime.Now;
            while (l.Next != null)
            {
                Console.WriteLine(l.Value.ToString());
                l = l.Next;
            }
            Console.WriteLine(l.Value);
            
            Console.WriteLine("\n");
            Console.WriteLine(end - now);
            Console.ReadLine();
        }
    }
}

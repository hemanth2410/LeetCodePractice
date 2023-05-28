using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    public class SumOfTwoLists
    {
        LinkedList<int> resultList = new LinkedList<int> ();


        public LinkedList<int> SumTwoLists(LinkedList<int> list1, LinkedList<int> list2)
        {
            int lastCarry = 0;
            int maxLength = Math.Max (list1.Count, list2.Count);
            LinkedList<int> shortest = list1.Count == maxLength ? list2 : list1;
            LinkedList<int> longest = list1.Count == maxLength ? list1 : list2;
            int missing = maxLength - shortest.Count;
            for (int i = 0; i < missing; i++)
            {
                shortest.AddLast(0);
            }
            int[] longestArray = longest.ToArray ();
            int[] shortestArray = shortest.ToArray ();
            for (int i = 0; i < maxLength; i++)
            {
                longestArray[i] += lastCarry;
                LinkedListNode<int> l1 = new LinkedListNode<int>(longestArray[i]);
                LinkedListNode<int> l2 = new LinkedListNode<int>(shortestArray[i]);

                (LinkedListNode<int> n1, int carry) value = SumOfTwoNodes(l1, l2);
                resultList.AddLast(value.n1);
                lastCarry = value.carry;
            }
            if(lastCarry > 0)
            {
                resultList.AddLast(lastCarry);
            }
            return resultList;
        }

        (LinkedListNode<int>,int carry) SumOfTwoNodes(LinkedListNode<int> l1, LinkedListNode<int> l2)
        {
            // Assumpotion  0 <= x <= 9
            // Arrays can very in length
            int nodeValue = l1.Value + l2.Value;
            int remainder = nodeValue % 10;
            int carry = nodeValue / 10;
            return (new LinkedListNode<int>(remainder), carry);
        }

        public ListNode SumTwo(ListNode A, ListNode B)
        {
            //ListNode resultList = new ListNode();
            //int numberA = 0;
            //int numberB = 0;
            //while (A != null || B != null)
            //{ 
            //    if(B!= null)
            //    {
            //        numberB = (numberB * 10) + B.Value;
            //        B = B.Next;
            //    }
            //    if(A!= null)
            //    {
            //        numberA = (numberA * 10) + A.Value;
            //        A = A.Next;
            //    }


            //}
            //int sum = numberA + numberB;
            //int reversedNumber = 0;
            //while (sum != 0)
            //{
            //    reversedNumber = (reversedNumber * 10) + (sum % 10);
            //    sum /= 10;
            //}
            //sum = reversedNumber;
            //while (sum > 0)
            //{

            //    int Value = sum % 10;
            //    resultList = new ListNode(Value, resultList);
            //    sum = sum / 10;
            //}
            //return resultList;

            ListNode resultList = new ListNode();
            ListNode currentNode = resultList;
            int carry = 0;

            while (A != null || B != null || carry != 0)
            {
                int valueA = A != null ? A.Value : 0;
                int valueB = B != null ? B.Value : 0;

                int sum = valueA + valueB + carry;
                carry = sum / 10;

                currentNode.Next = new ListNode(sum % 10);
                currentNode = currentNode.Next;

                if (A != null)
                    A = A.Next;

                if (B != null)
                    B = B.Next;
            }

            return resultList.Next;
        }

        (int sum, int carry) calculate(int value1, int value2, int carry)
        {
            int temp = value1 + value2 + carry;
            int sum = temp % 10;
            int _carry = temp / 10;
            return(sum, _carry);
        }
    }

    public class ListNode
    {
        public int Value;
        public ListNode Next;
        public ListNode(int Value = 0, ListNode Next = null)
        {
            this.Value = Value;
            this.Next = Next;
        }
    }
}

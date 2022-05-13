using System;

namespace Linkedlist
{
    class LinkedListNode
    {
        public int data;
        public LinkedListNode next;
        public LinkedListNode(int value)
        {
            data = value;
            next = null;
        }
    }

    class LinkedList
    {

        int listSize;
        LinkedListNode head = null;

        public LinkedList()
        {
            this.head = null;
            listSize = 0;
        }

       public void  addEnd(LinkedListNode inputNode)
        {
            LinkedListNode node = inputNode;
            LinkedListNode current;

            //if the list(head) is empty Insert First Element
            if (head == null)
            {
                //this.head = node;
                this.head = inputNode;

                
            }else
            {
                //if the list(head) has already value, we start traversing the list from the beginning(head)
                current = head;

                while(current.next != null)
                {
                    //current take the value from next element
                    current = current.next;
                    
                }

                //Add to current variable which contain the  last element,  the next node in its property next
                current.next = inputNode;
                
            }

            //increase size with ++
            listSize++;

        }
       

        public void printList()
        {
            LinkedListNode current = head;
            while(current.next != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
               
            }
            //last element
            Console.WriteLine(current.data);
        }

        
    }



    class Program
    {
        static void Main(string[] args)
        {

            LinkedListNode node = new LinkedListNode(1);
            LinkedListNode node2 = new LinkedListNode(2);
          

            LinkedList list = new LinkedList();
            list.addEnd(node);
            list.addEnd(node2);
            list.printList();
            Console.WriteLine("\n");
          

        }
    }
}

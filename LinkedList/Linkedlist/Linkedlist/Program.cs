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

        public void addEnd(LinkedListNode inputNode)
        {
            LinkedListNode node = inputNode;
            LinkedListNode current;

            //if the list(head) is empty Insert First Element
            if (head == null)
            {
                //this.head = node;
                this.head = inputNode;


            }
            else
            {
                //if the list(head) has already value, we start traversing the list from the beginning(head)
                current = head;

                while (current.next != null)
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
        //Insert an element at a specific location
        public bool insert(int position, LinkedListNode inputNode)
        {
            //if it is not valid range
            if (position < 0 || position > listSize)
            {
                return false;
            }

            LinkedListNode current = head;
            LinkedListNode previous = null;
            int index = 0;

            //Agregar un elemento al inicio 
            if (position == 0)
            {
                inputNode.next = current;
                head = inputNode;
            }
            else
            {
                //loop through the list to the specified position
                while (index++ < position)
                {
                    previous = current;
                    current = current.next;
                }

                inputNode.next = current;
                previous.next = inputNode;

            }

            listSize++;
            return true;

        }

        public LinkedListNode removeAt(int position)
        {
            //valid the range
            if (position < 0 || position >= listSize)
            {
                return null;
            }

            LinkedListNode current = head;
            LinkedListNode previous = null;
            int index = 0;

            //if it is 0
            if (position == 0)
            {
                head = current.next;
            }
            else
            {
                //loop through the list till find the position
                while (index++ < position)
                {
                    previous = current;
                    current = current.next;
                }

                //we bind the previous element with the next of the current (we skip the element to remove it)
                previous.next = current.next;
            }

            listSize--;

            return current;
        }


        public void printList()
        {
            LinkedListNode current = head;
            while (current.next != null)
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
            LinkedListNode node3 = new LinkedListNode(3);

            LinkedList list = new LinkedList();
            list.addEnd(node);
            list.addEnd(node2);
            list.printList();
            Console.WriteLine("\n");
            //Insert specific index
            list.insert(2, node3);
            list.printList();
            Console.WriteLine("\n");
            //Deleteat indix position
            list.removeAt(2);
            list.printList();

        }
    }
}

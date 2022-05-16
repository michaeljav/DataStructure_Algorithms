using System;
using System.Collections.Generic;

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
        //LinkedListNode head = null;
        public LinkedListNode head { get; set; }


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
                //last element
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

        public int indexOf(int inputValue)
        {
            LinkedListNode current = head;
            int index = 0;

            while (current != null)
            {
                if (current.data == inputValue)
                {
                    return index;
                }

                index++;
                //Next node
                current = current.next;
            }

            return -1;
        }


        public int removeByValue(int inputValue)
        {
            int indexofElement = indexOf(inputValue);
            if (indexofElement < 0)
            {
                return indexofElement;
            }
            return removeAt(indexofElement).data;

        }

        public bool hasElelement()
        {
            return listSize > 0;
        }

        public int size()
        {
            return listSize;
        }

        public void printList()
        {
            LinkedListNode current = head;
            string result = "";
            while (current != null)
            {

                result += current.next != null ? current.data + "-->" : current.data + "";
                current = current.next;

            }
            Console.WriteLine(result);

        }

        //recursively
        public void printListRecursiveLy(LinkedListNode head)
        {
            if (head == null) return;
            Console.WriteLine(head.data);
            printListRecursiveLy(head.next);
        }

        //Linked  return List Values
        public int[] linkedListValues(LinkedListNode head)
        {
            List<int> values = new List<int>();
            LinkedListNode current = head;
            while (current != null)
            {
                values.Add(current.data);
                current = current.next;
            }
            return values.ToArray();

        }


        //Return Sum of values insied Linkedlist
        public int SumList(LinkedListNode head)
        {
            int sum = 0;
            LinkedListNode current = head;

            while (current != null)
            {
                sum += current.data;
                current = current.next;
            }

            return sum;
        }

        //Return Sum of values insied Linkedlist Recursively
        public int SumListRecursively(LinkedListNode head)
        {
            if (head == null) return 0;
            return head.data + SumListRecursively(head.next);
        }

        //return target value from linkedlist
        public bool FindValue(LinkedListNode head, int target)
        {
            LinkedListNode current = head;
            while (current != null)
            {
                if (current.data == target) return true;
                current = current.next;
            }

            return false;

        }

        //return recursively target value from linkedlist
        public bool FindValueRecursively(LinkedListNode head, int target)
        {
            if (head == null) return false;
            if (head.data == target) return true;
            return FindValueRecursively(head.next, target);
        }

        //Return recursively  index from linkedlist
        public int? getIndexRecursively(LinkedListNode head, int index)
        {
            if (head == null) return null;
            if (index == 0) return head.data;
            return getIndexRecursively(head.next, index - 1);
        }

        //Return   index from linkedlist
        public int? getIndex(LinkedListNode head, int index)
        {
            LinkedListNode current = head;

            while (current != null)
            {
                if (index-- == 0) return current.data;
                current = current.next;
            }
            return null;
        }

        //Reverse Linked list
        //1-->2-->3-->null
        //3-->2-->1-->null

        public LinkedListNode ReverseLinkedList(LinkedListNode head)
        {
            LinkedListNode current = head; // current = 1 --> 2 --> null
            LinkedListNode prev_newLinkedlist = null;
            while (current != null)
            {
                //temp from next(2-->3-->null) to null
                LinkedListNode next = current.next;
                //Set null in property  Next  for getting the First node 1--> null
                current.next = prev_newLinkedlist;
                //first node inserted in final list 1--> null
                prev_newLinkedlist = current;
                //Set again from 2--> forward to conitnue the loop
                current = next;
                //   Console.WriteLine(current.data);
                //  current = current.next;

            }

            return prev_newLinkedlist;
        }

        //Reverse Linked list recursively
        public LinkedListNode ReverseLinkedListRecursively(LinkedListNode head, LinkedListNode prev = null)
        {
            if (head == null) return prev;
            LinkedListNode next = head.next;
            head.next = prev;
            return ReverseLinkedListRecursively(next, head);
        }

        //Zipper Linkedlist
        public LinkedListNode ZipperLinkedlist(LinkedListNode head, LinkedListNode head2)
        {

            LinkedListNode tail = head;
            LinkedListNode current = head.next;
            LinkedListNode current2 = head2;
            int count = 0;

            while(current != null && current2 != null)
            {
                //even
                if (count % 2 == 0)
                {
                    tail.next = current2;
                    current2 = current2.next;
                }
                //odd
                else
                {
                    tail.next = current;
                    current = current.next;

                }
                tail = tail.next;                
                count += 1;
            }

            if (current != null)
            {
                tail.next = current;
            }
            if (current2 != null)
            {
                tail.next = current2;
            }
            return head;

        }

        //zipper list recursively
        public LinkedListNode ZipperLinkedlistRecursively(LinkedListNode head, LinkedListNode head2)
        {
            if (head == null && head2 == null) return null;
            if (head == null) return head2;
            if (head2 == null ) return head;

            LinkedListNode next1 = head.next;
            LinkedListNode next2 = head2.next;
             head.next = head2;           
            head2.next = ZipperLinkedlistRecursively(next1, next2);
            return head;
        }



        //bad
        //public LinkedListNode ZipperLinkedlist(LinkedListNode head, LinkedListNode head2)
        //{
        //    LinkedListNode current = head;
        //    LinkedListNode current2 = head2;
        //    LinkedListNode zipper = null;

        //    //get longer
        //    int index = 0;
        //    int index2 = 0;
        //    while (current != null)
        //    {
        //        index+=1;
        //        current = current.next;
        //    }
        //    while (current2 != null)
        //    {
        //        index2 += 1;
        //        current2 = current2.next;
        //    }

        //    if(index >= index2)
        //    {
        //        current = head;
        //        current2 = head2;
        //        while (current != null)
        //        {
        //            zipper = current;
        //            zipper.next = current2;

        //            current2 = current2.next;
        //            current = current.next;
        //        }
        //    }else
        //    {
        //        current = head;
        //        current2 = head2;
        //        while (current2 != null)
        //        {

        //            current2 = current2.next;
        //        }
        //    }



        //    return null;

        //}

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
            //for (int i = 4; i <= 6; i++)
            //{
            //    list.addEnd(new LinkedListNode(i));
            //}

            list.printList();

            Console.WriteLine("Insert element in a index \n");
            //Insert specific index
            list.insert(2, node3);
            list.printList();

            //Console.WriteLine("Remove Element By Index \n");
            ////Deleteat indix position
            //list.removeAt(2);
            //list.printList();

            //Console.WriteLine("Find Index of Value \n");
            ////get  indix  by value
            //Console.WriteLine(list.indexOf(2));

            ////Remove by value
            //Console.WriteLine("Delete by Value \n");
            //Console.WriteLine(list.removeByValue(2));

            //Console.WriteLine("Current element inside the list \n");
            //list.printList();

            //Console.WriteLine("Has element inside the list \n");
            //Console.WriteLine(list.hasElelement());

            //Console.WriteLine("Size \n");
            //Console.WriteLine(list.size());

            //Console.WriteLine("\n Print Recursively \n");
            //list.printListRecursiveLy(list.head);

            //Console.WriteLine("\n Print Array values from list \n");
            //int[] valus = list.linkedListValues(list.head);
            //foreach (var item in valus)
            //{
            //    Console.WriteLine(item);
            //}

            // Console.WriteLine("\n Print Sum  list \n");
            //int sum=list.SumList(list.head);

            //Console.WriteLine("\n Print Sum  list Recursively \n");
            //int sum=list.SumListRecursively(list.head);            
            //Console.WriteLine(sum);

            //Console.WriteLine("\n Find target \n");
            //bool finded = list.FindValue(list.head, 20);
            //Console.WriteLine(finded);


            //Console.WriteLine("\n Find target Recursively \n");
            //bool finded = list.FindValueRecursively(list.head, 1);
            //Console.WriteLine(finded);


            //Console.WriteLine("\n Find value by index  Recursively \n");
            //int? finded = list.getIndexRecursively(list.head, 1);
            //Console.WriteLine(finded);

            //Console.WriteLine("\n Find value by index  \n");
            //int? finded = list.getIndex(list.head, 45);
            //Console.WriteLine(finded);


            //Console.WriteLine("\n Reverse linked list \n");
            //LinkedListNode finded = list.ReverseLinkedList(list.head);        
            //list.printListRecursiveLy(finded);


            //Console.WriteLine("\n Reverse linked list Recursively \n");
            //LinkedListNode finded = list.ReverseLinkedListRecursively(list.head);
            //list.printListRecursiveLy(finded);


            //Zipper list
            //creand second
            LinkedList list2 = new LinkedList();
            for (int i = 6; i <= 10; i++)
            {
                list2.addEnd(new LinkedListNode(i));
            }

            //Console.WriteLine("\n Zipper List \n");
            //LinkedListNode finded = list.ZipperLinkedlist(list.head, list2.head);
            //list.printListRecursiveLy(finded);


            Console.WriteLine("\n Zipper List recursively \n");
            LinkedListNode finded = list.ZipperLinkedlistRecursively(list.head, list2.head);
            list.printListRecursiveLy(finded);
            




        }
    }
}

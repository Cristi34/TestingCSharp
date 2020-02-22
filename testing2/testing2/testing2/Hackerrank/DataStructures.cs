using System;

namespace TestingCSharp.Hackerrank
{
	public class DataStructures
    {
        class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
            }
        }

        static void printLinkedList(SinglyLinkedListNode head)
        {
            if (head != null)
            {
                var node = head;
                while (node != null)
                {
                    Console.WriteLine(node.data);
                    node = node.next;
                }
            }
            Console.ReadLine();
        }

        static SinglyLinkedListNode insertNodeAtTail(SinglyLinkedListNode head, int data)
        {
            var nodeToInsert = new SinglyLinkedListNode(data);
            if (head == null)
            {
                head = nodeToInsert;
            }
            else
            {
                if (head.next == null)
                {
                    head.next = nodeToInsert;
                }
                else
                {
                    var node = head.next;
                    while (node != null)
                    {
                        if (node.next != null)
                        {
                            node = node.next;
                        }
                        else
                        {
                            node.next = nodeToInsert;
                            break;
                        }
                    }
                }
            }

            return head;
        }

        static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
        {
            var nodeToInsert = new SinglyLinkedListNode(data);
            int index = 0;
            if (head == null && position == 0)
            {
                head = nodeToInsert;
            }
            else
            {
                var node = head;
                while (index < position)
                {
                    if (index == position - 1)
                    {
                        var nodeToMove = node.next;
                        nodeToInsert.next = nodeToMove;
                        node.next = nodeToInsert;                        

                        break;
                    }
                    else
                    {
                        index++;
                        node = node.next;
                    }
                }
            }

            return head;
        }

        static SinglyLinkedListNode insertNodeAtHead(SinglyLinkedListNode head, int data)
        {
            var nodeToInsert = new SinglyLinkedListNode(data);
            var node = head;

            if(node == null)
            {
                node = nodeToInsert;
                return node;
            }

            nodeToInsert.next = head;
            return nodeToInsert;            
        }

        static void ReverseLinkedList()
        {

        }

        static SinglyLinkedListNode deleteNode(SinglyLinkedListNode head, int position)
        {
            if (position == 0 && head != null)
            {
                return head.next;
            }            
            int index = 0;
            var node = head;
            while (index < position)
            {
                var nextNode = node.next;
                var nextNode2 = nextNode.next;
                if (index == position - 1)
                {
                    node.next = nextNode2;
                    break;
                }
                index++;
                node = node.next;
            }
            return head;
        }

        // Delete a Node
        public static void TestDeleteNode()
        {
            var filePath = @"D:\hackerrank\Delete-Node.txt";
            SinglyLinkedList llist = new SinglyLinkedList();
            int lineCounter = 0, llistCount = 0, position = 0;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                if (lineCounter == 0)
                {
                    llistCount = Convert.ToInt32(line);
                }
                else if(lineCounter <= llistCount)
                {
                    int llistItem = Convert.ToInt32(line);
                    llist.InsertNode(llistItem);
                }
                else
                {
                    position = Convert.ToInt32(line);
                }
                lineCounter++;
            }

            SinglyLinkedListNode llist1 = deleteNode(llist.head, position);
            printLinkedList(llist1);
        }

        // Insert a Node at the Tail of a Linked List
        public static void TestInsertNodeAtTail()
        {
            var filePath = @"D:\hackerrank\Insert-a-Node-at-the-Tail-of-a-Linked-List.txt";
            SinglyLinkedList llist = new SinglyLinkedList();
            int lineCounter = 0, llistcount;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                if (lineCounter == 0)
                {
                    llistcount = Convert.ToInt32(line);
                }
                else
                {
                    int llistItem = Convert.ToInt32(line);
                    SinglyLinkedListNode llist_head = insertNodeAtTail(llist.head, llistItem);
                    llist.head = llist_head;
                }
                lineCounter++;
            }

            printLinkedList(llist.head);            
        }

        // Insert a node at a specific position in a linked list
        public static void TestInsertNodeAtPosition()
        {
            var filePath = @"D:\hackerrank\Insert-a-node-at-a-specific-position-in-a-linked-list.txt";
            SinglyLinkedList llist = new SinglyLinkedList();
            int lineCounter = 0, llistCount = 0, data = 0, position = 0;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                if (lineCounter == 0)
                {
                    llistCount = Convert.ToInt32(line);
                }
                else if (lineCounter <= llistCount)
                {
                    int llistItem = Convert.ToInt32(line); 
                    llist.InsertNode(llistItem);
                }
                else
                {
                    data = Convert.ToInt32(line);
                    line = file.ReadLine();
                    position = Convert.ToInt32(line);

                    break;
                }
                lineCounter++;
            }

            SinglyLinkedListNode llist_head = insertNodeAtPosition(llist.head, data, position);

            printLinkedList(llist.head);
        }

        // Insert a node at the head of a linked list
        public static void TestInsertNodeAtHead()
        {
            var filePath = @"D:\hackerrank\Insert-a-Node-at-the-Head-of-a-Linked-List.txt";
            SinglyLinkedList llist = new SinglyLinkedList();
            int lineCounter = 0, llistcount;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                if (lineCounter == 0)
                {
                    llistcount = Convert.ToInt32(line);
                }
                else
                {
                    int llistItem = Convert.ToInt32(line);
                    SinglyLinkedListNode llist_head = insertNodeAtHead(llist.head, llistItem);
                    llist.head = llist_head;
                }
                lineCounter++;
            }

            printLinkedList(llist.head);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest
{
    // Getting and Setting  Nodes Value and Data 
    class ListNode
    {
        public string Data
        {
            get; set;
        }

        public ListNode Next
        {
            get; set;
        }

        public ListNode Prev
        {
            get; set;
        }

        public ListNode(string value)
        {
            Data = value;
            Next = null;
            Prev = null;
        }
    }
    
    // Insert|Delete|Print|check if Exist|Menu
    class List
    {
        // initializing the head of the double Linked List
        static ListNode First;

        //check if element exists.
        public static bool CheckExisting(string value)
        {
            ListNode traverse = First;
            do
            {
                if (traverse != null && traverse.Data.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                    return true;

                if (traverse == null || traverse.Next == null) break;
                traverse = traverse.Next;
            } while (traverse != null);

            return false;
        }

        //Insert element after specified element
        public static void InsertNode(string data, string value)
        {
            ListNode node = new ListNode(value);
            if (First == null)
            {
                First = node;
                return;
            }

            ListNode traverse = First;
            bool found = data == null;

            do
            {
                if (data != null)
                {
                    if (traverse.Data.Equals(data, StringComparison.InvariantCultureIgnoreCase))
                    {
                        found = true;
                        break;
                    }
                }
                if (traverse.Next == null) break;
                traverse = traverse.Next;
            } while (traverse != null);


            if (found)
            {
                if (traverse.Next == null)
                {
                    node.Prev = traverse;
                    node.Next = null; // already set in constructor
                    traverse.Next = node;
                }
                else
                {
                    node.Next = traverse.Next;
                    node.Prev = traverse;
                    traverse.Next.Prev = node;
                    traverse.Next = node;
                }
            }
            else
            {
                Console.WriteLine("Node Not Found");
            }
        }

        //Delete Element From any postion(Front|Specified Postion|End)
        public static void DeleteNode(string value)
        {
            if (First == null)
            {
                Console.WriteLine("List is empty");                
                return;
            }

            ListNode traverse = First;
            bool found = value == null;

            if (traverse.Data.Equals(value, StringComparison.InvariantCultureIgnoreCase))
            {
                First = First.Next;
                return;
            }

            do
            {
                if (value != null)
                {
                    if (traverse.Data.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                    {
                        found = true;                        
                        break;
                    }
                }
                if (traverse.Next == null) break;
                traverse = traverse.Next;
            } while (traverse != null);

            if (found)
            {
                if (traverse.Next == null)
                {
                    traverse.Prev.Next = null;
                }
                else
                {
                    traverse.Next.Prev = traverse.Prev;
                    traverse.Prev.Next = traverse.Next;
                }                
            }
            else
            {
                Console.WriteLine("Node Not Found! choose Element from list");
            }
        }

        //Display the List
        public static void Traverse()
        {
            ListNode traverse = First;
            Console.WriteLine("\n-- Current Data  --\n");
            while (traverse != null)
            {
                Console.WriteLine(traverse.Data);
                traverse = traverse.Next;
            }
        }
        
        //Menu and prgram entry Point
        static void Main(string[] args)
        {           
            Console.WriteLine("Let's make bidirectional list");

            Console.WriteLine("Setting up 5 Nodes for initializing List");

            //initializing list
            for (var i = 0; i < 5; i++)
                InsertNode(null, i.ToString());

            //display list
            Traverse();

            //Print the Menu and make the choice
            do
            {
                Console.WriteLine("\n\nMenu");
                Console.WriteLine("\n1. Insert Element");
                Console.WriteLine("2. Delete Element");
                Console.WriteLine("3. Print Data");
                Console.WriteLine("Q. Exit");
                Console.WriteLine("Enter Choice :");
                string choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    //case1: Insert New Node
                    case "1":
                        string data  = null;
                        if (First != null)
                        {
                            Console.WriteLine("Enter Node Value to Locate :");
                            data = Console.ReadLine();
                        }
                        Console.WriteLine("Enter New Node Value : ");
                        string input = Console.ReadLine();
                        if (CheckExisting(input))
                            Console.WriteLine("Element Data Already Exists");
                        else
                            InsertNode(data, input);
                            Traverse();
                        break;

                    //case2: Delete New Node
                    case "2":
                        Console.WriteLine("Enter Node Value to Delete : ");
                        string deleteVal = Console.ReadLine();
                        DeleteNode(deleteVal);
                        Traverse();
                        break;

                    //case3: Print Data
                    case "3":
                        Traverse();
                        break;

                    //caseQ: Quit the Application
                    case "Q":
                        return;

                    //default: Quit the Application
                    default: Console.WriteLine("Please select corrent menu item !");
                        break;
                }
                Console.WriteLine();
            } while (true);
        }
    }
}

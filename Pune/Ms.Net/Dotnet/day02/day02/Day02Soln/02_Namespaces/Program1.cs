using ListSpace;

// whole namespace can be written at once.
//  or can be split in multiple parts in same file
//  or can be split in multiple parts in multiple files/assemblies.

namespace TreeSpace
{
    class Node
    {
        private int data;
        // ...
    }

    class Tree
    {
        public void Add(int val)
        {
            Console.WriteLine("Tree.Add() called.");
        }
        public void Display()
        {
            Console.WriteLine("Tree.Display() called.");
        }
    }
}

// ListSpace -- part1 - Node class
namespace ListSpace
{
    class Node
    {
        private int data;
        // ...
    }
}

// ListSpace -- part2 - List class
namespace ListSpace { 
    class List
    {
        public void Add(int val)
        {
            Console.WriteLine("List.Add() called.");
        }
        public void Display()
        {
            Console.WriteLine("List.Display() called.");
        }
    }
}

namespace _02_Namespaces
{
    internal class Program1
    {
        static void Main1(string[] args)
        {
            // Use classes with fully qualified names
            TreeSpace.Node node1 = new TreeSpace.Node();
            TreeSpace.Tree t1 = new TreeSpace.Tree(); 
            t1.Add(1);
            t1.Add(2);
            t1.Add(3);
            t1.Display();

            ListSpace.Node node2 = new ListSpace.Node();
            ListSpace.List l1 = new ListSpace.List();
            l1.Add(1);
            l1.Add(2);
            l1.Add(3);
            l1.Display();
        }
    }
}

/*
Namespaces are logical container.
    - Code organization -- Logical hierarchial arrangement
    - Avoids name conflicts
By default for each project, one namespace is created.
    - It has same name as of project name.
    - Programmer can create additional namespaces in same file 
        or across files.
*/
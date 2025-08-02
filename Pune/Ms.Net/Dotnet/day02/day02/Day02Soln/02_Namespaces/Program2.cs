namespace NewNamespace;
// File-scoped namespace -- Reduce indentations (due to nesting)

/* 
Commonly used namespaces are auto-imported.
e.g. System, System.Collections.Generic, System.Linq.
*/

// Namespace alias - Reduce typing efforts while using fully qualified names
// of deely located classes e.g. System.Collections.Generic.List<>
using Gen = System.Collections.Generic;
using TreeSpace;

internal class Program2
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!\n");

        Gen.List<int> list = new Gen.List<int>();
        Console.WriteLine("List: " + list);

        Tree t1 = new Tree(); // can access member from namespace after "using" it.
        t1.Display();
    }
}


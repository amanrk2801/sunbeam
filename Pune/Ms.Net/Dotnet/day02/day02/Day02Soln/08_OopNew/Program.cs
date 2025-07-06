namespace _08_OopNew
{
    class A
    {
        public virtual void Foo() {
            Console.WriteLine("A.Foo() called.");
        }
    }
    class B: A
    {
        public override void Foo()
        {
            Console.WriteLine("B.Foo() called.");
        }
    }
    class C : B
    {
        public new virtual void Foo()
        {
            Console.WriteLine("C.Foo() called.");
        }
    }
    class D : C
    {
        public override void Foo()
        {
            Console.WriteLine("D.Foo() called.");
        }
    }
    class E : D
    {

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            A obj = new D();
            obj.Foo();
        }
    }
}

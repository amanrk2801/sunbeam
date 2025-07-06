using System.Collections;

namespace _02_ExceptionIndexerIterators
{
    // custom (user-defined) exception class
    class InvalidIndexExcpetion : ApplicationException
    {
        private int _index;
        public InvalidIndexExcpetion(int index)
            : base(message: $"Invalid Index at {index}")
        {
            this._index = index;
        }
        public int Index => _index;
        // ...
    }

    // stack of strings
    class DemoStack : IEnumerable
    {
        private readonly string[] _arr;
        private int _top = -1;
        public DemoStack(int capacity) => _arr = new string[capacity];
        public int Capacity => _arr.Length;
        public int Count => _top + 1;
        public void Push(string item) => _arr[++_top] = item;
        public string Pop() => _arr[_top--];
        public string Get(int index)
        {
            if (index < 0 || index > _top)
                throw new InvalidIndexExcpetion(index);
            return _arr[index];
        }

        // indexer implemenation 
        public string this[int index]
        {
            get {
                if (index < 0 || index > _top)
                    throw new InvalidIndexExcpetion(index);
                return _arr[index];
            }
            set {
                if (index < 0 || index > _top)
                    throw new InvalidIndexExcpetion(index);
                _arr[index] = value;
            }
        }

        class DemoStackEnumerator : IEnumerator
        {
            private readonly DemoStack _stack;
            private int _index;
            public DemoStackEnumerator(DemoStack stack)
            {
                _stack = stack;
                _index = -1;
            }
            public object Current
            {
                get {
                    return _stack._arr[_index];
                }
            }
            public bool MoveNext()
            {
                if (_index < _stack.Count)
                    _index++;
                return _index < _stack.Count;
            }
            public void Reset()
            {
                _index = -1;
            }
        }
        public IEnumerator GetEnumerator()
        {
            //return new DemoStackEnumerator(this);
            for (int i = 0; i < Count; i++)
                yield return _arr[i];
        }
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            #region Create DemoStack object
            DemoStack s = new DemoStack(5);
            Console.WriteLine("s Capacity: " + s.Capacity);
            #endregion

            #region Add Elements to DemoStack
            s.Push("One");
            s.Push("Two");
            s.Push("Three");
            s.Push("Four");
            Console.WriteLine("Popped: " + s.Pop()); // Four
            Console.WriteLine();
            #endregion

            #region Using Iterator with DemoStack
            foreach(string item in s)
                Console.WriteLine("Traverse - Elem: " + item);
            Console.WriteLine();
            #endregion

            #region Using Indexer in DemoStack class
            // DemoStack "s" object is used like an array due to "indexer".
            s[1] = "TWO";
            Console.WriteLine("s[1] = " + s[1]);
            #endregion

            #region Pop all elements from Stack
            while (s.Count > 0)
            {
                Console.WriteLine("Popped Elem: " + s.Pop());
                //Three, TWO, One
            }
            #endregion

            #region Custom Exception Handling
            try
            {
                Console.WriteLine("Get Elem at Index 6: " + s.Get(6));  
            }
            catch (InvalidIndexExcpetion e)
            {
                Console.WriteLine("Exception: " + e.Message);
                //e.Index;
            }
            #endregion
        }

        class Numbers : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return 1;
                yield return 3;
                yield return 5;
                yield return 7;
                yield return 11;
                yield return 13;
            }
        }
        static void Main(string[] args)
        {
            Numbers primes = new Numbers();
            foreach(int num in primes)
            { 
                Console.WriteLine(num); 
            }
        }
    }
}

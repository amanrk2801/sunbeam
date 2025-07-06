namespace _06_Arrays
{
    internal class Program
    {
        // 1-D array
        static void Main1(string[] args)
        {
            // Array - Collection of Elements of Same Type & Fixed Size - Index Based
            int[] arr1 = { 41, 22, 37, 54 };
            Console.WriteLine("arr1 Length: " + arr1.Length);
            for(int i = 0; i < arr1.Length; i++)
                Console.WriteLine("arr1[i] = " + arr1[i]);

            // Array Elements are by default initialized to the default value: int=0
            Console.WriteLine("\narr2 Elements: ");
            int[] arr2 = new int[5];
            foreach(int num in arr2)
                Console.WriteLine("arr2 for elem = " + num);

            // Sorting Array
            Console.WriteLine("\nAfter sort arr1:");
            Array.Sort(arr1, (x,y) => y - x);
            for (int i = 0; i < arr1.Length; i++)
                Console.WriteLine("arr1[i] = " + arr1[i]);
        }

        // 2-D array
        static void Main2(string[] args)
        {
            int[,] mat = new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 6, 7, 8 },
            };
            Console.WriteLine("mat Element Count: " + mat.Length);
            Console.WriteLine("mat Dimensions: " + mat.Rank);
            Console.WriteLine("mat Num of Rows: " + mat.GetLength(0)); // 3
            Console.WriteLine("mat Num of Cols: " + mat.GetLength(1)); // 3
            for (int i = 0;i < mat.GetLength(0);i++)
            {
                for (int j = 0; j < mat.GetLength(1);j++)
                    Console.Write(mat[i,j] + " ");
                Console.WriteLine();
            }
        }

        // jagged arrays
        static void Main3(string[] args)
        {
            int[][] mat = new int[3][];
            mat[0] = new int[] { 1, 2, 3 };
            mat[1] = new [] {4, 5, 6, 7};
            mat[2] = new[] { 8, 9 };
            for (int i = 0; i < mat.Length;i++)
            {
                for(int j = 0;j < mat[i].Length; j++)
                    Console.Write(mat[i][j] + " ");
                Console.WriteLine();
            }
        }

        // var arg function demo
        static void Main4(string[] args)
        {
            int AddAll(params int[] arr)
            {
                int sum = 0;
                foreach (int num in arr)
                    sum += num;
                return sum;
            }

            Console.WriteLine("Addition of Two Nums: " + AddAll(2, 4));
            Console.WriteLine("Addition of Four Nums: " + AddAll(1, 2, 3, 4));
        }

        // generic array - object[]
        static void Main(string[] args)
        {
            // flexible - can store any type
            object[] arr = new object[5];
            arr[0] = 123;
            arr[1] = 3.14;
            arr[2] = "string";
            arr[3] = DateTime.Now;
            arr[4] = true;
            // to access each elem (and their methods) -- need to downcast
            foreach (object obj in arr)
            {
                if (obj is int i)
                    Console.WriteLine("int elem = " + i);
                else if (obj is double d)
                    Console.WriteLine("double elem = " + d);
                else if (obj is string s)
                    Console.WriteLine("string elem = " + s);
                else if(obj is DateTime dt)
                    Console.WriteLine("datetime elem = " + dt);
                else
                    Console.WriteLine("unknown type elem = " + obj);
            }
        }
    }
}

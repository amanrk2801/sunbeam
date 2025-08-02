using System.Reflection;

namespace _08_Reflection
{
    enum Course
    {
        None = 0,
    }
    interface Specs
    {

    }
    class Test
    {
        // ...
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            // get info about the current assembly
            //Assembly asm = Assembly.GetExecutingAssembly();
            // get info about the given assembly
            string path = @"D:\Nilesh\Feb25\DAC\dotnet\Day06_Soln\MyMath\bin\Debug\net8.0\MyMath.dll"; // Console.ReadLine();
            Assembly asm = Assembly.LoadFrom(path);

            // get all types in assembly
            Type[] types = asm.GetTypes();
            foreach (Type type in types)
            {
                Console.WriteLine("Class Name: " + type.FullName);
                Console.WriteLine("Base Class: " + type.BaseType?.FullName);
                Type[] interfaces = type.GetInterfaces();
                foreach (Type interfaceType in interfaces)
                    Console.WriteLine("Intf: " + interfaceType.FullName);
                if(type.IsClass)
                    Console.WriteLine("Type: class");
                else if (type.IsInterface)
                    Console.WriteLine("Type: interface");
                else if (type.IsEnum)
                    Console.WriteLine("Type: enum");
                Console.WriteLine("Is Public: " + type.IsPublic);

                MethodInfo[] methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (MethodInfo m in methods)
                    Console.WriteLine("Method : " + m);

                FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (FieldInfo f in fields)
                    Console.WriteLine("Field : " + f);

                foreach (ConstructorInfo c in type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                    Console.WriteLine("Ctor : " + c);
                
                foreach (PropertyInfo p in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                    Console.WriteLine("Property : " + p);

                foreach (object attr in type.GetCustomAttributes())
                    Console.WriteLine("Attribute: " + attr);
            }
        }

        static void Main2(string[] args)
        {
            string path = @"D:\Nilesh\Feb25\DAC\dotnet\Day06_Soln\MyMath\bin\Debug\net8.0\MyMath.dll"; // Console.ReadLine();
            Assembly asm = Assembly.LoadFrom(path);

            Type type = asm.GetType("MyMath.MyMath");
            Console.WriteLine("Type Name: " + type?.FullName);

            object obj = asm.CreateInstance("MyMath.MyMath");
            Console.WriteLine("obj = " + obj);

            MethodInfo m = type.GetMethod("Multiply", BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            Console.WriteLine("Method: " + m);

            object res = m.Invoke(obj, [22, 7]);
            Console.WriteLine("Result: " + res);
        }

        static void Main(string[] arguments)
        {
            string path = @"D:\Nilesh\Feb25\DAC\dotnet\Day06_Soln\MyMath\bin\Debug\net8.0\MyMath.dll";
            Assembly asm = Assembly.LoadFrom(path);

            Type[] types = asm.GetTypes();
            foreach (Type type in types)
            {
                Console.WriteLine("* Type Name: " + type.FullName);
                object obj = asm.CreateInstance(type.FullName);
                Console.WriteLine("\t- Object created: " + obj);
                Console.WriteLine();

                foreach (MethodInfo m in type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                {
                    Console.WriteLine("- Method: " + m);
                    List<object> args = new List<object>();
                    foreach (ParameterInfo pi in m.GetParameters())
                    {
                        Console.Write($"\tEnter Value of {pi.Name}: ");
                        string? value = Console.ReadLine();
                        object? val = Convert.ChangeType(value, pi.ParameterType);
                        args.Add(val);
                    }

                    object? result = m.Invoke(obj, args.ToArray());
                    Console.WriteLine("\tResult: " + result);
                    Console.WriteLine();
                }
            }
        }
    }
}

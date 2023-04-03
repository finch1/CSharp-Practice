
namespace Delegate
{
    public delegate void MyDelegate(string msg); //declare a delegate
    public delegate int MyDelegateInt(); // delegate returns
    public delegate T add<T>(T param1, T param2); // generic delegate using generic type paremeters

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // set target method
            MyDelegate del = new MyDelegate(ClassA.MethodA);
            del("Hello Planet");
            Console.WriteLine();

            // set target method
            del = ClassB.MethodB;
            del("Hello Other Planet");
            Console.WriteLine();

            // or set lambda expression
            del = (string msg) => Console.WriteLine("Called Lambda Expression: " + msg);
            del("Hello Lambda");
            Console.WriteLine();

            // Invoke a delegate
            InvokeDelegate(del);
            Console.WriteLine();


            static void InvokeDelegate(MyDelegate del) // MyDelegate type parameter
            {
                del("Invoked Hello World");
            }

            // Multicast delegate: add or remove functions in the invocation list. 
            MyDelegate del1 = ClassA.MethodA;
            MyDelegate del2 = ClassB.MethodB;

            del = del1+ del2; // combines 2 delegate functions
            del("Hello Combined");
            Console.WriteLine();

            MyDelegate del3 = (string msg) => Console.WriteLine("Called del3 Lambda Expression: " + msg);
            del += del3; // combines del 1,2,3
            del("Combines 3 methods");
            Console.WriteLine();

            del -= del2;
            del("Removed del2");
            Console.WriteLine();

            // If a delegate returns a value, then the last assigned target method's value will be returned when a multicast method is called. 
            MyDelegateInt del4 = ClassA.MethodARet;
            MyDelegateInt del5 = ClassB.MethodBRet;
            MyDelegateInt del_i = del4 + del5;
            Console.WriteLine(del_i());
            Console.WriteLine();

            add<int> sum = Sum;
            Console.WriteLine(sum(10, 20));

            add<string> concat = Concat;
            Console.WriteLine(concat("The ", "dog."));
            Console.WriteLine();

            static int Sum(int a, int b)
            {
                return a+b;Console.WriteLine();
            }
            static string Concat(string a, string b)
            {
                return a+b;
            }
        }
    }

    class ClassA
    {
        public static void MethodA(string msg){
            Console.WriteLine("Called ClassA MethodA() with Paramter: " + msg);
        }

        public static int MethodARet()
        {
            return 100;
        }
    }

    class ClassB
    {
        public static void MethodB(string msg){
            Console.WriteLine("Called ClassB MethodB() with Paramter: " + msg);
        }

        public static int MethodBRet()
        {
            return 200;
        }
    }
}



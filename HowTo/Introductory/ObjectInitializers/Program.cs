namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Object initializer without constructir
            var person = new Person{FullName = "Terry T", Age = 69};
            person.Orders.Add(new Orders());
            person.Orders.Add(new Orders());

            System.Console.WriteLine(person.Orders.Count);
            person.NewOrderList();
            System.Console.WriteLine(person.Orders.Count);

        }
    }

    class Person
    {
        // initialize this internally in the class. No matter how many constructors, these will always be initialized
        // readonly = initialized only once, such as here or in a ctor
        readonly public List<Orders> Orders = new List<Orders>();

        // constructors should be used to initialize values from the outside
        public Person()
        {
            
        }

        public string FullName { get; set; }
        public int Age { get; set; }

        // this will raise an error as the List is decorated with readonly       
        public void NewOrderList()
        {
            this.Orders = new List<Orders>();
        }
    }

    class Orders
    {


    }
}
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // instance of a class = object = blueprint defined from the class
            var person = new Person();
            person.Name = "Jake";
            
            // Instance method = accessable from object
            person.Introduce("Jake Thomson");

            // Static accessable from class
            Person.Age = 0;
            // Static members are used to represent Singletons = one instance in memory
            Console.WriteLine();

            // Using the constructor
            var customer1 = new Customer("Terry");
            var customer2 = new Customer();
            var customer3 = new Customer("Jerry", 69);
            customer3.Orders.Add(new Orders());
            
            
        }
    }

    public class Person // Pascal Case
    {
        // anything inside the class is called member of the class

        // Data = Fields = Attributes
        public string Name;
        public static int Age;

        // Behaviour = Functions = Methods // camel Case
        // SGINATURE = what makes a method/constructor = return type, name, input parameters
        public void Introduce(string FullName)
        {
            string[] SplitName = FullName.Split(' ');

            Console.WriteLine("Name {0} Surname {1}", SplitName[0], SplitName[1]);
        }
        
    }

    public class Customer
    {
        private string Name;
        private int Age;
        public List<Orders> Orders;

        // Constructors are used to initialise the early state of the class = no return type
        public Customer()
        {
            this.Orders = new List<Orders>();
        }
    
        public Customer(string name) :this() // calls the default empty constructor to ensure List of orders is always initialized
        {
            // this = to make sure that what is on the left hand side is an attribute which belongs to the class
            this.Name = name;
        }
        
        // Constructor Overloading
        public Customer(string name, int age) :this(name) // will call the name constructor first, then the age
        {
            this.Age = age;
        }

    }

    public class Orders
    {


    }
}
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // generic lists of type we specify
            var gl_b = new GenericList<Book>();
            var gl_i = new GenericList<int>();
            
            gl_b.Add(new Book(123, "Hills"));
            gl_i.Add(70);

            // generic dict
            var gd_d = new GenericDict<string, Book>();
            gd_d.Add("abc", new Book(304, "Have"));

            // Testing nullable
            var number = new Nullable<int>(5);
            System.Console.WriteLine("Has value? " + number.HasValue);
            System.Console.WriteLine("Value: " + number.GetValueOrDefault());

            // no value = accepts null
            number = new Nullable<int>();
            System.Console.WriteLine("Has value? " + number.HasValue);
            System.Console.WriteLine("Value: " + number.GetValueOrDefault());
        }
    }


    public class Book
    {
        public Book(int ISBN, string Title)
        {
            System.Console.WriteLine("This book was created: {0}", Title);
        }
    }

    // Creating a List Class to hold objects
    // Bad Idea
    public class BookList
    {
        public void Add(BookList book)
        {
            throw new NotImplementedException();
        }

        public BookList this[int index]
        {
            get{throw new NotImplementedException();}
        }
    }

    // A Better Idea
    public class GenericList<T> // T accepts everything: int, objects...
    {
        public void Add(T value)
        {

        }

        public T this[int index]
        {
            get{throw new NotImplementedException();}
        }
    }

    // A Generic Dict
    public class GenericDict<TKey, TValue>
    {
        public void Add(TKey key, TValue value)
        {

        }
    }

    // Generic Comparer

    // types of constraints
    // where : IComparable
    // where : Product - class type
    // where : struct - value type
    // where : class - reference type
    // where : new() - default constructor type
    public class Utilities<T> where T:IComparable, new()// T stands for Template
    {
        // this only accepts int
        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        // new() is used here to initialize a generic template
        public void DoSomething(T value)
        {
            var obj = new T();
        }

        // this compares more types
        public T Max(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b; // IComparable is used here
        }
    }

    public class DiscountCalculator<TProduct> where TProduct:Product
    {
        public float CalculateDiscount(TProduct product){
            return product.Price;
        }
    }

    public class Product
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class Ktieb:Product // ktieb derives from product
    {
        public string Title { get; set; }
    }

    public class Nullable<T> where T:struct
    {
        private object _value;

        public Nullable()
        {
            
        }

        public Nullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            get{ return _value != null; } // if value is not null, return true
        }

        public T GetValueOrDefault()
        {
            if (HasValue)
                return (T)_value; // here we are casting

            // if null, return the default operator
            return default(T);
        }
        

    }
}

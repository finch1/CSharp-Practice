namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // Consept
            // input args => expression
            // number => number*number

            // Func Delegate<input type, output type> [name] = [input arguments] => [expression]
            // [input arguments] = (multiple parameters, multiple parameters, multiple parameters)
            // [name] = () => 
            Func<int, int> square = number => number*number;
            System.Console.WriteLine(square(5));

            // another example
            int factor = 5;
            Func<int, int> multiply = (number) => number*factor;
            var result_1 = multiply(5);
            System.Console.WriteLine(result_1);

            // another example - Predicats
            Predicate<string> isUpper = IsUpperCase;
            bool result_2 = isUpper("hello world!!");
            Console.WriteLine(result_2);

            // another example
            // bookRepo is a GenericList<T> with access to collection metods
            var bookRepo = new BookRepository().GetBooks();
            // Find all accepts a Predicate Type Argument
            var cheapBooks = bookRepo.FindAll(IsCheaperThen20Dollar); // FindAll Iterates the collection and for each book, it will pass the book to the method and returns the object
            foreach(var book in cheapBooks)
            {
                System.Console.WriteLine(book.title);
            }

            // NOW USING LAMBDA
            cheapBooks = bookRepo.FindAll(book => book.price < 20); // FindAll Iterates the collection and for each book, it will pass the book to the method and returns the object
            foreach(var book in cheapBooks)
            {
                System.Console.WriteLine(book.title);
            }


            
        }

        // A Predicate function, returning bool true if condition is satisfied
        static bool IsUpperCase(string str)
        {
            return str.Equals(str.ToUpper());
        }

        // A Predicate function, returning bool true if condition is satisfied
        static bool IsCheaperThen20Dollar(Book book)
        {
            return book.price < 20;
        }
    }

    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book("Title 1", 5),
                new Book("Title 2", 15),
                new Book("Title 3", 28),
            };

        }
    }

    public class Book
    {
        public string title = "";
        public int price = 0;

        public Book(string Title, int Price)
        {
            title = Title;
            price = Price;
        }
        
    }
}
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            // display books cheaper then 15
            var cheapBooks = new List<Book>();
            foreach(var book in books)
            {
                if(book.Price < 15)
                {
                    cheapBooks.Add(book);
                    System.Console.WriteLine(book.Title);
                }
            }

            System.Console.WriteLine();

            // now with LINQ Extension Methods
            var cheapBooksWhere = books
                                    .Where(books => books.Price < 15); // Where excepts a predicate (annonymous method) Func<Book, bool> = takes in a Book object and returns Book object if condition is true
            foreach(var book in cheapBooksWhere)
            {
                System.Console.WriteLine(book.Title);
            }

            System.Console.WriteLine();
            
            // Ordering too
            var cheapBooksOrder = books
                                    .Where(books => books.Price < 15)
                                    .OrderBy(books => books.Title); // Func<Book, TKey>, keySelector;
            foreach(var book in cheapBooksOrder)
            {
                System.Console.WriteLine(book.Title);
            }
            
            System.Console.WriteLine();

            // Selecting too
            var cheapBooksSelect = books
                                    .Where(books => books.Price < 15)
                                    .OrderBy(books => books.Title)
                                    .Select(books => books.Title); // Func<Book, TResult>, Selector; Here we converted to a list of strings because we only select th etitle of the book
            foreach(var Title in cheapBooksSelect)
            {
                System.Console.WriteLine(Title);
            }

            System.Console.WriteLine();

            // now with LINQ QueryOperator
            var cheapBooksOp = from b in books
                                where b.Price < 15
                                orderby b.Title
                                select b.Title; 
                                // or get a list of books with: select b;

            foreach(var Title in cheapBooksOp)
            {
                System.Console.WriteLine(Title);
            }

            System.Console.WriteLine();

            // Func<Book, bool> predicate = returns one object and throws error if more than one are found
            // books.Single(b => b.Price < 20)
            // SingleorDefault = returns null instead of exception
            System.Console.WriteLine(books.Single(b => b.Title == "Book C").Title);


            System.Console.WriteLine();

            // Pagination
            var pagedBooks = books.Skip(2).Take(3);
            System.Console.WriteLine(pagedBooks.Count());

            System.Console.WriteLine();

            // Aggregation = returns number
            var maxPrice = books.Max(b => b.Price);
            System.Console.WriteLine(maxPrice);
            var minPrice = books.Min(b => b.Price);
            System.Console.WriteLine(minPrice);
            var sumPrice = books.Sum(b => b.Price);
            System.Console.WriteLine(sumPrice);

            
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public int Price { get; set; }
    }

    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book(){Title = "Book A", Price = 5},
                new Book(){Title = "Book B", Price = 10},
                new Book(){Title = "Book C", Price = 15},
                new Book(){Title = "Book D", Price = 20},
                new Book(){Title = "Book E", Price = 25},

            };
        }
    }
}
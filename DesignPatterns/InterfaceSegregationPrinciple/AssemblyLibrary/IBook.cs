namespace Rental;

// further define a library item
public interface IBook : ILibraryItem
{
    string Author { get; set; }
    int Pages { get; set; }
}
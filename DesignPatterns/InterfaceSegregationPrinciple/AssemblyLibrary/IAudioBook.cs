namespace Rental;

// there maybe audio books which cannot be borrowed, so we do not implement directly from IBorrowable
public interface IAudioBook : ILibraryItem
{
    int RuntimeInMinutes {get; set;}
}
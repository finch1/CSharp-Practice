namespace ProductDemo;

// not a physical product to be shipped
public class DigitalProductModel : IDigitalProductModel
{
    public string Title { get; set; }
    
    public bool HasOrderBeenCompleted { get; private set;}

    public int TotalDownloadsLeft { get; private set;}=5;


    public void ShipItem(CustomerModel Customer)
    {
        if(!HasOrderBeenCompleted)
        {
            System.Console.WriteLine($"Simulating Emailing {Title} to {Customer.Email} in {Customer.City}");
            TotalDownloadsLeft--;
            // defensive programming
            if(TotalDownloadsLeft < 1)
            {
                HasOrderBeenCompleted = true;
                TotalDownloadsLeft = 0;
            }

        }
        
        
    }
}
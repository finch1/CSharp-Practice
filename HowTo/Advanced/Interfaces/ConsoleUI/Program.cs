using ProductDemo;

namespace ShoppingCart;

class Program
{
    static void Main(string[] args)
    {
        List<IProductModel> cart = AddSampleData();
        CustomerModel customer = GetCustomer();

        foreach (var prod in cart)
        {
            prod.ShipItem(customer);

            // if product implements IDigitalProductModel, put it in digital
            if(prod is IDigitalProductModel digital)
                System.Console.WriteLine($"For {digital.Title} you have {digital.TotalDownloadsLeft} downloads left");
        }

        Console.ReadLine();
    }

    private static CustomerModel GetCustomer()
    {
        return new CustomerModel{
            FirstName = "Jake",
            LastName = "Thomson",
            City = "WA",

        };        
    }

    private static List<IProductModel> AddSampleData()
    {
        return new List<IProductModel>
        {
            new PhysicalProductModel{Title = "Football"},
            new PhysicalProductModel{Title = "BaseBall"},
            new PhysicalProductModel{Title = "Basketball"},
            new DigitalProductModel{Title = "PDF File"}
        };
    }
}
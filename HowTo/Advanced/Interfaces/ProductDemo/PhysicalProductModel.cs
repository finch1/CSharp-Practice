namespace ProductDemo;

public class PhysicalProductModel : IProductModel
{
    public string Title { get; set; }
    public bool HasOrderBeenCompleted { get; private set; }
    public void ShipItem(CustomerModel Customer)
    {
        if(!HasOrderBeenCompleted){
            System.Console.WriteLine($"Simulating Shipping {Title} to {Customer.FirstName} in {Customer.City}");
            HasOrderBeenCompleted = true;
        }
    }

}
namespace ProductDemo;

// everything in interface is public
public interface IProductModel
{
    string Title { get; set; }
    bool HasOrderBeenCompleted { get; }
    void ShipItem(CustomerModel Customer);
}
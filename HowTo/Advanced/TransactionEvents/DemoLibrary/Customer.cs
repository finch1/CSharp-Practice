namespace DemoLibrary;
public class Customer
{
    public string CustomerName { get; set; }
    
    // readonly = initialized only once, such as here or in a ctor
    readonly public List<Account> AccountsList = new List<Account>();
}

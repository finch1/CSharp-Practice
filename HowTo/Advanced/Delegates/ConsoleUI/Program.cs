using DemoLibrary;

class Program
{
    static ShoppingCartModel cart = new ShoppingCartModel();

    static void Main(string[] args)
    {
        PopulateCartWithDemoData();

        System.Console.WriteLine($"The total of the cart is {cart.GenerateTotal(SubTotalAlert, CalculateLeveledDiscount, AlertUser):C2}");
        System.Console.WriteLine("\nAnonymous Methods");

        decimal total = cart.GenerateTotal((subTotal) => System.Console.WriteLine($"The subtotal is {subTotal:C2}."),
                                                (items, subTotal) => {
                                                    if(items.Count > 3)
                                                        return subTotal * 0.5M;
                                                    else
                                                        return subTotal;
                                                },
                                                (message) => System.Console.WriteLine("We are applying your discount"));

        System.Console.WriteLine($"Total is {total:C2}");

        System.Console.WriteLine();
        System.Console.Write("Press Key");
        System.Console.ReadLine();
    }

    // the actual definition of the delegate mentioned in the other class. No coupling, method does not need to know anything
    private static void SubTotalAlert(decimal subTotal)
    {
        System.Console.WriteLine($"The subtotal is {subTotal:C2}.");
    }

    // an Action
    private static void AlertUser(string message)
    {
        System.Console.WriteLine(message);
    }

    private static decimal CalculateLeveledDiscount(List<ProductModel> items, decimal subTotal)
    {
        if(subTotal > 100)
            return subTotal * 0.8M;
        else if(subTotal > 50)
            return subTotal * 0.85M;
        else if(subTotal > 10)
            return subTotal * 0.90M;
        else
            return subTotal;
    }

    private static void PopulateCartWithDemoData()
    {
        cart.Items.Add(new ProductModel{Item="1", Price = 3.63M});
        cart.Items.Add(new ProductModel{Item="2", Price = 2.95M});
        cart.Items.Add(new ProductModel{Item="3", Price = 7.51M});
        cart.Items.Add(new ProductModel{Item="4", Price = 8.84M});
    }
}
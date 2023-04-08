namespace CSharp8
{
    
    
    public interface IShoppingCart
    {

        public static void SetDefaultName(string name)
        {
            defaultName = name;
        }
        private static string defaultName = "";

        // default implementation :>
        // Since we are providing the implementation here, there is no need to add it to the implementing class, the compiler won't be angry
        void CalculateSubTotal()
        {
            // default implementation so the existing code using this interface does not break
            System.Console.WriteLine($"This is the {defaultName} IShoppingCart implementation of CalculateSubTotal.");
        }

        void CalculateTotal();
    }

    public class ShoppingCart : IShoppingCart
    {
        public void CalculateTotal()
        {
            System.Console.WriteLine("This is CalculateTotal in ShoppingCart class.");
        }
    }

    public class BetterShoppingCart : IShoppingCart
    {
        public BetterShoppingCart()
        {
            IShoppingCart.SetDefaultName("Special Name");
        }

        // commentint this to understand that this method cannot be called from the instanciated class, even if it is interfaced.
        /*
        public void CalculateSubTotal()
        {
            System.Console.WriteLine("This is CalculateSubTotal in BetterShoppingCart class.");
        }
        */

        public void CalculateTotal()
        {
            System.Console.WriteLine("This is CalculateTotal in BetterShoppingCart class.");
        }
    }
}
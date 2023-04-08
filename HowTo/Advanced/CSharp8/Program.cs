namespace CSharp8
{
    class Program
    {
        static void Main(string[] args)
        {
            // note in the output of this program:
            // defaultName in interface will use the one set in the interface
            // since the method in the interface is STATIC, once default name is initialized/set, it will remain visible for any other instanciated class coming after
            // so the order of initialization below, MATTERS

            // note that sc is an interface not the base class
            IShoppingCart sc = new ShoppingCart();
            
            sc.CalculateSubTotal();

            IShoppingCart sc_b = new BetterShoppingCart();

            sc_b.CalculateSubTotal(); // this method is available here !!! because we are using the interface

            BetterShoppingCart bsc = new BetterShoppingCart();

            bsc.CalculateTotal();

            NullCoalescAssignment.Demo();
            
            string filename = "Filename.txt";
            string filePath = @$"\{filename}";

        }
    }
}
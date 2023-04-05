namespace DemoLibrary;
public class ShoppingCartModel
{
    // we can return a tubple, or out, but the better way is delegate
    public delegate void MentionDiscount(decimal subTotal);

    public List<ProductModel> Items { get; set; } = new List<ProductModel>();

    public decimal GenerateTotal(MentionDiscount mentionDiscount,// first arg is reference to the delegate.
                                    Func<List<ProductModel>, decimal, decimal> calculateDiscountedTotal, // second arg is Func<input, input, output> delegate. with Func<>, we specify the type.
                                    Action<string> tellUserWeAreDiscounting)
    {
        decimal subTotal = Items.Sum(x => x.Price);

        mentionDiscount(subTotal); // loosley coupled application. Could be used as an alerting/event system

        tellUserWeAreDiscounting("We are applying your discount");

        // Note that we don't need to declare Func<> on top like the delegate method
        return calculateDiscountedTotal(Items, subTotal); // output is decimal and returned back
    }
}

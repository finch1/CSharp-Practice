namespace Person;

public class CEO : BaseEmployee, IManager
{
    public override void CalculatePerHourRate(int rank)
    {
        decimal baseAmount = 150M;
        Salary = baseAmount * rank;
    }

    public void GeneratePerformanceReview()
    {
        System.Console.WriteLine("I am reviewing some one else report");
    }

    public void PromoteSomeone()
    {
        System.Console.WriteLine("You are promoted");
    }
}
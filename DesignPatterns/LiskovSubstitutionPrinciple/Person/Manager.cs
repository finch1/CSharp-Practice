namespace Person;

public class Manager : Employee, IManager
{
    public override void CalculatePerHourRate(int rank)
    {
        decimal baseAmount = 19.75M;
        Salary = baseAmount + (rank *4);
    }

    public void GeneratePerformanceReview()
    {
        System.Console.WriteLine("Reviewing Performance.");
    }
}
namespace Person;

// abstract means this can be inhereted from but never used directly
public abstract class BaseEmployee : IEmployee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Salary { get; set; }

    public virtual void CalculatePerHourRate(int rank)
    {
        decimal baseAmount = 12.50M;

        Salary = baseAmount + (rank *2);
    }    
}
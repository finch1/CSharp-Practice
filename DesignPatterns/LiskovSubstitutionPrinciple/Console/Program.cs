using Person;

class Program
{
    // when children are swapped, they should not break the code, as they are all related to the parent
    static void Main(string[] args)
    {
        // showing correct implementation of LSP, where any child class may be instantiated into the parent
        BaseEmployee be = new CEO();
        BaseEmployee bee = new Manager();
        BaseEmployee beee = new Employee();

        // Note: using implementation still works, nothing breaks
        IManager accountingVP = new Manager(){FirstName = "Emma", LastName = "Stone"};
        accountingVP.CalculatePerHourRate(5);

        // Note: using implementation still works, nothing breaks
        IAmManaged emp = new Employee{FirstName = "Steve", LastName = "Jobs"};
        emp.AssignManager(accountingVP);
        emp.CalculatePerHourRate(2);

        System.Console.WriteLine($"{emp.FirstName}'s salary is {emp.Salary:C2}/hour");

        System.Console.ReadLine();
    }
}


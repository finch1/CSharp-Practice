namespace Person;
public class Employee : BaseEmployee, IAmManaged
{
    public IEmployee Manager { get; set; } = null;
    public void AssignManager(IEmployee manager)
    {
        System.Console.WriteLine("Simulate Reviewing Report.");
        Manager = manager;
    }
}

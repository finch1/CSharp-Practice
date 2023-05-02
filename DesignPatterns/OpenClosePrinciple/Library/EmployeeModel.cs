namespace OCP;

public class EmployeeModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool IsManager { get; set; } = false;
    public bool IsExecutive { get; set; } = false;
}
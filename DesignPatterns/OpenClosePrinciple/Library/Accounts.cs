namespace OCP;

public class Accounts : IAccounts
{
    public EmployeeModel Create(IApplicantModel person)
    {
        return new EmployeeModel{

            FirstName = person.FirstName,
            LastName = person.LastName,
            Email = @$"{person.FirstName.Substring(0,1)}.{person.LastName}@duluri.com"
        };
    }
    


}
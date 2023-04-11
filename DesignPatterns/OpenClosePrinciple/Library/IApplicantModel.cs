namespace OCP;

public interface IApplicantModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IAccounts AccountProcessor { get; set; }
}
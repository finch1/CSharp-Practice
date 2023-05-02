namespace Person;

public interface IAmManaged : IEmployee
{
    IEmployee Manager { get; set; }

    void AssignManager(IEmployee manager);
}
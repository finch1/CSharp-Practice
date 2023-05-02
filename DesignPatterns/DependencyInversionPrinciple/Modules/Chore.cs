namespace DPI;

public class Chore : IChore
{
    ILogger _logger;
    IMessageSender _messageSender;

    public string ChoreName { get; set; }
    public IPerson Owner { get; set; }
    public double HoursWorked { get; private set; }
    public bool IsComplete { get; private set; }

    // This ctor gives us new logger and message sender objects upon instantiating the class rather then putting them in the functions.
    // This is Dependency Injection
    public Chore(ILogger logger, IMessageSender messageSender)
    {
        _logger = logger;
        _messageSender = messageSender;
    }

    public void PerformedWork(double hours)
    {
        HoursWorked += hours;
        _logger.Log($"Performed work on {ChoreName}");
    }

    public void CompleteChore()
    {
        IsComplete = true;

        _logger.Log($"Completed {ChoreName}");

        _messageSender.SendMessage(Owner, $"The chore {ChoreName} is complete.");
    }

}
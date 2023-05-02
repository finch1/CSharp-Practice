namespace DPI;

public class Texter : IMessageSender
{
    public void SendMessage(IPerson person, string message)
    {
        System.Console.WriteLine($"Simulating sending an text too {person.Phone}");
    }
}
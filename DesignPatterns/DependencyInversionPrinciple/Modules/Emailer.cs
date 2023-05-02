namespace DPI;

public class Emailer : IMessageSender
{
    public void SendMessage(IPerson person, string message)
    {
        System.Console.WriteLine($"Simulating sending an email too {person.Email}");
    }
}
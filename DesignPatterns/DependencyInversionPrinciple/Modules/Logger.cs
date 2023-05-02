namespace DPI;

public class Logger : ILogger
{
    public void Log(string message)
    {
        System.Console.WriteLine($"Write to console {message}");
    }
}
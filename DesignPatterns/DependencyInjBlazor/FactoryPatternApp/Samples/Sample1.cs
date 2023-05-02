namespace FactoryPatternApp.Samples;

public class Sample1 : ISample1
{
    public string CurrentDateTime { get; set; } = DateTime.Now.ToString();
}
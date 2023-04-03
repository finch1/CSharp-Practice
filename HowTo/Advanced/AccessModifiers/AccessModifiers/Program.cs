using DemoLibrary;

namespace ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Building this project creates an exe/dll!");
        AccessDemo ad = new AccessDemo();
        // ad.InternalDemo();
        // ad.ProtectedInternalDemo();
        ad.PublicDemo();

        OutputCMD("Public", " as available everywhere!");
        OutputCMD("Private", " only available in the class it was declared in!");
        OutputCMD("Protected", " only available in the assembly it was declared in!");
        OutputCMD("Internal", " only available in the assembly it was declared in!");
        OutputCMD("Internal Protected", " where ever it inherets from in nay assembly!");
        OutputCMD("Private Protected", " only available in same class or inhereted but in same assembly!");
    }

    static void OutputCMD(string Title, string Message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.Write(Title);
        Console.ForegroundColor = ConsoleColor.Yellow;
        System.Console.WriteLine(Message);
    }
}

class GoodClass
{
    private string _ssn;
    public string SSN
    {
        get { return "****1234***"; }
        set { _ssn = value; }
    }

    private string _age;
    public string Age
    {
        get { return _age; }
        set { 
                if(value >= 0 && value < 150)
                    _age = value;
        }
    }
    
    
}

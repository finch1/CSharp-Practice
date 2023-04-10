

public static class StdMsg
{
    // static IDictionary<string, string> commonMessages = new Dictionary();

    private static readonly IDictionary<MsgType, string> commonMessages = new Dictionary<MsgType, string>
    {
        {MsgType.WelcomeMessage, "Welcome to my application"},
        {MsgType.EndApplication, "Goodbye!"},
        {MsgType.IncorrectFirstName, "You did not give us a valid first name!"},
        {MsgType.IncorrectLastName, "You did not give us a valid last name!"},
        {MsgType.AskForFirstName, "What is your first name?"},
        {MsgType.AskForLastName, "What is your last name?"},        
    };

    public static void PrintMessage(MsgType message)
    {
        System.Console.WriteLine(commonMessages[message]);  
    }

    public enum MsgType
    {
        WelcomeMessage,
        EndApplication,
        IncorrectFirstName,
        IncorrectLastName,
        AskForFirstName,
        AskForLastName,
        
    }

}
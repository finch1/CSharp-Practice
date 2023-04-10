

class PersonDataCapture
{
    public static Person Capture()
    {
        // Ask for person information
        Person user = new Person();

        StdMsg.PrintMessage(StdMsg.MsgType.AskForFirstName);  
        user.FirstName = Console.ReadLine();
        
        StdMsg.PrintMessage(StdMsg.MsgType.AskForLastName);  
        user.LastName = Console.ReadLine();

        return user;
    }
}
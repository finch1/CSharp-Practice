class Program
{
    // CREATE A MAIN METHOD WHICH ITS ONLY JOB IS TO CREATE FLOW AND CREATE A CLASS FOR EACH FUNTION = SINGLE RESPONSABILITY PRINCIPLE
    static void Main(string[] args)
    {
        StdMsg.PrintMessage(StdMsg.MsgType.WelcomeMessage);

        Person user = PersonDataCapture.Capture();

        bool isvalid = PersonValidate.ValidatePerson(user);

        if(isvalid is not true)
        {
            StdMsg.PrintMessage(StdMsg.MsgType.EndApplication);
            return;
        }

        AccountGenerator.CreateAccount(user);  


    }
    
}
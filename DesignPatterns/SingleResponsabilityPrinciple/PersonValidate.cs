

class PersonValidate
{
    public static bool ValidatePerson(Person user)
    {
        // Check validity of first name and last name
        if(string.IsNullOrWhiteSpace(user.FirstName))
        {
            StdMsg.PrintMessage(StdMsg.MsgType.IncorrectFirstName);
            return false;
        }
            

        if(string.IsNullOrWhiteSpace(user.LastName))
        {
            StdMsg.PrintMessage(StdMsg.MsgType.IncorrectLastName);
            return false;
        }

        return true;
    }
}
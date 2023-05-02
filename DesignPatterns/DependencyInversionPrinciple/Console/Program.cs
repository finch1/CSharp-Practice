using DPI;

public class Program
{
    /*
        High level modules should not depend on low level modules. 
        Rather, both should depend on abstractions. 
        And these abstractions should not depend on details. 
        Disconnected by using Interfances.
    */
    static void Main(string[] args)
    {
        IPerson owner = Factory.CreatePerson();

        owner.FirstName = "Jack";
        owner.LastName = "Jones";
        owner.Email = "Jack@Jones";
        owner.Phone = 12348;

        IChore chore = Factory.CreateChore();

        chore.ChoreName = "Clean kitchen";
        chore.Owner = owner;

        chore.PerformedWork(2);
        chore.PerformedWork(2.3);
        chore.CompleteChore();

        System.Console.ReadLine();



    }
}
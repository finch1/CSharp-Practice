namespace DemoLibrary;

public class SQLDataAccess : DataAccess
{
    // note that here we are overriding the already implemented method in the abstract class
    public override string LoadConnectionString(string connection)
    {
        // we can actually call the abstract implemented method to do the common processing
        string output = base.LoadConnectionString(connection);
        output += ". Virtual Override Method.";
        System.Console.WriteLine(output);
        return output;

    }

    // overriding the declaration in the abstract class and implementing the method
    public override void LoadData(string sql)
    {
        System.Console.WriteLine("Loading data from database");
    }

    public override void SaveData(string sql)
    {
        System.Console.WriteLine("Saving data to database");
    }

    

}

namespace DemoLibrary;

public class MySQLDataAccess : DataAccess
{

    public override void LoadData(string sql)
    {
        System.Console.WriteLine("Loading data from database");
    }

    public override void SaveData(string sql)
    {
        System.Console.WriteLine("Saving data to database");
    }
}

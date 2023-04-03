namespace DemoLibrary;


public abstract class DataAccess : IDataAccess
{
    // virtual allows overriding the method in the child class
    public virtual string LoadConnectionString(string connection)
    {
        System.Console.WriteLine("Load connection string");
        return "ConnectionStringLoaded";
    }

    // make sure who inherets, implements the below
    public abstract void LoadData(string sql);    

    public abstract void SaveData(string sql);
}

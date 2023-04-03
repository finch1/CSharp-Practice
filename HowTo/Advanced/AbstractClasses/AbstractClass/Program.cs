using DemoLibrary;

class Program
{
    static void Main(string[] args)
    {
        // ABSTRACT CLASS BLENDS BASE CLASS AND INTERFACE

        // this is possible and the variable will have access to all the methods
        DataAccess da = new SQLDataAccess();
        da.LoadConnectionString("Abstract Class");


        List<IDataAccess> databases = new List<IDataAccess>
        {
            new SQLDataAccess(),
            new MySQLDataAccess(),
        };

        foreach (var db in databases)
        {
            db.LoadConnectionString("Connection String");
            db.LoadData("Select * from table");
            db.SaveData("Insert into table");
            System.Console.WriteLine();
        }

        Console.ReadLine();
    }
} 
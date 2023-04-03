namespace DemoLibrary;

public interface IDataAccess
{
    string LoadConnectionString(string connection);

    void LoadData(string sql);

    void SaveData(string sql);
}
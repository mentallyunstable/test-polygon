
public interface IDataSaver
{
    string SaveData();
}

public interface IDataSaver<T> : IDataSaver where T : Data
{
    string PropertyKey { get; }
    void AddSubscriber(IDataSaveable<T> saveable);
    void RemoveSubscriber(IDataSaveable<T> saveable);
}

public interface IDataSaveable<T> where T : Data
{
    T GetSaveData();
}

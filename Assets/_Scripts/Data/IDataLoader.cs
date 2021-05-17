
public interface IDataLoadable<T> where T : Data
{
    void LoadData(T data);
}

public interface IDataLoader<T> : IDataLoader where T : Data
{
    void AddLoadable(IDataLoadable<T> loadable);
    void RemoveLoadable(IDataLoadable<T> loadable);
}

public interface IDataLoader
{
    void LoadData();
}

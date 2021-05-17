
public interface IInitialData { }

public interface IInitiable<T> where T : IInitialData
{
    void Initiate(T initialData);
}
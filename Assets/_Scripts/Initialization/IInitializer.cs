
public interface IInitializer<T> where T : IInitialData
{
    void AddInitiable(IInitiable<T> initiable);
    void RemoveInitiable(IInitiable<T> initiable);
    void Initialize();
}
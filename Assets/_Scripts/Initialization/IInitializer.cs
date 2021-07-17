/// <summary>
/// Inteface for 
/// </summary>
public interface IInitializer<T> : IObserver<T> where T : IInitiable
{
    void Initialize();
}
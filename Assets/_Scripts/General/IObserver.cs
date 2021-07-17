/// <summary>
/// Basic class for implementing Observer pattern logic.
/// </summary>
/// <typeparam name="T">Type of subscribers objects.</typeparam>
public interface IObserver<T>
{
    void AddSubscriber(T subscriber);
    void RemoveSubscriber(T subscriber);
}
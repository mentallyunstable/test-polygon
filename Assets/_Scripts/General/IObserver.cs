public interface IObserver<T>
{
    void AddSubscriber(T subscriber);
    void RemoveSubscriber(T subscriber);
}
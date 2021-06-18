
public interface IConfigObserver<T, C> : IObserver<T> where T : IConfigLoadable<C> where C : ConfigObject
{
    //void AddSubscriber(IConfigLoadable<T> subscriber);
    //void RemoveSubscriber(IConfigLoadable<T> subscriber);
    void LoadConfigs();
}

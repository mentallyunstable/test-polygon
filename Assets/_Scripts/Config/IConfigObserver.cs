
public interface IConfigObserver<T> where T : ConfigObject
{
    void AddSubscriber(IConfigLoadable<T> subscriber);
    void RemoveSubscriber(IConfigLoadable<T> subscriber);
    void LoadConfigs();
}

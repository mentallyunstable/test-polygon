
public interface IConfigLoadable<T> where T : ConfigObject
{
    string ConfigName { get; }
    void LoadConfig(T config);
}

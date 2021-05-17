
public interface IConfigLoader<T> where T : ConfigObject
{
    T LoadConfig(string configName);
}
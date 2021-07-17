using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingConfigObserver : MonoBehaviour, IInitiable, IConfigObserver<Building, BuildingConfig>
{
    [SerializeField]
    private string configPrefixName;

    private IConfigLoader<BuildingConfig> loader;
    private List<IConfigLoadable<BuildingConfig>> subscribers = new List<IConfigLoadable<BuildingConfig>>();

    private void Awake()
    {
        Initiate();
    }

    public void Initiate()
    {
        loader = new BuildingConfigLoader(configPrefixName);

        LoadConfigs();
    }

    public void AddSubscriber(Building subscriber)
    {
        if (loader == null)
        {
            if (!subscribers.Contains(subscriber))
            {
                subscribers.Add(subscriber);
            }
            else
            {
                Debug.LogWarning($"BuildConfigObserver already contains subscriber: {subscriber}");
            }
        }
        else
        {
            subscriber.LoadConfig(loader.LoadConfig(subscriber.ConfigName));
        }
    }

    public void RemoveSubscriber(Building subscriber)
    {
        if (loader == null)
        {
            if (subscribers.Contains(subscriber))
            {
                subscribers.Remove(subscriber);
            }
            else
            {
                Debug.LogWarning($"BuildConfigObserver doesn't contains subscriber: {subscriber}");
            }
        }
        else
        {
            subscriber.LoadConfig(loader.LoadConfig(subscriber.ConfigName));
        }
    }

    public void LoadConfigs()
    {
        for (int i = 0; i < subscribers.Count; i++)
        {
            subscribers[i].LoadConfig(loader.LoadConfig(subscribers[i].ConfigName));
        }

        subscribers = new List<IConfigLoadable<BuildingConfig>>();
    }
}

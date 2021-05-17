using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class BuildingDataSaver : MonoBehaviour, IDataSaver<BuildingData>
{
    [SerializeField]
    private DataSaversHandler saversHandler;

    private readonly List<IDataSaveable<BuildingData>> observables = new List<IDataSaveable<BuildingData>>();

    public string PropertyKey => "first_city_buildings_data";

    private void Awake()
    {
        saversHandler.AddSaver(this);
    }

    public void AddSubscriber(IDataSaveable<BuildingData> subscriber)
    {
        if (!observables.Contains(subscriber))
        {
            observables.Add(subscriber);
        }
    }

    public void RemoveSubscriber(IDataSaveable<BuildingData> subscriber)
    {
        if (observables.Contains(subscriber))
        {
            observables.Remove(subscriber);
        }
    }

    public string SaveData()
    {
        string json = "";
        for (int i = 0; i < observables.Count; i++)
        {
            json += JsonConvert.SerializeObject(observables[i].GetSaveData());
        }

        return json;
    }
}

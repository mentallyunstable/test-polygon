using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInitializer : MonoBehaviour, IInitializer<BuildingInitialData>
{
    [SerializeField]
    private BuildingConfigObserver configObserver;
    [SerializeField]
    private BuildingDataSaver dataSaver;
    [SerializeField]
    private BuildingViewController viewController;

    private List<IInitiable<BuildingInitialData>> initiables = new List<IInitiable<BuildingInitialData>>();

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        BuildingInitialData initialData = new BuildingInitialData(dataSaver, configObserver, viewController);

        for (int i = 0; i < initiables.Count; i++)
        {
            initiables[i].Initiate(initialData);
        }
    }

    public void AddInitiable(IInitiable<BuildingInitialData> initiable)
    {
        if (!initiables.Contains(initiable))
        {
            initiables.Add(initiable);
        }
    }

    public void RemoveInitiable(IInitiable<BuildingInitialData> initiable)
    {
        if (initiables.Contains(initiable))
        {
            initiables.Remove(initiable);
        }
    }
}

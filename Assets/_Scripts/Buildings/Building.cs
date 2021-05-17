using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public sealed class Building : MonoBehaviour, IConfigLoadable<BuildingConfig>, IInitiable<BuildingInitialData>, IDataSaveable<BuildingData>, ITimeEventable, IDataLoadable<BuildingData>
{
    [SerializeField]
    private BuildingInitializer initializer;
    [SerializeField]
    private string buildingName;

    public string ConfigName => buildingName;

    public BuildingConfig Config { get; private set; }

    public string TimerKey => "BuildingBehaviour_TestKey";

    public bool IsFree { get { return state is FreeBuildingState; } }
    public bool IsBought { get { return state is BoughtBuildingState; } }
    public bool IsWorking { get { return state is WorkingBuildingState; } }

    private BuildingConfigObserver configObserver;
    private BuildingDataSaver dataSaver;
    private BuildingViewController viewController;

    [Inject]
    private TimeEventsHandler timeEventshandler;

    private BuildingState state;

    private void Awake()
    {
        initializer.AddInitiable(this);
        timeEventshandler.AddNewTimer(this);
        Debug.Log("Building Awake");
    }

    public void Initiate(BuildingInitialData initialData)
    {
        dataSaver = initialData.DataSaver;
        configObserver = initialData.ConfigObserver;
        viewController = initialData.ViewController;

        dataSaver.AddSubscriber(this);
        configObserver.AddSubscriber(this);
    }

    private void OnDestroy()
    {
        dataSaver.RemoveSubscriber(this);
        configObserver.RemoveSubscriber(this);
        timeEventshandler.RemoveTimer(this);
    }

    private void OnMouseUpAsButton()
    {
        viewController.ShowView(this);
    }

    private void ChangeState(BuildingState newState)
    {
        state?.Dispose();
        state = newState;
    }

    public void LoadConfig(BuildingConfig config)
    {
        Config = config;

        state = new FreeBuildingState(this);
    }

    public BuildingData GetSaveData()
    {
        BuildingData data = new BuildingData()
        {
            name = buildingName,
            stateType = state.StateType,
        };

        state.SetSaveData(ref data);

        return data;
    }

    public IEnumerator ITimeEventCoroutine()
    {
        yield return new WaitForSeconds(3f);
        //ChangeState(new BoughtBuildingState(this));
    }

    public void BuyBuilding()
    {
        ChangeState(new BoughtBuildingState(this));
    }

    public void LoadData(BuildingData data)
    {
        Debug.Log(data);
    }

    public enum BuildingStateType
    {
        Free,
        Bought,
        Working
    }
}

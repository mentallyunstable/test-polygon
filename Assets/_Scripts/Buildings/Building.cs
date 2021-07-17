using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Building : MonoBehaviour, IConfigLoadable<BuildingConfig>, IInitiable,
    IDataSaveable<BuildingData>, ITimeEventable, IDataLoadable<BuildingData>
{
    public string ConfigName => buildingName;

    public string TimerKey => "BuildingBehaviour_TestKey";

    private BuildingState _state;

    [Inject]
    private readonly IInitializer<Building> _initializer;
    [Inject]
    private readonly IConfigObserver<Building, BuildingConfig> _configObserver;
    [Inject]
    private readonly ITimeEventsHandler _timeEventshandler;
    //[Inject]
    private readonly IDataSaver<BuildingData> _dataSaver;

    [SerializeField]
    private string buildingName;
    private BuildingViewController _viewController;

    public BuildingConfig Config { get; private set; }
    public StateType CurrectState => _state.Type;

    private void Awake()
    {
        _initializer.AddSubscriber(this);
        _configObserver.AddSubscriber(this);
        _timeEventshandler.AddTimer(this);
        //_dataSaver.AddSubscriber(this);
        Debug.Log("Building Awake");
    }

    public void Initiate()
    {
        Debug.Log($"Initiate building with name: {buildingName}");
    }

    private void OnDestroy()
    {
        _initializer.RemoveSubscriber(this);
        _configObserver.RemoveSubscriber(this);
        _timeEventshandler.RemoveTimer(this);
        //_dataSaver.RemoveSubscriber(this);
    }

    private void OnMouseUpAsButton()
    {
        _viewController.ShowView(this);
    }

    private void ChangeState(BuildingState newState)
    {
        _state?.Kill();
        _state = newState;
    }

    public void LoadConfig(BuildingConfig config)
    {
        Config = config;

        _state = new FreeBuildingState(this);
    }

    public BuildingData GetSaveData()
    {
        BuildingData data = new BuildingData()
        {
            name = buildingName,
            stateType = _state.Type,
        };

        _state.SetSaveData(ref data);

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

    public enum StateType
    {
        Free,
        Bought,
        Working
    }
}

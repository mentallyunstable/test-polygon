using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Building : MonoBehaviour, IConfigLoadable<BuildingConfig>, IInitiable<BuildingInitialData>,
    IDataSaveable<BuildingData>, ITimeEventable, IDataLoadable<BuildingData>
{
    public string ConfigName => buildingName;

    public string TimerKey => "BuildingBehaviour_TestKey";

    private BuildingState _state;

    [Inject]
    private readonly IConfigObserver<Building, BuildingConfig> _configObserver;
    [Inject]
    private readonly ITimeEventsHandler _timeEventshandler;
    [Inject]
    private IDataSaver<BuildingData> _dataSaver;

    [SerializeField]
    private BuildingInitializer initializer;
    [SerializeField]
    private string buildingName;
    private BuildingViewController _viewController;

    public BuildingConfig Config { get; private set; }
    public StateType CurrectState => _state.Type;

    private void Awake()
    {
        initializer.AddInitiable(this);
        _configObserver.AddSubscriber(this);
        _timeEventshandler.AddTimer(this);
        Debug.Log("Building Awake");
    }

    public void Initiate(BuildingInitialData initialData)
    {
        _dataSaver = initialData.DataSaver;
        _viewController = initialData.ViewController;

        _dataSaver.AddSubscriber(this);
    }

    private void OnDestroy()
    {
        _dataSaver.RemoveSubscriber(this);
        _configObserver.RemoveSubscriber(this);
        _timeEventshandler.RemoveTimer(this);
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

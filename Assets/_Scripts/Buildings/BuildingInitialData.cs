
public struct BuildingInitialData : IInitialData
{
    public BuildingDataSaver DataSaver { get; private set; }
    public BuildingConfigObserver ConfigObserver { get; private set; }
    public BuildingViewController ViewController { get; private set; }

    public BuildingInitialData(BuildingDataSaver dataSaver, BuildingConfigObserver configObserver, BuildingViewController viewController)
    {
        DataSaver = dataSaver;
        ConfigObserver = configObserver;
        ViewController = viewController;
    }
}

using UnityEngine;
using Zenject;

public class BuildingConfigObserverInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(GetComponent<IConfigObserver<Building, BuildingConfig>>()).AsSingle();
    }
}
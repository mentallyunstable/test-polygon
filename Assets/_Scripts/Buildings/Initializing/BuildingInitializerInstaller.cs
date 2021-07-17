using UnityEngine;
using Zenject;

public class BuildingInitializerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(GetComponent<IInitializer<Building>>());
    }
}
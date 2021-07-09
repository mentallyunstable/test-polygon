using UnityEngine;
using Zenject;

public class TimeEventsHandlerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(GetComponent<ITimeEventsHandler>()).AsSingle();
        //Container.BindInterfacesTo<ITimeEventable>();
    }
}
using UnityEngine;
using Zenject;

public class TimeEventsHandlerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(Container.InstantiateComponent<TimeEventsHandler>(gameObject)).AsSingle();
        Container.BindInterfacesTo<ITimeEventable>();
    }
}
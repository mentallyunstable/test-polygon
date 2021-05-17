using UnityEngine;
using Zenject;

public class FocusEventsHandlerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(Container.InstantiateComponent<FocusEventsHandler>(gameObject)).AsSingle();
        Container.BindInterfacesTo<IFocusEventable>();
        Debug.Log("FocusEventsHandlerInstaller InstallBindings");
    }
}
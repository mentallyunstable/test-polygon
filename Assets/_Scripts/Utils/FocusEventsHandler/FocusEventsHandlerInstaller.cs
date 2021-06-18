using UnityEngine;
using Zenject;

public class FocusEventsHandlerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(GetComponent<IObserver<IFocusEventable>>()).AsSingle();
        //Container.Bind<IFocusEventable>().To<IObserver<IFocusEventable>>();
        //Container.BindInstance(GetComponent<FocusEventsHandler>()).AsSingle();
        //Container.BindInterfacesTo<IFocusEventable>();
        Debug.Log("FocusEventsHandlerInstaller InstallBindings");
    }
}
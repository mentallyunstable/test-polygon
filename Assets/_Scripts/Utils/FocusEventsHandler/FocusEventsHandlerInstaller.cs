using UnityEngine;
using Zenject;

public class FocusEventsHandlerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(GetComponent<IObserver<IFocusEventable>>()).AsSingle();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFocusEventable
{
    void OnFocusChange(bool focus);
}

public class FocusEventsHandler : MonoBehaviour, IObserver<IFocusEventable>
{
    private readonly List<IFocusEventable> subscribers = new List<IFocusEventable>();

    public void AddSubscriber(IFocusEventable subscriber)
    {
        if (!subscribers.Contains(subscriber))
        {
            subscribers.Add(subscriber);
        }
        else
        {
            Debug.LogWarning($"FocusEventsHandler already contains subscriber: {subscriber}");
        }
    }

    public void RemoveSubscriber(IFocusEventable subscriber)
    {
        if (subscribers.Contains(subscriber))
        {
            subscribers.Remove(subscriber);
        }
        else
        {
            Debug.LogWarning($"FocusEventsHandler doesn't contains subscriber to remove: {subscriber}");
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        for (int i = 0; i < subscribers.Count; i++)
        {
            subscribers[i].OnFocusChange(focus);
        }
    }
}

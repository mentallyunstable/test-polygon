using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeEventable
{
    string TimerKey { get; }
    IEnumerator ITimeEventCoroutine();
}

public class TimeEventsHandler : MonoBehaviour
{
    private readonly Dictionary<string, IEnumerator> timers = new Dictionary<string, IEnumerator>();

    public void AddNewTimer(ITimeEventable timeEventable)
    {
        if (!timers.ContainsKey(timeEventable.TimerKey))
        {
            timers.Add(timeEventable.TimerKey, timeEventable.ITimeEventCoroutine());
            StartCoroutine(timeEventable.ITimeEventCoroutine());
        }
    }

    public void RemoveTimer(ITimeEventable timeEventable)
    {
        IEnumerator timer = timers[timeEventable.TimerKey];
        if (timer == null)
        {
            Debug.LogError($"TimeEventsHandler doesn't have timer with key: {timeEventable.TimerKey}");
        }
        else
        {
            StopCoroutine(timer);
            timers.Remove(timeEventable.TimerKey);
        }
    }
}

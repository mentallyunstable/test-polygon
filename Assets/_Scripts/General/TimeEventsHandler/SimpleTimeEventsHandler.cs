using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Common <see cref="ITimeEventsHandler"/>. Starts the coroutine on adding new subscriber with <see cref="AddTimer(ITimeEventable)"/> method.
/// </summary>
public class SimpleTimeEventsHandler : MonoBehaviour, ITimeEventsHandler
{
    private readonly Dictionary<string, IEnumerator> timers = new Dictionary<string, IEnumerator>();

    public void AddTimer(ITimeEventable timeEventable)
    {
        if (!timers.ContainsKey(timeEventable.TimerKey))
        {
            timers.Add(timeEventable.TimerKey, timeEventable.ITimeEventCoroutine());
            // TODO: need to detect coroutine end and remove it from timers dictionary
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

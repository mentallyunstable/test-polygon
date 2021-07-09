using System.Collections;

/// <summary>
/// Can be used by <see cref="ITimeEventsHandler"/>, that holds it and controls its <see cref="ITimeEventCoroutine"/>.
/// </summary>
public interface ITimeEventable
{
    /// <summary>
    /// Identifier for specific implementation. Can be used to find specific <see cref="ITimeEventable"/>.
    /// </summary>
    string TimerKey { get; }
    /// <summary>
    /// Time event coroutine.
    /// </summary>
    /// <returns></returns>
    IEnumerator ITimeEventCoroutine();
}
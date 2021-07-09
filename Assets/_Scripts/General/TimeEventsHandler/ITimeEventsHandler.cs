
/// <summary>
/// Interface for creating different time events handlers.
/// Time events handlers should be used to control MonoBehaviour coroutines remotely.
/// Should be used for adding and removing <see cref="ITimeEventable"/> and starting their coroutines.
/// </summary>
public interface ITimeEventsHandler
{
    /// <summary>
    /// Should be used for adding new <see cref="ITimeEventable"/> and starting their coroutines.
    /// </summary>
    /// <param name="timeEventable"></param>
    void AddTimer(ITimeEventable timeEventable);
    /// <summary>
    /// Should be used to remove <see cref="ITimeEventable"/>.
    /// </summary>
    /// <param name="timeEventable"></param>
    void RemoveTimer(ITimeEventable timeEventable);
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implementation on <see cref="IInitializer"/> interface used for initialize <see cref="Building"/> objects.
/// </summary>
public class BuildingInitializer : MonoBehaviour, IInitializer<Building>
{
    private readonly List<IInitiable> initiables = new List<IInitiable>();

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        for (int i = 0; i < initiables.Count; i++)
        {
            initiables[i].Initiate();
        }
    }

    public void AddSubscriber(Building initiable)
    {
        if (!initiables.Contains(initiable))
        {
            initiables.Add(initiable);
        }
    }

    public void RemoveSubscriber(Building initiable)
    {
        if (initiables.Contains(initiable))
        {
            initiables.Remove(initiable);
        }
    }
}

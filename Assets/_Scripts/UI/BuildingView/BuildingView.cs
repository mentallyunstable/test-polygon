using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingView : MonoBehaviour
{
    public Building Building { get; private set; }

    public void InitView(Building building)
    {
        Building = building;

        OnInitView();
    }

    protected abstract void OnInitView();
}

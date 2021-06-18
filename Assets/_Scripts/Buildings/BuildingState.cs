using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingState
{
    protected Building buildingContext;

    public abstract Building.BuildingStateType StateType { get; }

    public BuildingState(Building context)
    {
        buildingContext = context;

        SetContext(context);

        OnStateCreate();
    }

    public void Kill()
    {
        OnStateKill();
        //Debug.LogWarning("BuildingState Dispose");
    }

    private void SetContext(Building context)
    {
        LoadConfig(context.Config);
    }

    protected abstract void OnStateCreate();
    protected abstract void OnStateKill();
    protected abstract void LoadConfig(BuildingConfig config);

    public abstract void SetSaveData(ref BuildingData data);
    public abstract void LoadStateData(BuildingData data);

}
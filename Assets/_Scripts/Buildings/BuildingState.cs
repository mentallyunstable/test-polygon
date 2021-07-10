using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingState
{
    protected Building context;

    public abstract Building.StateType Type { get; }

    public BuildingState(Building context)
    {
        this.context = context;

        SetContext(context);

        OnStateCreate();
    }

    public void Kill()
    {
        OnStateKill();
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
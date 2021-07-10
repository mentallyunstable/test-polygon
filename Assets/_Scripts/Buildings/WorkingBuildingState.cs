using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class WorkingBuildingState : BuildingState
{
    private BigInteger rawIncome;
    public float rawInterval;

    public override Building.StateType Type => Building.StateType.Working;

    public WorkingBuildingState(Building context) : base(context) { }

    protected override void OnStateCreate()
    {

    }

    protected override void OnStateKill()
    {

    }

    protected override void LoadConfig(BuildingConfig config)
    {

    }

    public override void SetSaveData(ref BuildingData data)
    {

    }

    public override void LoadStateData(BuildingData data)
    {

    }
}

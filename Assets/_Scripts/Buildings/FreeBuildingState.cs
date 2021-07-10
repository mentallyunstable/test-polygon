using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class FreeBuildingState : BuildingState
{
    private BigInteger price;

    public override Building.StateType Type => Building.StateType.Free;

    public FreeBuildingState(Building context) : base(context) { }

    protected override void OnStateCreate()
    {
        Debug.LogWarning("FreeBuildingState OnStateCreate");
    }

    protected override void OnStateKill()
    {
        Debug.LogWarning("FreeBuildingState OnStateKill");
    }

    protected override void LoadConfig(BuildingConfig config)
    {
        price = BigInteger.Parse(config.price);
    }

    public override void LoadStateData(BuildingData data)
    {

    }

    public override void SetSaveData(ref BuildingData data)
    {

    }
}

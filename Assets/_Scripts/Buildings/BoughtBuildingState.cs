using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class BoughtBuildingState : BuildingState
{
    public BigInteger neededWorkersAmount;
    public BigInteger currentWorkersAmount;

    public override Building.StateType Type => Building.StateType.Bought;

    public BoughtBuildingState(Building context) : base(context) { }

    protected override void OnStateCreate()
    {
        Debug.LogWarning($"BoughtBuildingState OnStateCreate {neededWorkersAmount} {currentWorkersAmount}");
    }

    protected override void OnStateKill()
    {
        Debug.LogWarning("BoughtBuildingState OnStateKill");
    }

    protected override void LoadConfig(BuildingConfig config)
    {
        neededWorkersAmount = BigInteger.Parse(config.needWorkers);
    }

    public override void LoadStateData(BuildingData data)
    {
        currentWorkersAmount = BigInteger.Parse(data.currentWorkersAmount);
    }

    public override void SetSaveData(ref BuildingData data)
    {
        data.currentWorkersAmount = currentWorkersAmount.ToString();
    }
}

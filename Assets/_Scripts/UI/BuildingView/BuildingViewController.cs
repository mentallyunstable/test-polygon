using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingViewController : Singleton<BuildingViewController>
{
    [SerializeField]
    private FreeBuildingView freeBuildingView;

    public void ShowView(Building building)
    {
        if (building.CurrectState == Building.StateType.Free)
        {
            freeBuildingView.InitView(building);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeBuildingView : BuildingView
{
    [SerializeField]
    private UIObject view;

    protected override void OnInitView()
    {
        view.Enable();
    }

    public void BuyBuilding()
    {
        Building.BuyBuilding();
        view.Disable();
    }
}

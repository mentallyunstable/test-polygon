using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingConfiguration_", menuName = "Configuration/Building Configuration", order = 0)]
public class BuildingConfig : ConfigObject
{
    public string price;
    public string needWorkers;

    //public override string GetPath()
    //{
    //    return ResourcePathSettings.BuildingInfoPath;
    //}
}

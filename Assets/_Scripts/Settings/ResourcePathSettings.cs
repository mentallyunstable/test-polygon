using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourcePathSettings", menuName = "Settings/Resource Path Settings", order = 0)]
public class ResourcePathSettings : ScriptableObjectSingleton<ResourcePathSettings>
{
    [SerializeField]
    private string buildingInfoPath = "";
    public static string BuildingInfoPath { get { return Instance.buildingInfoPath + '/'; } }
}

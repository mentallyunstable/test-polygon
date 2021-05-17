using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingConfigLoader : ResourceLoader, IConfigLoader<BuildingConfig>
{
    private string path;

    public BuildingConfigLoader(string configName)
    {
        path = ResourcePathSettings.BuildingInfoPath + configName;
    }

    public BuildingConfig LoadConfig(string configName)
    {
        return LoadResource<BuildingConfig>(path + configName);
    }

}

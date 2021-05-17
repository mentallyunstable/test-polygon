using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader
{
    protected static T LoadResource<T>(string path) where T : Object
    {
        T resource = Resources.Load<T>(path);

        if (resource)
        {
            return resource;
        }

        throw new System.Exception($"ResourceLoader can't load object by path: {path}");
    }
}
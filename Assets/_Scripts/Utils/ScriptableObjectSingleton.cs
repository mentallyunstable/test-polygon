using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject
{
    private static T self;

    public static T Instance
    {
        get
        {
            if (self == null)
            {
                T[] objects = Resources.LoadAll<T>("Settings/" + typeof(T).Name.ToString());
                //Debug.Log(objects.Length + " " + "Settings/" + typeof(T).ToString());

                if (objects.Length > 0)
                {
                    self = objects[0];
                    if (objects.Length > 1)
                    {
                        Debug.LogError("More than one instance of scriptable object of type: " + typeof(T).Name.ToString());
                    }
                }
                else
                {
                    Debug.LogError("No instances of scriptable object of type: " + typeof(T).Name.ToString());
                }

            }

            return self;
        }
    }

    public void OnEnable()
    {
        if (Instance != null && this != Instance)
        {
            Debug.LogError(typeof(T).Name.ToString() + " already exists in \"Resources\\Settings\\\"");
            DestroyImmediate(this);
        }
    }
}

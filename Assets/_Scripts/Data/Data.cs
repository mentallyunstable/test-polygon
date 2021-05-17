using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Runtime.Serialization;

public class Data
{
    private string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }

    private T FromJson<T>(string json) where T : Data
    {
        return JsonConvert.DeserializeObject<T>(json);
    }
}

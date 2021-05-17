using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DataSaversHandler : Singleton<DataSaversHandler>, IFocusEventable
{
    public bool debugging;

    [Inject]
    private FocusEventsHandler focusEventsHandler;

    private readonly List<IDataSaver> savers = new List<IDataSaver>();

    private void Awake()
    {
        Debug.Log("DataSaversHandler Awake");
        focusEventsHandler.AddSubscriber(this);
    }

    private void OnDestroy()
    {
        focusEventsHandler.RemoveSubscriber(this);
    }

    public void AddSaver(IDataSaver saver)
    {
        if (saver != null && !savers.Contains(saver))
        {
            savers.Add(saver);

            if (debugging)
            {
                Debug.Log($"<color=red>{name}</color> added new subscriber: <color=red>{saver.GetType()}</color>");
            }
        }
    }

    private void SaveData()
    {
        string json = string.Empty;

        for (int i = 0; i < savers.Count; i++)
        {
            json += savers[i]?.SaveData();
        }

        Debug.Log(json);
    }

    public void OnFocusChange(bool focus)
    {
        if (!focus)
            SaveData();
    }
}

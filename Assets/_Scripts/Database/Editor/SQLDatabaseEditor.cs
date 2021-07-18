using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SQLDatabase))]
[CanEditMultipleObjects]
public class SQLDatataseEditor : Editor
{
    private string _query = "";

    public override void OnInspectorGUI()
    {
        SQLDatabase db = target as SQLDatabase;

        base.OnInspectorGUI();

        if (GUILayout.Button("Check database connection"))
        {
            if (db.OpenConnection())
            {
                Debug.Log("Database connection opened successfully");
                db.CloseConnection();
            }
            else
            {
                Debug.LogError("Error while trying to open database connection");
            }
        }

        EditorGUILayout.LabelField("SQL query", EditorStyles.boldLabel);

        _query = EditorGUILayout.TextArea(_query, GUILayout.Height(100), GUILayout.ExpandHeight(true));

        if (GUILayout.Button("Execute query"))
        {
            db.ExecuteRawQuery(_query);
        }

        if (GUILayout.Button("Get data"))
        {
            DataSet ds = db.GetDataByQuery(_query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < ds.Tables[0].Rows[i].ItemArray.Length; j++)
                {
                    Debug.Log(ds.Tables[0].Rows[i][j]);
                }
            }
        }
    }
}
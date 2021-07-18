using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using System.Text;

public class SQLDatabase : MonoBehaviour
{
    private const string CONNECTION_URI = "Data Source=";

    public string databaseFileName = "db.bytes";

    private string _databasePath;
    private SqliteConnection _connection;
    private SqliteCommand _command;

    private string DatabasePath => Application.isPlaying ? _databasePath : Path.Combine(Application.streamingAssetsPath, databaseFileName);

    private void Awake()
    {
        SetDatabasePath();
    }

    private void SetDatabasePath()
    {
#if UNITY_EDITOR
        _databasePath = Path.Combine(Application.streamingAssetsPath, databaseFileName);
        CheckAndCreateDatabaseFile();
#elif UNITY_ANDROID
        _databasePath = Path.Combine(Application.persistentDataPath, databaseFileName);
        UnpackDatabaseFile();
#elif UNITY_IOS
        _databasePath = Path.Combine(Application.dataPath, "Raw", databaseFileName);
        UnpackDatabaseFile();
#endif
    }

    public bool OpenConnection()
    {
        try
        {
            CheckAndCreateDatabaseFile();
            _connection = new SqliteConnection(CONNECTION_URI + DatabasePath);
            _command = new SqliteCommand(_connection);
            _connection.Open();

            return true;
        }
        catch (System.Exception exception)
        {
            Debug.LogError($"Exception caught while trying to open database connection, name: {databaseFileName}, path: {DatabasePath}");
            Debug.LogException(exception);

            return false;
        }
    }

    public bool CloseConnection()
    {
        try
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _command.Dispose();
            }

            return true;
        }
        catch (System.Exception exception)
        {
            Debug.LogError($"Exception caught while trying to close database connection, name: {databaseFileName}, path: {DatabasePath}");
            Debug.LogException(exception);

            return false;
        }
    }

    public bool ExecuteRawQuery(string query)
    {
        try
        {
            OpenConnection();
            _command.CommandText = query;
            _command.ExecuteNonQuery();
            CloseConnection();

            return true;
        }
        catch (System.Exception exception)
        {
            Debug.LogError($"Exception caught while trying to do raw query, name: {databaseFileName}, path: {DatabasePath}");
            Debug.LogException(exception);

            return false;
        }
    }

    public DataSet GetDataByQuery(string query)
    {
        try
        {
            OpenConnection();
            using SqliteDataAdapter adapter = new SqliteDataAdapter(query, _connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            CloseConnection();

            return ds;
        }
        catch (System.Exception exception)
        {
            Debug.LogException(exception);
            return null;
        }
    }

    #region ANDROID_COMPILATION

#if UNITY_ANDROID
    private void UnpackDatabaseFile()
    {
        if (!File.Exists(DatabasePath))
        {
            using WWW reader = new WWW(DatabasePath);
            while (!reader.isDone) { }

            File.WriteAllBytes(DatabasePath, reader.bytes);
        }
    }
#endif

    #endregion
    #region IOS_COMPILATION

#if UNITY_IOS
    private void UnpackDatabaseFile()
    {
        if (!File.Exists(DatabasePath))
        {
            using WWW reader = new WWW(DatabasePath);
            while (!reader.isDone) { }

            File.WriteAllBytes(DatabasePath, reader.bytes);
        }
    }
#endif

    #endregion

#if UNITY_EDITOR
    private void CheckAndCreateDatabaseFile()
    {
        CheckAndCreateStreamingAssetsDirectory();

        if (!File.Exists(DatabasePath))
        {

        }
    }

    private void CheckAndCreateStreamingAssetsDirectory()
    {
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
    }
#endif
}

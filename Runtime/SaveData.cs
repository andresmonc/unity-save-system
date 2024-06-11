using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{

    public string EntityID { get; private set; }
    private Dictionary<string, object> data;

    public static SaveData Of(string entityID, params (string key, object value)[] keyValuePairs)
    {
        SaveData saveData = new SaveData
        {
            EntityID = entityID,
            data = new Dictionary<string, object>()
        };
        foreach (var pair in keyValuePairs)
        {
            saveData.data.Add(pair.key, pair.value);
        }
        return saveData;
    }

    public T GetData<T>(string key)
    {
        if (data.TryGetValue(key, out object value))
        {
            if (value is T typedValue)
            {
                return typedValue;
            }
            else
            {
                throw new InvalidCastException($"The value for key '{key}' is not of type {typeof(T)}.");
            }
        }
        else
        {
            throw new KeyNotFoundException($"The key '{key}' was not found in the dictionary.");
        }
    }
}

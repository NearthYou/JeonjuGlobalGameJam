using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    private Dictionary<string, object> _data = new Dictionary<string, object>();

    public void AddData(string key, object data)
    {
        if (_data.ContainsKey(key))
        {
            _data[key] = data;
        }
        else
        {
            _data.Add(key, data);
        }
    }

    public T GetData<T>(string key)
    {
        if (_data.ContainsKey(key))
        {
            return (T)_data[key];
        }

        return default;
    }

    public void RemoveData(string key)
    {
        if (_data.ContainsKey(key))
        {
            _data.Remove(key);
        }
    }

    public void ClearData()
    {
        _data.Clear();
    }
}
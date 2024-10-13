using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Managers : MonoBehaviour
{
    private static Managers _instance = null;
    public static Managers instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = GameObject.Find("@Managers");
                if (go == null)
                {
                    go = new GameObject { name = "@Managers" };
                    go.AddComponent<Managers>();
                }

                _instance = go.GetComponent<Managers>();
            }

            return _instance;
        }
    }

    private static UIManager _uiManager;
    private static DataManager _dataManager;
    private static SoundManager _soundManager;
    private static GameManager _gameManager = null;
    public static UIManager UI => _uiManager;
    public static DataManager Data => _dataManager;
    public static SoundManager Sound => _soundManager;
    public static GameManager Game => _gameManager;

    private void Awake()
    {
        SetUp();
    }

    private void SetUp()
    {
        _uiManager = Utils.TryOrAddComponent<UIManager>(gameObject);
        _soundManager = Utils.TryOrAddComponent<SoundManager>(gameObject);
        _gameManager = Utils.TryOrAddComponent<GameManager>(gameObject);
        _dataManager = new DataManager();
        _uiManager.Init();
        
        DontDestroyOnLoad(this);
    }

    private void OnApplicationQuit()
    {
        _uiManager.Quit();
    }
}
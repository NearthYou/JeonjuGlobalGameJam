using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesButton : MonoBehaviour
{
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        
        button.onClick.AddListener(() =>
        {
            Managers.Game.StartGame();
            Managers.Sound.StopSFX();
            Managers.Sound.StopBGM();
        });
    }
}

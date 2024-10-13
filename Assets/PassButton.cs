using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassButton : MonoBehaviour
{
    [SerializeField] private bool _isGimme;
    private PassUIController _passUIController;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void Init(PassUIController passUIController)
    {
        _passUIController = passUIController;
    }
}
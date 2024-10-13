using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chopsticks : Draggable, ITools
{
    [SerializeField] private Sprite _changeSprite;
    private Sprite _initSprite;
    private Image _image;
    private bool _isBroken;
    private Color initColor;

    private float _timer;
    private float _maxTime = 30f;

    private void Awake()
    {
        initColor = GetComponent<Image>().color;
        _image = GetComponent<Image>();
        _initSprite = _image.sprite;
    }

    private void Update()
    {
        if (_isBroken)
        {
            _timer += Time.deltaTime;
            if (_timer >= _maxTime)
            {
                _isBroken = false;
                _image.color = initColor;
                _image.sprite = _initSprite;
                _timer = 0;
            }
        }
    }

    public void UseTool()
    {
        if (_isBroken)
            return;
        
        if(StageManager.instance.CurrentFood.GetTaste() == ETaste.Toxic)
        {
            Debug.Log("독성이 있는 음식입니다.");
            _image.color = Color.green;
        }
        else
        {
            Managers.Sound.PlaySFX("SC_Break");
            Debug.Log("젓가락 부러짐");
            _isBroken = true;
            _image.sprite = _changeSprite;
        }
    }

    public void ResetChopsticks()
    {
        if (_isBroken)
            return;
        
        _image.color = initColor;
        _image.sprite = _initSprite;
    }
}
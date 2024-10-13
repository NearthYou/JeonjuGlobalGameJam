using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Emotion : MonoBehaviour
{
    private Image _image;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    
    public void SetEmotion(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
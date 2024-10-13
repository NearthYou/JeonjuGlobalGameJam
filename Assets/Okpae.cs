using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Okpae : Draggable, ITools
{
    [SerializeField] private GameObject _stampSprite;
    
    public void UseTool()
    {
        Debug.Log("옥패 사용");
    }
}
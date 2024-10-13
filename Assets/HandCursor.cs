using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCursor : MonoBehaviour
{
    [SerializeField] private Texture2D _cursorTexture;
    [SerializeField] private Texture2D _cursorHand;
    [SerializeField] private Texture2D _cursorClick;

    private void OnMouseEnter()
    {
    }
    
    private void OnMouseExit()
    {
        Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GimmeZone : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Texture2D _cursorTexture;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if(!StageManager.instance.IsSpreadFood || StageManager.instance.IsEat)
            return;
        
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        StageManager.instance.EatGimme();
    }
}
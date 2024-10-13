using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodZone : MonoBehaviour, IDropHandler, IPointerClickHandler, IPointerMoveHandler, IPointerExitHandler
{
    [SerializeField] private Texture2D _cursorTexture;
    [SerializeField] private Texture2D _cursorClick;

    private bool isSpreadFood;

    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null || draggable.IsDragging)
        {
            // 드롭할 수 있는 위치에 블록이 드롭될 때 수행할 작업

            // 드래그한 블록 위치 고정
            // draggable.transform.SetParent(transform);
            // draggable.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            // 드래그
            //Debug.Log("Dropped on " + gameObject.name);

            if (eventData.pointerDrag.GetComponent<Draggable>() is Chopsticks)
            {
                Managers.Sound.PlaySFX("SC_Put");
                eventData.pointerDrag.GetComponent<ITools>().UseTool();
            }
        }
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if(StageManager.instance.CurrentFood == null || isSpreadFood)
            return;
        
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if(StageManager.instance.CurrentFood == null || StageManager.instance.IsEat)
            return;
        
        Cursor.SetCursor(_cursorClick, Vector2.zero, CursorMode.ForceSoftware);
        isSpreadFood = true;
        StageManager.instance.SpreadFood();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if(StageManager.instance.CurrentFood == null || isSpreadFood
           || StageManager.instance.IsEat)
            return;
        
        Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void EatFood()
    {
        isSpreadFood = false;
    }
}
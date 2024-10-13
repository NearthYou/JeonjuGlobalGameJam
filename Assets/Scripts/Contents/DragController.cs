using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 DefaultPos;
    private Draggable draggable;
 
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        draggable = GetComponent<Draggable>();
    }
 
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // 투명도 조절
        canvasGroup.blocksRaycasts = false; // 드래그 중인 동안 다른 UI 요소의 클릭 허용
        DefaultPos = rectTransform.anchoredPosition;
        
        if(eventData.pointerDrag.GetComponent<Draggable>() is Chopsticks)
            Managers.Sound.PlaySFX("SC_Click");
    }
 
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / GetCanvas().scaleFactor;
        draggable.IsDragging = true;
    }
 
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f; // 원래 투명도로 복원
        canvasGroup.blocksRaycasts = true; // 다시 다른 UI 요소의 클릭 차단
        rectTransform.anchoredPosition = DefaultPos;
        draggable.IsDragging = false;
    }
 
    private Canvas GetCanvas()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("Draggable 요소가 Canvas 안에 포함되어 있지 않습니다.");
        }
        return canvas;
    }
}
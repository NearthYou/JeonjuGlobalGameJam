using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class ButtonDropZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject stamp;
    public GameObject Stamp => stamp;

    [SerializeField] private ButtonDropZone otherButton;
    [FormerlySerializedAs("isGimmee")] [SerializeField] private bool isSend;
    
    private bool _isStamp = false;
    public bool _coolTime = false;
    private float time = 0;
    private float maxTime = 3f;
    
    public bool IsStamp
    {
        get => _isStamp;
        set => _isStamp = value;
    }

    private void Update()
    {
        if (_coolTime)
        {
            time += Time.deltaTime;
            if (time >= maxTime)
            {
                time = 0;
                _coolTime = false;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (_coolTime)
            return;
        
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null)
        {
            if (eventData.pointerDrag.GetComponent<Draggable>() is Okpae)
            {
                otherButton.Stamp.SetActive(false);
                otherButton.IsStamp = false;
                stamp.SetActive(false);
                eventData.pointerDrag.GetComponent<ITools>().UseTool();
                stamp.SetActive(true);
                _isStamp = true;

                Managers.Sound.PlaySFX("Stamp");
                
                if (isSend)
                {
                    StartCoroutine(StageManager.instance.SendFood(stamp));
                    _coolTime = true;
                    otherButton._coolTime = true;

                }
                else
                {
                    StartCoroutine(StageManager.instance.TrashFood(stamp));
                    _coolTime = true;
                    otherButton._coolTime = true;
                }
            }
        }
    }
}
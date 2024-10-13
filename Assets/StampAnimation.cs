using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StampAnimation : MonoBehaviour
{
    private Vector3 _originalScale;
    
    private void Awake()
    {
        _originalScale = transform.localScale;
    }
    
    private void OnEnable()
    {
        Sequence _sequence = DOTween.Sequence();
        _sequence.Append(transform.DOScale(Vector3.one, 0.5f)).SetEase(Ease.InOutCirc);
    }
    
    private void OnDisable()
    {
        transform.localScale = _originalScale;
    }
}

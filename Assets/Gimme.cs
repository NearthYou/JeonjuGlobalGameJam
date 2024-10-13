using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gimme : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite changeSprite;
    [SerializeField] private Sprite deadSprite;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite()
    {
        spriteRenderer.sprite = changeSprite;
    }
    
    public void Move(Vector3 target)
    {
        transform.DOMove(target, 1f);
    }
    
    public void Delete()
    {
        spriteRenderer.sprite = deadSprite;
        Sequence sequence = DOTween.Sequence();
        sequence
            .Append(spriteRenderer.DOFade(0f, 1f)
                .OnComplete(() => gameObject.SetActive(false)));
    }
}

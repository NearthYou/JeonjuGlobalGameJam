using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Food : MonoBehaviour
{
    [SerializeField] private Sprite changeSprite;
    [SerializeField] private Ease easeType = Ease.Linear;
    
    private FoodInfo foodInfo;

    public FoodInfo FoodInfo
    {
        get => foodInfo;
        set => foodInfo = value;
    }

    private SpriteRenderer spriteRenderer;
    
    private Vector3 initScale;
    private Color initColor;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initScale = transform.localScale;
        initColor = spriteRenderer.color;
    }
    
    public bool IsPoison()
    {
        return foodInfo.toxic > 0;
    }
    
    public void SetFoodInfo(FoodInfo _foodInfo)
    {
        foodInfo = _foodInfo;
        spriteRenderer.sprite = this.foodInfo._image;
    }
    
    public void MoveOut(Vector3 targetPosition, float duration)
    {
        
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(targetPosition, duration).SetEase(easeType))
            .AppendInterval(0.25f)
            .AppendCallback(() => ScaleChange(1.1f, 0.5f));
    }
    
    public void MoveIn(float duration)
    {
        StopAnimation();
        
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.position + Vector3.right * 8f, duration).SetEase(easeType))
            .OnComplete(() =>
            {
                Debug.Log("stop");
                Destroy(gameObject);
            });
    }
    
    public void ScaleChange(float targetScale, float duration)
    {
        transform.DOScale(targetScale, duration).SetLoops(-1, LoopType.Yoyo);
        //spriteRenderer.DOFade(0.5f, 0);
        //spriteRenderer.color = Color.green;
    }

    public void StopAnimation()
    {
        transform.DOKill();
        transform.localScale = initScale;
        spriteRenderer.color = initColor;
    }
    
    public ETaste GetTaste()
    {
        Dictionary<ETaste, int> tasteCount = new Dictionary<ETaste, int>();
        tasteCount.Add(ETaste.Salty, foodInfo.salty);
        tasteCount.Add(ETaste.Spicy, foodInfo.spicy);
        tasteCount.Add(ETaste.Sour, foodInfo.sour);
        tasteCount.Add(ETaste.Toxic, foodInfo.toxic);

        if (tasteCount[ETaste.Toxic] > 0)
            return ETaste.Toxic;

        int total = 0;
        ETaste taste = ETaste.None;
        
        foreach (var item in tasteCount)
        {
            if (item.Value > total)
            {
                total = item.Value;
                taste = item.Key;
            }
        }

        return taste;
    }
}
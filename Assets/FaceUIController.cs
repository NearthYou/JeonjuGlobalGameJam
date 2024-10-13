using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FaceUIController : MonoBehaviour
{
    [SerializeField] private Sprite[] emotionSprites;
    private Emotion _emotion;

    private void Start()
    {
        _emotion = GetComponentInChildren<Emotion>();
    }

    public void CalculateFace(Food food)
    {
        if (food.GetTaste() == ETaste.Toxic)
        {
            SetEmotion(ETaste.Toxic);
            StageManager.instance.LooseGimme();
            return;
        }

        SetEmotion(food.GetTaste());
    }
    
    private void SetEmotion(ETaste emotionType)
    {
        _emotion.SetEmotion(emotionSprites[(int) emotionType+1]);
    }
    
    public void ResetFace()
    {
        _emotion.SetEmotion(emotionSprites[0]);
    }
}
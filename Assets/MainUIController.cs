using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainUIController : MonoBehaviour
{
    private FaceUIController faceUIController;
    private PassUIController passUIController;
    private TMP_Text scoreText;
    
    private int score;
    
    private void Start()
    {
        faceUIController = GetComponentInChildren<FaceUIController>();
        passUIController = GetComponentInChildren<PassUIController>();
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TMP_Text>();
    }
    
    public void SetEmotion(Food food)
    {
        faceUIController.CalculateFace(food);
    }
    
    public void ResetEmotion()
    {
        faceUIController.ResetFace();
    }
    
    public void ResetTools()
    {
        passUIController.ResetChopsticks();
    }
    
    public void AddScore(int _score)
    {
        score += _score;
        
        if(score < 0)
            score = 0;
        
        scoreText.text = "Score: " + score;
    }
}

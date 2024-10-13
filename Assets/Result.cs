using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField] private TMP_Text foodCountText;
    [SerializeField] private TMP_Text gimiCountText;
    [SerializeField] private TMP_Text resultPointText;
    [SerializeField] private GameObject gameoverPanel;
    
    [SerializeField] private GameObject imageButton;
    [SerializeField] private GameObject popup;
    
    private int foodPoint;
    private int gimiCount;
    private int resultPoint;
    
    private void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        foodPoint = Managers.Game.foodPoint;
        gimiCount = Managers.Game.gimiCount;
        resultPoint = Managers.Game.resultPoint;
        
        SetResult(foodPoint, gimiCount, resultPoint);

        if (foodPoint < 2000)
        {
            imageButton.SetActive(false);
            popup.SetActive(false);
        }
        
        StartCoroutine(GameOverCoroutine());
        Managers.Sound.StopBGM();
        Managers.Sound.StopSFX();
        Managers.Sound.PlaySFX("ScoreScreen");
    }

    public void SetResult(int food, int gimi, int point)
    {
        foodCountText.text = food.ToString();
        gimiCountText.text = gimi.ToString();
        resultPointText.text = "+" + point;
    }
    
    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(2f);
        gameoverPanel.SetActive(true);
    }
}

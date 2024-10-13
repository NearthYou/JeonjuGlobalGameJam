using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int foodPoint;
    public int gimiCount;
    public int resultPoint
    {
        get => foodPoint + GimiPoint(gimiCount);
    }

    private void Start()
    {
        Managers.Sound.SetBGMVolume(1);
        Managers.Sound.PlayBGM("Main");
    }

    private int GimiPoint(int _gimiCount)
    {
        switch (_gimiCount)
        {
            case 1:
                return 50;
                break;
            case 2:
                return 150;
                break;
            case 3:
                return 350;
                break;
            default:
                break;
        }

        return 0;
    }
    
    public void SetResult(int _foodPoint, int _gimiCount)
    {
        foodPoint = _foodPoint;
        gimiCount = _gimiCount;
    }
    
    public void StartGame()
    {
        // 게임 시작
        SceneManager.LoadScene(1);
    }
    
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : Singleton<StageManager>
{
    private FoodSpawner foodSpawner;
    private MainUIController mainUIController;
    private GimmeController gimmeController;
    private int stageIndex;
    private int foodPoint;
    private int peopleCount;

    private int normalCount;

    [SerializeField] private SpriteRenderer king;
    [SerializeField] private Sprite kingDeadSprite;
    
    private bool isEat;

    public bool IsEat => isEat;

    private bool isSend;
    private bool isSpreadFood;
    
    public bool IsSpreadFood => isSpreadFood;

    public Food CurrentFood { get; private set; }
    
    private void Start()
    {
        foodSpawner = GameObject.FindGameObjectWithTag("FoodSpawner").GetComponent<FoodSpawner>();
        mainUIController = GameObject.FindGameObjectWithTag("MainUI").GetComponent<MainUIController>();
        gimmeController = GameObject.FindGameObjectWithTag("GimmesController").GetComponent<GimmeController>();
        peopleCount = 3;
        
        SpawnFood();
        
        Managers.Sound.PlayBGM("InGame");
    }
    
    private void SpawnFood()
    {
        CurrentFood = foodSpawner.SpawnFood();
    }

    public void EatGimme()
    {
        if (isEat)
            return;
        
        mainUIController.SetEmotion(CurrentFood);
        isEat = true;
    }
    
    public IEnumerator SendFood(GameObject stamp)
    {
        if (CurrentFood == null || isSend)
            yield return null;
        
        isSend = true;
        foodSpawner.ClearFood(CurrentFood);
        
        CalculatePointForSend();

        if (peopleCount == 0)
        {
            StartCoroutine(GameOverCoroutine());
        }
        
        stageIndex++;
        if (stageIndex > 8)
        {
            // 점수
            StartCoroutine(GameClearCoroutine());
            yield return null;
        }
        Debug.Log(stageIndex);
        
        yield return new WaitForSeconds(1.5f);
        mainUIController.ResetEmotion();
        mainUIController.ResetTools();
        stamp.SetActive(false);
        Reset();
        SpawnFood();
    }

    private void CalculatePointForSend()
    {
        if (CurrentFood.GetTaste() == ETaste.Toxic)
        {
            StartCoroutine(GameOverCoroutine());
        }
        
        if(CurrentFood.GetTaste() == ETaste.None)
        {
            foodPoint += 500;
            mainUIController.AddScore(500);
            normalCount++;

            // if (normalCount >= 4)
            //     StartCoroutine(GameClearCoroutine());
        }
        else
        {
            foodPoint -= 350;
            mainUIController.AddScore(-350);
            LooseGimme();
        }
    }
    
    public IEnumerator TrashFood(GameObject stamp)
    {
        if (CurrentFood == null || isSend)
            yield return null;

        isSend = true;
        foodSpawner.ClearFood(CurrentFood);
        CalculatePointTrash();
        
        stageIndex++;
        if (stageIndex > 8)
        {
            // 점수
            StartCoroutine(GameClearCoroutine());
            yield return null;
        }
        Debug.Log(stageIndex);

        yield return new WaitForSeconds(1.5f);
        mainUIController.ResetEmotion();
        mainUIController.ResetTools();
        stamp.SetActive(false);
        Reset();
        SpawnFood();
    }
    
    private void CalculatePointTrash()
    {
        if(CurrentFood.GetTaste() == ETaste.Toxic)
        {
            foodPoint += 500;
            mainUIController.AddScore(500);
        }
        else if(CurrentFood.GetTaste() == ETaste.None)
        {
            foodPoint -= 300;
            mainUIController.AddScore(-300);
        }
        else
        {
            foodPoint += 100;
            mainUIController.AddScore(100);
        }
    }

    public void LooseGimme()
    {
        peopleCount--;
        
        gimmeController.MoveGimmes();
        if(peopleCount == 0)
        {
            
        }
    }
    
    public void SpreadFood()
    {
        if (CurrentFood == null || isSpreadFood)
            return;
        
        isSpreadFood = true;
    }

    private void Reset()
    {
        isSend = false;
        isEat = false;
        isSpreadFood = false;
        CurrentFood = null;
    }
    
    public IEnumerator GameOverCoroutine()
    {
        Managers.Sound.StopBGM();
        Managers.Sound.StopSFX();
        Managers.Sound.PlaySFX("GameOver");
        king.sprite = kingDeadSprite;
        
        if(foodPoint < 0)
            foodPoint = 0;
        Managers.Game.SetResult(foodPoint, peopleCount);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(2);
    }
    
    private IEnumerator GameClearCoroutine()
    {
        Managers.Sound.StopBGM();
        Managers.Sound.StopSFX();
        Managers.Sound.PlaySFX("GameOver");
        
        if(foodPoint < 0)
            foodPoint = 0;
        Managers.Game.SetResult(foodPoint, peopleCount);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(2);
    }
}
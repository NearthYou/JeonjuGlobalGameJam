using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MoreMountains.Tools;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private FoodSO foodSO;
    
    private GameObject foodsParent;
    private List<FoodInfo> foodList = new List<FoodInfo>();

    private void Awake()
    {
        foodsParent = GameObject.FindGameObjectWithTag("FoodsParent");
        foodSO = Resources.Load<FoodSO>("SO/FoodSO");
        GenerateFoodList();
    }

    private void GenerateFoodList()
    {
        foodList.AddRange(foodList);
        
        for (int i = 0; i < 9; i++)
        {
            foodList.Add(foodSO.foods[Random.Range(0, foodSO.foods.Length)]);
        }
        
        foodList.MMShuffle();
    }

    public Food SpawnFood()
    {
        var currentFood = Instantiate(foodPrefab, transform.position, 
            Quaternion.identity, foodsParent.transform).GetComponent<Food>();

        if (foodList != null)
        {
            currentFood.SetFoodInfo(foodList[0]);
            foodList.RemoveAt(0);
        }

        currentFood.MoveOut(transform.position + Vector3.down * 5.25f, 1f);
        
        return currentFood;
    }
    
    public void ClearFood(Food food)
    {
        if (food != null)
        {
            food.MoveIn(1f);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodSO", menuName = "Scriptable Object/FoodSO")]
public class FoodSO : ScriptableObject
{
    public FoodInfo[] foods;
}

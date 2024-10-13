using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class FoodInfo
{
    public string _name;
    public Sprite _image;
    public int salty; 
    public int spicy;
    public int sour;
    public int toxic;
}
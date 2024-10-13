using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging;

    public bool IsDragging
    {
        get => isDragging;
        set => isDragging = value;
    }
}

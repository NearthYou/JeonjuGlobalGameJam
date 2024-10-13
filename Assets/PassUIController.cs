using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class PassUIController : MonoBehaviour
{
    private PassButton[] _passButtons;
    [SerializeField] private Chopsticks _chopsticks;
    
    public void ResetChopsticks()
    {
        _chopsticks.ResetChopsticks();
    }
}
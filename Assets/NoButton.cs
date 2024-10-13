using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoButton : MonoBehaviour
{
    Button button;
    // Start is called before the first frame update
    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            Managers.Game.ExitGame();
        });
    }
}

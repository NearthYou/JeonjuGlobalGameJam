using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GimmeController : MonoBehaviour
{
    private List<GameObject> gimmes = new List<GameObject>();
    private List<Vector3> positions = new List<Vector3>();
    private int peopleCount;

    public int PeopleCount
    {
        get => peopleCount;
        set => peopleCount = value;
    }

    private void Start()
    {
        peopleCount = 3;

        for (int i = 0; i < peopleCount; i++)
        {
            gimmes.Add(transform.GetChild(i).gameObject);
            positions.Add(transform.GetChild(i).transform.position);
        }
        
        gimmes[0].GetComponent<Gimme>().ChangeSprite();
    }
    
    public void MoveGimmes()
    {
        for (int i = 1; i < gimmes.Count; i++)
        {
            gimmes[i].GetComponent<Gimme>().Move(positions[i - 1]);
        }

        var gimme = gimmes[0];
        gimme.GetComponent<Gimme>().Delete();
        gimmes.Remove(gimme);

        if (gimmes.Count == 0)
        {
            StartCoroutine(StageManager.instance.GameOverCoroutine());
            return;
        }
        
        gimmes[0]?.GetComponent<Gimme>().ChangeSprite();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBank : MonoBehaviour
{
    //public GameObject result1, result2, result3, result4, result5, result6;

    public GameObject[] results;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = GameManager.instance.players.Count-1; i > GameManager.instance.currPlayers-1; i--)
        {
            results[i].SetActive(false);
        }
    }

}

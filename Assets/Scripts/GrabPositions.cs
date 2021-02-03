using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPositions : MonoBehaviour
{
    #region Singleton

    public static GrabPositions instance;
    public List<Transform> boardPositions = new List<Transform>();

    private void Awake()
    {
        instance = this;

        GameObject[] boardPos = GameObject.FindGameObjectsWithTag("boardPos");
        for (int i = 0; i < boardPos.Length; i++)
        {
            boardPositions.Add(boardPos[i].transform);
        }
    }

    #endregion
}

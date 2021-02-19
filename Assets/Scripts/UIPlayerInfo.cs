using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerInfo : MonoBehaviour
{

    public GameObject Player1Info;
    public GameObject Player2Info;
    public GameObject Player3Info;
    public GameObject Player4Info;
    public GameObject Player5Info;
    public GameObject Player6Info;

    private PlayerInfo[] playersInfo;
    private GameObject[] playersInfoUI;

    private int playerAmt;

    void Start()
    {
        playerAmt = GameManager.instance.currPlayers;

        playersInfo = GameObject.FindObjectsOfType<PlayerInfo>();

        playersInfoUI = new GameObject[] { Player1Info, Player2Info, Player3Info, Player4Info, Player5Info, Player6Info };

        checkPlayerCount();

        setPlayerNameAndAvatar();
    }

    private void setPlayerNameAndAvatar()
    {
        for (int i = 0; i < playerAmt; i++)
        {
            playersInfoUI[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playersInfo[i].playerName;
        }
    }

    private void checkPlayerCount()
    {
        for (int i = playersInfoUI.Length - 1; i >= playerAmt; i--)
        {
            playersInfoUI[i].SetActive(false);
        }
    }
}

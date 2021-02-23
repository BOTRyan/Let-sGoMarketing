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

    private List<GameObject> p1Tokens = new List<GameObject>();
    private List<GameObject> p2Tokens = new List<GameObject>();
    private List<GameObject> p3Tokens = new List<GameObject>();
    private List<GameObject> p4Tokens = new List<GameObject>();
    private List<GameObject> p5Tokens = new List<GameObject>();
    private List<GameObject> p6Tokens = new List<GameObject>();

    private PlayerInfo[] playersInfo;
    private GameObject[] playersInfoUI;

    private int playerAmt;

    void Start()
    {
        playerAmt = GameManager.instance.currPlayers;

        playersInfo = GameObject.FindObjectsOfType<PlayerInfo>();

        playersInfoUI = new GameObject[] { Player1Info, Player2Info, Player3Info, Player4Info, Player5Info, Player6Info };

        GetTokenChildren();

        checkPlayerCount();

        setPlayerNameAndAvatar();

        setTokenAmounts();
    }

    private void setTokenAmounts()
    {
        for (int i = 0; i < p1Tokens.Count; i++)
        {
            p1Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playersInfo[0].tokens[i].ToString();
        }

        for (int i = 0; i < p2Tokens.Count; i++)
        {
            p2Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playersInfo[1].tokens[i].ToString();
        }

        for (int i = 0; i < p3Tokens.Count; i++)
        {
            p3Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playersInfo[2].tokens[i].ToString();
        }

        for (int i = 0; i < p4Tokens.Count; i++)
        {
            p4Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playersInfo[3].tokens[i].ToString();
        }

        for (int i = 0; i < p5Tokens.Count; i++)
        {
            p5Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playersInfo[4].tokens[i].ToString();
        }

        for (int i = 0; i < p6Tokens.Count; i++)
        {
            p6Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playersInfo[5].tokens[i].ToString();
        }
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

    private void GetTokenChildren()
    {
        for (int i = 0; i < Player1Info.transform.childCount; i++)
        {
            p1Tokens.Add(Player1Info.transform.GetChild(i).gameObject);
        }
        p1Tokens.RemoveAt(0);

        for (int i = 0; i < Player2Info.transform.childCount; i++)
        {
            p2Tokens.Add(Player2Info.transform.GetChild(i).gameObject);
        }
        p2Tokens.RemoveAt(0);

        for (int i = 0; i < Player3Info.transform.childCount; i++)
        {
            p3Tokens.Add(Player3Info.transform.GetChild(i).gameObject);
        }
        p3Tokens.RemoveAt(0);

        for (int i = 0; i < Player4Info.transform.childCount; i++)
        {
            p4Tokens.Add(Player4Info.transform.GetChild(i).gameObject);
        }
        p4Tokens.RemoveAt(0);

        for (int i = 0; i < Player5Info.transform.childCount; i++)
        {
            p5Tokens.Add(Player5Info.transform.GetChild(i).gameObject);
        }
        p5Tokens.RemoveAt(0);

        for (int i = 0; i < Player6Info.transform.childCount; i++)
        {
            p6Tokens.Add(Player6Info.transform.GetChild(i).gameObject);
        }
        p6Tokens.RemoveAt(0);
    }
}

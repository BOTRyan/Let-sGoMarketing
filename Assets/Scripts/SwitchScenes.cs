using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    #region Singleton

    public static SwitchScenes instance;
    public int SceneIndex = 0;

    private void Awake()
    {
        instance = this;
    }

    private bool canStart = false;
    public bool nameChangedNeeded = false;

    private PlayerInfo tempInfo;
    private PlayerInfo tempInfoComp;


    public void goToHowTo()
    {
        for (int i = 0; i < GameManager.instance.currPlayers; i++)
        {
            tempInfo = GameManager.instance.players[i].GetComponent<PlayerInfo>();

            for (int j = 0; j < GameManager.instance.players.Count; j++)
            {
                tempInfoComp = GameManager.instance.players[j].GetComponent<PlayerInfo>();

                if (tempInfo.playerName == tempInfoComp.playerName && tempInfo.GetComponent<PlayerMovement>().yourPlayerNum != tempInfoComp.GetComponent<PlayerMovement>().yourPlayerNum)
                {
                    nameChangedNeeded = true;
                    GameManager.instance.playerInputs[i].textComponent.color = new Color(.75f, 0, 0);
                    GameManager.instance.playerInputs[j].textComponent.color = new Color(.75f, 0, 0);
                }
            }

            if (tempInfo.avatar != null && tempInfo.playerName != "Add Name" && tempInfo.playerName != "" && !nameChangedNeeded)
            {
                canStart = true;
            }
            else
            {
                canStart = false;
                if (tempInfo.playerName == "" || tempInfo.playerName == "Add Name")
                {
                    GameManager.instance.playerInputs[i].text = "Add Name";
                    GameManager.instance.playerInputs[i].textComponent.color = new Color(.75f, 0, 0);
                }

                if (tempInfo.avatar == null)
                {
                    GameManager.instance.bulldogButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().color = new Color(.75f, 0, 0);
                }
                break;
            }
        }

        if (canStart)
        {
            SceneManager.LoadScene("howToScene");
        }
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("gameScene");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("startScene");
    }

    #endregion
}

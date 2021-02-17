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

    public void BeginGame()
    {
        for (int i = 0; i < GameManager.instance.currPlayers; i++)
        {
            PlayerInfo tempInfo = GameManager.instance.players[i].GetComponent<PlayerInfo>();

            if (tempInfo.avatar != null && tempInfo.playerName != "Add Name" && tempInfo.playerName != "")
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
            SceneManager.LoadScene("gameScene");
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("startScene");
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject playerName;
    public GameObject aTokens, gmmTokens, bdaTokens, mTokens, gdTokens, prTokens;
    public GameObject emailInput;
    public GameObject learnMore;

    private int currPlayer = 0;
    private int playerPlace = 0;
    void Start()
    {
        updatePlayers(playerPlace);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPlace > GameManager.instance.currPlayers - 1) SceneManager.LoadScene("endScene");
        if (playerPlace > GameManager.instance.currPlayers - 1) SceneManager.LoadScene("careerChoiceScene");
    }

    public void submitEmail()
    {
        if (emailInput.GetComponent<TMPro.TextMeshProUGUI>().text != "yourname@email.com" && emailInput.GetComponent<TMPro.TextMeshProUGUI>().text.Contains("@")) GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().email = emailInput.GetComponent<TMPro.TextMeshProUGUI>().text;
    }

    public void nextPlayer(TMPro.TextMeshProUGUI text)
    {
        GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().fieldChoice = text.text;
        playerPlace++;
        updatePlayers(playerPlace);
    }

    void updatePlayers(int place)
    {
        for (int i = 0; i < GameManager.instance.currPlayers; i++)
        {
            if (GameManager.instance.players[i].GetComponent<PlayerMovement>().finishPlace == place) currPlayer = i;
        }
        playerName.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().playerName;
        mTokens.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().tokens[0].ToString();
        gmmTokens.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().tokens[1].ToString();
        gdTokens.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().tokens[2].ToString();
        bdaTokens.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().tokens[3].ToString();
        prTokens.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().tokens[4].ToString();
        aTokens.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().tokens[5].ToString();

        learnMore.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().playerName + ", interested in your LGM Career choice? Want to learn more or schedule a visit to Ferris State's campus? Enter your email to find out more!";
        playerName.GetComponentInChildren<Image>().sprite = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().avatar;
    }
}

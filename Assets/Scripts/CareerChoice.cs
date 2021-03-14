using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CareerChoice : MonoBehaviour
{
    public GameObject playerName;

    public GameObject emailInput;
    public GameObject learnMore;
    public GameObject submitButton;
    public GameObject selection;

    private int currPlayer = 0;
    private int playerPlace = 0;

    private bool lower = false;

    // Start is called before the first frame update
    void Start()
    {
        updatePlayers(playerPlace);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().email != null)
        {
            learnMore.SetActive(false);
            emailInput.SetActive(false);
            submitButton.SetActive(false);
        }
        else
        {
            learnMore.SetActive(true);
            emailInput.SetActive(true);
            submitButton.SetActive(true);
        }
    }

    void updatePlayers(int place)
    {
        for (int i = 0; i < GameManager.instance.players.Count; i++)
        {
            if (GameManager.instance.players[i].GetComponent<PlayerMovement>().finishPlace == place) currPlayer = i;
        }
        playerName.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().playerName;

        learnMore.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().playerName + ", interested in your LGM Career choice? Want to learn more or schedule a visit to Ferris State's campus? Enter your email to find out more!";
        playerName.GetComponentInChildren<Image>().sprite = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().avatar;
        selection.GetComponent<TMPro.TextMeshProUGUI>().text = "Nice choice! You selected the " + GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().careerChoice + "field!";
    }
    public void submitEmail()
    {
        if (emailInput.GetComponent<TMPro.TextMeshProUGUI>().text != "yourname@email.com") GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().email = emailInput.GetComponent<TMPro.TextMeshProUGUI>().text;
    }

    public void nextPlayer()
    {
        playerPlace++;
        updatePlayers(playerPlace);
    }

    private void changeChoiceDisplay(string choice)
    {
        switch(choice)
        {
            case "Graphic Design":
                break;
            case "Public Relations":
                break;
            case "Graphic Media Management":
                break;
            case "Advertising":
                break;
            case "Business Data Analytics":
                break;
            case "Marketing":
                break;
        }
    }

    public void shiftChoices()
    {
        if(!lower)
        {
            lower = true;
        }
    }
}

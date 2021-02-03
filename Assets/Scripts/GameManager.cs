using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    private List<string> playerNames = new List<string>();
    private List<InputField> playerInputs = new List<InputField>();
    private List<Button> bulldogButtons = new List<Button>();
    private int currPlayers = 3;

    public GameObject background;
    public int[][] playerInfo;
    public InputField player1, player2, player3, player4, player5, player6;
    public Button bulldog1, bulldog2, bulldog3, bulldog4, bulldog5, bulldog6;
    public Button addPlayerButton, removePlayerButton, playButton;

    public int currPlayerTurn = 1;

    // Start is called before the first frame update
    void Start()
    {
        bulldogButtons.Add(bulldog1);
        bulldogButtons.Add(bulldog2);
        bulldogButtons.Add(bulldog3);
        bulldogButtons.Add(bulldog4);
        bulldogButtons.Add(bulldog5);
        bulldogButtons.Add(bulldog6);
        playerInputs.Add(player1);
        playerInputs.Add(player2);
        playerInputs.Add(player3);
        playerInputs.Add(player4);
        playerInputs.Add(player5);
        playerInputs.Add(player6);
        for(int i = 0; i < playerInputs.Count; i++)
        {
            playerNames.Add(playerInputs[i].textComponent.text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            playerNames[0] = player1.textComponent.text;
            playerNames[1] = player2.textComponent.text;
            playerNames[2] = player3.textComponent.text;
            playerNames[3] = player4.textComponent.text;
            playerNames[4] = player5.textComponent.text;
            playerNames[5] = player6.textComponent.text;
        }

    }
    public void openBulldogSelection(Button b)
    {

    }

    public void addNewPlayer()
    {
        if(currPlayers < 6)
        {
            currPlayers++;
            for(int i = 0; i < currPlayers; i++)
            {
                bulldogButtons[i].GetComponent<Image>().enabled = true;
                bulldogButtons[i].GetComponent<Button>().enabled = true;
                bulldogButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().enabled = true;
                playerInputs[i].GetComponent<Image>().enabled = true;
                playerInputs[i].GetComponent<InputField>().interactable = true;
                playerInputs[i].GetComponent<InputField>().enabled = true;
                playerInputs[i].GetComponent<InputField>().textComponent.enabled = true;
            }
            updateButtonLocations();
        }
    }
    public void removePlayer()
    {
        if(currPlayers > 1)
        {
            currPlayers--;
            for(int i = 5; i > currPlayers - 1; i--)
            {
                bulldogButtons[i].GetComponent<Image>().enabled = false;
                bulldogButtons[i].GetComponent<Button>().enabled = false;
                bulldogButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().enabled = false;
                playerInputs[i].GetComponent<Image>().enabled = false;
                playerInputs[i].GetComponent<InputField>().interactable = false;
                playerInputs[i].GetComponent<InputField>().enabled = false;
                playerInputs[i].GetComponent<InputField>().textComponent.enabled = false;
            }
            updateButtonLocations();
        }
    }
    private void updateButtonLocations()
    {
        Vector3 temp = addPlayerButton.transform.position;
        Vector3 temp2 = playButton.transform.position;
        switch (currPlayers)
        {
            case 1:
            case 2:
            case 3:
                temp = new Vector3(addPlayerButton.transform.position.x, 271.5f, addPlayerButton.transform.position.z);
                addPlayerButton.transform.position = temp;
                background.transform.localScale = new Vector3(1.25f, 1.25f, 1);
                background.transform.position = new Vector3(background.transform.position.x, 395f, background.transform.position.z);
                
                break;
            case 4:
                temp = new Vector3(addPlayerButton.transform.position.x, 221.5f, addPlayerButton.transform.position.z);
                addPlayerButton.transform.position = temp;
                background.transform.localScale = new Vector3(1.25f, 1.43f, 1);
                background.transform.position = new Vector3(background.transform.position.x, 369.8f, background.transform.position.z);
                break;
            case 5:
                temp = new Vector3(addPlayerButton.transform.position.x, 171.5f, addPlayerButton.transform.position.z);
                addPlayerButton.transform.position = temp;
                background.transform.localScale = new Vector3(1.25f, 1.61f, 1);
                background.transform.position = new Vector3(background.transform.position.x, 344.8f, background.transform.position.z);

                break;
            case 6:
                temp = new Vector3(addPlayerButton.transform.position.x, 125.5f, addPlayerButton.transform.position.z);
                addPlayerButton.transform.position = temp;
                background.transform.localScale = new Vector3(1.25f, 1.79f, 1);
                background.transform.position = new Vector3(background.transform.position.x, 320.5f, background.transform.position.z);

                break;
        }
    }
}

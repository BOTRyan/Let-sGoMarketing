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
            GameObject[] objs = GameObject.FindGameObjectsWithTag("sceneManager");
            if (objs.Length > 1) Destroy(this.gameObject);
            DontDestroyOnLoad(this.gameObject);
    }

    #endregion

    private List<string> playerNames = new List<string>();
    public List<InputField> playerInputs = new List<InputField>();
    public List<Button> bulldogButtons = new List<Button>();
    public int currPlayers = 3;

    public Canvas screen;
    public GameObject background3, background4, background5, background6;
    public GameObject bulldogMenu;
    public List<GameObject> players = new List<GameObject>();

    public InputField player1Name, player2Name, player3Name, player4Name, player5Name, player6Name;
    public Button bulldog1, bulldog2, bulldog3, bulldog4, bulldog5, bulldog6;
    public Button addPlayerButton, removePlayerButton, playButton;
    public GameObject player1, player2, player3, player4, player5, player6;
    public GameObject player1Avatar, player2Avatar, player3Avatar, player4Avatar, player5Avatar, player6Avatar;
    public List<GameObject> avatarObjects = new List<GameObject>();

    public int currPlayerTurn = 1;
    public int playersDone = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            bulldogButtons.Add(bulldog1);
            bulldogButtons.Add(bulldog2);
            bulldogButtons.Add(bulldog3);
            bulldogButtons.Add(bulldog4);
            bulldogButtons.Add(bulldog5);
            bulldogButtons.Add(bulldog6);
            playerInputs.Add(player1Name);
            playerInputs.Add(player2Name);
            playerInputs.Add(player3Name);
            playerInputs.Add(player4Name);
            playerInputs.Add(player5Name);
            playerInputs.Add(player6Name);
            background3.GetComponent<Image>().enabled = true;
            background4.GetComponent<Image>().enabled = false;
            background5.GetComponent<Image>().enabled = false;
            background6.GetComponent<Image>().enabled = false;
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);
            players.Add(player5);
            players.Add(player6);
            avatarObjects.Add(player1Avatar);
            avatarObjects.Add(player2Avatar);
            avatarObjects.Add(player3Avatar);
            avatarObjects.Add(player4Avatar);
            avatarObjects.Add(player5Avatar);
            avatarObjects.Add(player6Avatar);
            for (int i = 0; i < players.Count; i++)
            {
                players[i].GetComponent<PlayerInfo>().avatar = null;
            }

            for (int i = 0; i < playerInputs.Count; i++)
            {
                playerNames.Add(playerInputs[i].textComponent.text);
            }
            setBulldogVis(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            playerNames[0] = player1Name.textComponent.text;
            playerNames[1] = player2Name.textComponent.text;
            playerNames[2] = player3Name.textComponent.text;
            playerNames[3] = player4Name.textComponent.text;
            playerNames[4] = player5Name.textComponent.text;
            playerNames[5] = player6Name.textComponent.text;

            for (int i = 0; i < avatarObjects.Count; i++)
            {
                avatarObjects[i].GetComponent<Image>().sprite = players[i].GetComponent<PlayerInfo>().avatar;
            }
            for (int i = 0; i < playerNames.Count; i++)
            {
                players[i].GetComponent<PlayerInfo>().playerName = playerNames[i];
            }
        }


        if (currPlayerTurn > currPlayers)
        {
            currPlayerTurn = 1;
            CameraControl.instance.targetPosY = CameraControl.instance.p1.camOffset;
            CameraControl.instance.jumpToOnce = false;
        }

        if (playersDone >= currPlayers)
        {
            SceneManager.LoadScene("endScene");
        }
    }
    public void openBulldogSelection(Button b)
    {
        bulldogMenu.GetComponent<AvatarMenu>().currButton = b;
        setBulldogVis(!bulldogMenu.activeSelf);
    }

    public void addNewPlayer()
    {
        if (currPlayers < 6)
        {
            currPlayers++;
            for (int i = 0; i < currPlayers; i++)
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
        if (currPlayers > 1)
        {
            currPlayers--;
            for (int i = 5; i > currPlayers - 1; i--)
            {
                bulldogButtons[i].GetComponent<Image>().enabled = false;
                bulldogButtons[i].GetComponent<Button>().enabled = false;
                bulldogButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().enabled = false;
                playerInputs[i].GetComponent<Image>().enabled = false;
                playerInputs[i].GetComponent<InputField>().interactable = false;
                playerInputs[i].GetComponent<InputField>().enabled = false;
                playerInputs[i].GetComponent<InputField>().textComponent.enabled = false;
                players[i].GetComponent<PlayerInfo>().avatar = null;
                avatarObjects[i].GetComponent<Image>().enabled = false;
                if (bulldogMenu.GetComponent<AvatarMenu>().currButton == bulldogButtons[i]) setBulldogVis(false);
            }
            updateButtonLocations();
        }
    }
    private void updateButtonLocations()
    {
        Vector3 temp = addPlayerButton.transform.position;
        switch (currPlayers)
        {
            case 1:
                currPlayers = 1;
                break;
            case 2:
                currPlayers = 2;
                break;
            case 3:
                temp = new Vector3(addPlayerButton.transform.position.x, screen.transform.position.y * .8f + screen.GetComponent<CanvasScaler>().referenceResolution.y * .02f, addPlayerButton.transform.position.z);
                addPlayerButton.transform.position = temp;
                background3.GetComponent<Image>().enabled = true;
                background4.GetComponent<Image>().enabled = false;
                background5.GetComponent<Image>().enabled = false;
                background6.GetComponent<Image>().enabled = false;
                currPlayers = 3;
                break;
            case 4:
                temp = new Vector3(addPlayerButton.transform.position.x, screen.transform.position.y * .65f + screen.GetComponent<CanvasScaler>().referenceResolution.y * .02f, addPlayerButton.transform.position.z);
                addPlayerButton.transform.position = temp;
                background3.GetComponent<Image>().enabled = false;
                background4.GetComponent<Image>().enabled = true;
                background5.GetComponent<Image>().enabled = false;
                background6.GetComponent<Image>().enabled = false;
                currPlayers = 4;
                break;
            case 5:
                temp = new Vector3(addPlayerButton.transform.position.x, screen.transform.position.y * .5f + screen.GetComponent<CanvasScaler>().referenceResolution.y * .02f, addPlayerButton.transform.position.z);
                addPlayerButton.transform.position = temp;
                background3.GetComponent<Image>().enabled = false;
                background4.GetComponent<Image>().enabled = false;
                background5.GetComponent<Image>().enabled = true;
                background6.GetComponent<Image>().enabled = false;
                currPlayers = 5;
                break;
            case 6:
                temp = new Vector3(addPlayerButton.transform.position.x, screen.transform.position.y * .35f + screen.GetComponent<CanvasScaler>().referenceResolution.y * .02f, addPlayerButton.transform.position.z);
                addPlayerButton.transform.position = temp;
                background3.GetComponent<Image>().enabled = false;
                background4.GetComponent<Image>().enabled = false;
                background5.GetComponent<Image>().enabled = false;
                background6.GetComponent<Image>().enabled = true;
                currPlayers = 6;
                break;
        }
    }

    public void setBulldogVis(bool vis)
    {
        if (vis)
        {
            bulldogMenu.SetActive(true);
        }
        else
        {
            bulldogMenu.SetActive(false);
        }
    }
}

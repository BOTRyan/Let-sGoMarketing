using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CareerChoice : MonoBehaviour
{
    public GameObject playerName;

    public GameObject emailInput;
    public GameObject learnMore;
    public GameObject submitButton;
    public GameObject selection;

    public GameObject careerOptionLeft;
    public GameObject careerOptionMid;
    public GameObject careerOptionRight;

    public GameObject confirmButton;
    public GameObject congrats;

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
        if (GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().fieldChoice != null) print(GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().fieldChoice);
        if (GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().email != null)
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
        changeChoiceDisplay(GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().fieldChoice);

    }

    void updatePlayers(int place)
    {
        for (int i = 0; i < GameManager.instance.currPlayers; i++)
        {
            if (GameManager.instance.players[i].GetComponent<PlayerMovement>().finishPlace == place) currPlayer = i;
        }
        playerName.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().playerName;

        learnMore.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().playerName + ", interested in your LGM Career choice? Want to learn more or schedule a visit to Ferris State's campus? Enter your email to find out more!";
        playerName.GetComponentInChildren<Image>().sprite = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().avatar;
        selection.GetComponent<TMPro.TextMeshProUGUI>().text = "Nice choice! You selected the " + GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().fieldChoice + " field!";
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
        switch (choice)
        {
            case "Graphic Design":
                careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-purple1");
                careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-red2");
                careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-red3");

                break;
            case "Public Relations":
                if (lower)
                {
                    careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-yellow1");
                    careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-yellow2");
                    careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-yellow4");
                }
                else
                {
                    careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue4");
                    careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue5");
                    careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue6");
                }
                break;
            case "Graphic Media Management":

                careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-green1");
                careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-green2");
                careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-green3");

                break;
            case "Advertising":
                if (lower)
                {
                    careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue1");
                    careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue2");
                    careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue3");
                }
                else
                {
                    careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue4");
                    careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue7");
                    careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue8");
                }

                break;
            case "Business Data Analytics":
                careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-pink1");
                careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-pink2");
                careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-pink3");

                break;
            case "Marketing":
                if (lower)
                {
                    careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-purple1");
                    careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-purple2");
                    careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-purple3");
                }
                else
                {
                    careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue1");
                    careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue2");
                    careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue3");
                }
                break;
        }
    }

    public void shiftChoices()
    {

        lower = !lower;

    }


    public void goBack()
    {
        SceneManager.LoadScene("endScene");

    }

    public void confirmChoice(GameObject g)
    {
        confirmButton.SetActive(true);       
        

        GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().careerChoice = g.GetComponent<Image>().sprite;
        
           
    }

    public void congratsPrompt()
    {
        congrats.SetActive(true);


    }

}

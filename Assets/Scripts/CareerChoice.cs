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

    public GameObject congratsPlayer, greatJobTitle, congratsEmailInput, congratsLearnMore, congratsSubmit;
    private string career;
    public Sprite advertAccount, bpManager, salesProf, marketResearchS, mDirector, salesManage, freelancer, healthMarketer, gmTech, gmTechSales, customerProject, bdAnalyst, marketResearchA, sysArch, creativeDirect, researchDirect, mPlanner, uxDesign, uiDesign, contentStrategist, corpCommManager, prDirect;

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
        if (playerPlace >= GameManager.instance.currPlayers) SceneManager.LoadScene("resultsScene");
        updatePlayers(playerPlace);
        congrats.SetActive(false);
        confirmButton.SetActive(false);
        careerOptionMid.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        careerOptionRight.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        careerOptionLeft.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().careerChoice = null;
    }

    private void changeChoiceDisplay(string choice)
    {
        switch (choice)
        {
            case "Design":
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
        if(g == careerOptionLeft)
        {
            careerOptionMid.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
            careerOptionRight.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
            careerOptionLeft.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        }
        else if(g == careerOptionMid)
        {
            careerOptionMid.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            careerOptionRight.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
            careerOptionLeft.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
        }
        else if(g == careerOptionRight)
        {
            careerOptionMid.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
            careerOptionRight.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            careerOptionLeft.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
        }

    }

    public void congratsPrompt()
    {
        congrats.SetActive(true);
        Sprite shortcut = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().careerChoice;
        // switch case to check sprites
        if (shortcut == advertAccount) career = "Advertising Account Manager";
        else if (shortcut == bpManager) career = "Brand/Product Manager";
        else if (shortcut == salesProf) career = "Sales Professional";
        else if (shortcut == marketResearchS) career = "Marketing Research Specialist";
        else if (shortcut == mDirector) career = "Marketing Director";
        else if (shortcut == salesManage) career = "Sales Manager";
        else if (shortcut == freelancer) career = "Freelance Writer";
        else if (shortcut == healthMarketer) career = "Healthcare Marketer";
        else if (shortcut == gmTech) career = "Graphic Media Technician";
        else if (shortcut == gmTechSales) career = "Graphic Media Technical Sales Representative";
        else if (shortcut == customerProject) career = "Customer Service Project Manager";
        else if (shortcut == bdAnalyst) career = "Business Data Analyst";
        else if (shortcut == marketResearchA) career = "Market Research Analyst";
        else if (shortcut == sysArch) career = "System Architect";
        else if (shortcut == creativeDirect) career = "Creative Director";
        else if (shortcut == researchDirect) career = "Research Director";
        else if (shortcut == mPlanner) career = "Media Planner";
        else if (shortcut == uxDesign) career = "User Experience Designer";
        else if (shortcut == uiDesign) career = "User Interface Designer";
        else if (shortcut == contentStrategist) career = "Content Strategist";
        else if (shortcut == corpCommManager) career = "Corporate Communications Manager";
        else if (shortcut == prDirect) career = "Public Relations Director";
        
        greatJobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "You'll make a great " + career + "!";
        randomCongrats();

    }

    private void randomCongrats()
    {
        int randChoice = Mathf.FloorToInt(Random.Range(1, 6));
        switch(randChoice)
        {
            case 1:
                congratsPlayer.GetComponent<TMPro.TextMeshProUGUI>().text = "Nice choice, " + playerName.GetComponent<TMPro.TextMeshProUGUI>().text + "!";
                break;
            case 2:
                congratsPlayer.GetComponent<TMPro.TextMeshProUGUI>().text = "Sweet pick, " + playerName.GetComponent<TMPro.TextMeshProUGUI>().text + "!";
                break;
            case 3:
                congratsPlayer.GetComponent<TMPro.TextMeshProUGUI>().text = "Epic pick, " + playerName.GetComponent<TMPro.TextMeshProUGUI>().text + "!";
                break;
            case 4:
                congratsPlayer.GetComponent<TMPro.TextMeshProUGUI>().text = "Great pick, " + playerName.GetComponent<TMPro.TextMeshProUGUI>().text + "!";
                break;
            case 5:
                congratsPlayer.GetComponent<TMPro.TextMeshProUGUI>().text = "Prime choice, " + playerName.GetComponent<TMPro.TextMeshProUGUI>().text + "!";
                break;
        }
    }

}

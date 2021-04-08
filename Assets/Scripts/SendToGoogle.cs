using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class SendToGoogle : MonoBehaviour
{
    public GameManager manager;

    //email stuff required. Unsafe: use a burner email
    const string senderEmail = "fsu.lgm@gmail.com";
    const string webhostURL = "https://lgm-emails.000webhostapp.com/emailer.php";
    const string message = "Thanks for playing \"Let's Go Marketing!\"";

    string Name;
    string Email;
    string Field;
    string Career;
    string Color;
    string Duration;
    //tokens
    string TokenA, TokenG, TokenB, TokenM, TokenD, TokenP;
    //spaces
    string YTB, DYK, CP, BC, Normal;

    [SerializeField]
    //readonly string getURL;//currently unnecessary
    readonly string postURL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdOurHMy2joAjqGWQZaCpMzSxhaqo7eR9auIkD22Jlsea-qew/formResponse";

    void Start()//find GameManager so that the script can be attached literally anywhere and it doesn't matter (as long as the GameManager has all the data we need)
    {
        manager = FindObjectOfType<GameManager>();
    }



    IEnumerator SendMailRequestToServer(string toEmail)
    {
        /*List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        //tutorial: https://www.youtube.com/watch?v=JgFZhMnaKqE&ab_channel=MatthewVentures
        form.AddField(("name", "Name"));
        form.Add(("fromEmail", senderEmail));
        form.Add(new MultipartFormDataSection("toEmail", toEmail));
        form.Add(new MultipartFormDataSection("message", message));

        UnityWebRequest www = UnityWebRequest.Post(webhostURL, form);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) Debug.Log("error: " + www.error);
        else Debug.Log("Sent email to player");*/

        // Setup form responses
        WWWForm form = new WWWForm();
        form.AddField("name", "It's me!");
        form.AddField("fromEmail", senderEmail);
        form.AddField("toEmail", toEmail);
        form.AddField("message", message);

        // Submit form to our server, then wait
        UnityWebRequest www = UnityWebRequest.Post(webhostURL, form);
        Debug.Log("Email sent to " + toEmail);

        yield return www.SendWebRequest();

        // Print results
        /*if (www.error == null)
        {
            Debug.Log("WWW Success!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }*/
        if (www.isNetworkError || www.isHttpError) Debug.Log("error: " + www.error);
        else Debug.Log("Sent player email");
    }



    IEnumerator Post(string nameIn, string emailIn, string fieldIn, string careerIn, string colorIn, string tokenAIn, string tokenGIn, string tokenBIn, string tokenMIn, string tokenDIn, string tokenPIn, string ytbIn, string dykIn, string cpIn, string bcIn, string normalIn)
    {
        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        //look for the sections in the URL that require input. Tutorial to find that value here: https://www.youtube.com/watch?v=z9b5aRfrz7M&ab_channel=LuzanBaral
        form.Add(new MultipartFormDataSection("entry.1774318415", nameIn));
        form.Add(new MultipartFormDataSection("entry.447813241", emailIn));
        form.Add(new MultipartFormDataSection("entry.1774298051", fieldIn));
        form.Add(new MultipartFormDataSection("entry.1309134014", careerIn));
        form.Add(new MultipartFormDataSection("entry.906285824", colorIn));

        //tokens
        form.Add(new MultipartFormDataSection("entry.297539896", tokenAIn));
        form.Add(new MultipartFormDataSection("entry.285011331", tokenGIn));
        form.Add(new MultipartFormDataSection("entry.1840331461", tokenBIn));
        form.Add(new MultipartFormDataSection("entry.621689233", tokenMIn));
        form.Add(new MultipartFormDataSection("entry.1409755334", tokenDIn));
        form.Add(new MultipartFormDataSection("entry.1815462484", tokenPIn));

        //spaces
        form.Add(new MultipartFormDataSection("entry.122754949", ytbIn));
        form.Add(new MultipartFormDataSection("entry.855798970", dykIn));
        form.Add(new MultipartFormDataSection("entry.1505258852", cpIn));
        form.Add(new MultipartFormDataSection("entry.150968286", bcIn));
        form.Add(new MultipartFormDataSection("entry.483335758", normalIn));

        UnityWebRequest www = UnityWebRequest.Post(postURL, form);

        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) Debug.Log("error: " + www.error);
        else Debug.Log("Sent player data");
    }

    IEnumerator PostGameData(string durationIn)
    {
        //wait two seconds so the organization works in the Google Sheet
        yield return new WaitForSeconds(2);

        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        form.Add(new MultipartFormDataSection("entry.806798460", durationIn));

        UnityWebRequest www = UnityWebRequest.Post(postURL, form);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) Debug.Log("error: " + www.error);
        else Debug.Log("Sent game data");
    }

    public void SendData()
    {
        manager = FindObjectOfType<GameManager>();
        Debug.Log("SendData() called");
        //iterate through the list of players for their info
        for (int i = 0; i < manager.currPlayers; ++i)
        {
            Debug.Log("Getting Player " + (i + 1));
            Name = manager.players[i].GetComponent<PlayerInfo>().playerName;
            Email = manager.players[i].GetComponent<PlayerInfo>().email;
            Field = manager.players[i].GetComponent<PlayerInfo>().fieldChoice;
            Color = manager.players[i].GetComponent<PlayerInfo>().avatar.name;
            Color = Color.Substring(0, Color.IndexOf("Sit"));

            Career = manager.players[i].GetComponent<PlayerInfo>().careerChoice.name;
            switch(Career)//fill out
            {
                case "jc-blue1":
                    Career = "Advertising Account Manager";
                    break;
                case "jc-blue2":
                    Career = "Brand/Product Manager";
                    break;
                case "jc-blue3":
                    Career = "Sales Professional";
                    break;
                case "jc-blue4":
                    Career = "Marketing Research Specialist";
                    break;
                case "jc-blue5":
                    Career = "Marketing Director";
                    break;
                case "jc-blue6":
                    Career = "Sales Manager";
                    break;
                case "jc-blue7":
                    Career = "Freelance Writer";
                    break;
                case "jc-blue8":
                    Career = "Healthcare Marketer";
                    break;
                case "jc-green1":
                    Career = "Graphic Media Technician";
                    break;
                case "jc-green2":
                    Career = "Graphic Media Technical Sales Representativ";
                    break;
                case "jc-green3":
                    Career = "Customer Service Project Manager";
                    break;
                case "jc-pink1":
                    Career = "Business Data Analyst";
                    break;
                case "jc-pink2":
                    Career = "Market Research Analyst";
                    break;
                case "jc-pink3":
                    Career = "System Architect";
                    break;
                case "jc-purple1":
                    Career = "Creative Director";
                    break;
                case "jc-purple2":
                    Career = "Research Director";
                    break;
                case "jc-purple3":
                    Career = "Media Planner";
                    break;
                case "jc-red2":
                    Career = "User Experience Designer";
                    break;
                case "jc-red3":
                    Career = "User Interface Designer";
                    break;
                case "jc-yellow1":
                    Career = "Content Strategist";
                    break;
                case "jc-yellow2":
                    Career = "Corporate Communications Manager";
                    break;
                case "jc-yellow4":
                    Career = "Public Relations Director";
                    break;
            }//switch

            
            //tokens
            TokenA = manager.players[i].GetComponent<PlayerInfo>().tokens[5].ToString();
            TokenG = manager.players[i].GetComponent<PlayerInfo>().tokens[1].ToString();
            TokenB = manager.players[i].GetComponent<PlayerInfo>().tokens[3].ToString();
            TokenM = manager.players[i].GetComponent<PlayerInfo>().tokens[0].ToString();
            TokenD = manager.players[i].GetComponent<PlayerInfo>().tokens[2].ToString();
            TokenP = manager.players[i].GetComponent<PlayerInfo>().tokens[4].ToString();

            //spaces
            YTB = manager.players[i].GetComponent<PlayerInfo>().spaces[0].ToString();
            DYK = manager.players[i].GetComponent<PlayerInfo>().spaces[1].ToString();
            CP = manager.players[i].GetComponent<PlayerInfo>().spaces[2].ToString();
            BC = manager.players[i].GetComponent<PlayerInfo>().spaces[3].ToString();
            Normal = manager.players[i].GetComponent<PlayerInfo>().spaces[4].ToString();

            Debug.Log("Starting Coroutine");
            StartCoroutine(Post(Name, Email, Field, Career, Color, TokenA, TokenG, TokenB, TokenM, TokenD, TokenP, YTB, DYK, CP, BC, Normal));
            StartCoroutine(SendMailRequestToServer(Email));
        }

        //send Duration
        Duration = ((manager.gameTime)/60f).ToString();
        StartCoroutine(PostGameData(Duration));
    }//Send()


    //currently don't need get requests, but here just in case
    /*IEnumerator GetRequest()
    {
        UnityWebRequest www = UnityWebRequest.Get(getURL);

        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) Debug.Log("Error: " + www.error);
        //else{do stuff}
    }

    public void GetData()
    {
        StartCoroutine(GetRequest());
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SendToGoogle : MonoBehaviour
{
    public GameManager manager;

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
    readonly string postURL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScvQKiFGYrCZ_PsFPssE3LNG5hF7WpYuUesrL_nLQqS6v1tow/formResponse";//not the final value; Justin's test form. Need to ask Designers to make their own Google Form

    void Start()//find GameManager so that the script can be attached literally anywhere and it doesn't matter (as long as the GameManager has all the data we need)
    {
        manager = FindObjectOfType<GameManager>();
    }

    IEnumerator Post(string nameIn, string emailIn, string fieldIn, string careerIn, string colorIn, string tokenAIn, string tokenGIn, string tokenBIn, string tokenMIn, string tokenDIn, string tokenPIn, string ytbIn, string dykIn, string cpIn, string bcIn, string normalIn)
    {
        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        //look for the sections in the URL that require input. Tutorial to find that value here: https://www.youtube.com/watch?v=z9b5aRfrz7M&ab_channel=LuzanBaral
        form.Add(new MultipartFormDataSection("entry.2014565725", nameIn));
        form.Add(new MultipartFormDataSection("entry.2131894653", emailIn));
        form.Add(new MultipartFormDataSection("entry.119326422", fieldIn));
        form.Add(new MultipartFormDataSection("entry.2091551399", careerIn));
        form.Add(new MultipartFormDataSection("entry.1658428665", colorIn));

        //tokens
        form.Add(new MultipartFormDataSection("entry.1868129861", tokenAIn));
        form.Add(new MultipartFormDataSection("entry.1712409209", tokenGIn));
        form.Add(new MultipartFormDataSection("entry.1968552602", tokenBIn));
        form.Add(new MultipartFormDataSection("entry.594056184", tokenMIn));
        form.Add(new MultipartFormDataSection("entry.591368335", tokenDIn));
        form.Add(new MultipartFormDataSection("entry.276096434", tokenPIn));

        //spaces
        form.Add(new MultipartFormDataSection("entry.659316869", ytbIn));
        form.Add(new MultipartFormDataSection("entry.600528165", dykIn));
        form.Add(new MultipartFormDataSection("entry.1168000115", cpIn));
        form.Add(new MultipartFormDataSection("entry.957236386", bcIn));
        form.Add(new MultipartFormDataSection("entry.878186627", normalIn));

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
        form.Add(new MultipartFormDataSection("entry.1382100341", durationIn));

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
                    break;
                case "jc-blue4":
                    break;
                case "jc-blue5":
                    break;
                case "jc-blue6":
                    break;
                case "jc-blue7":
                    break;
                case "jc-blue8":
                    break;
                case "jc-green1":
                    break;
                case "jc-green2":
                    break;
                case "jc-green3":
                    break;
                case "jc-pink1":
                    break;
                case "jc-pink2":
                    break;
                case "jc-pink3":
                    break;
                case "jc-purple1":
                    break;
                case "jc-purple2":
                    break;
                case "jc-purple3":
                    break;
                case "jc-red2":
                    break;
                case "jc-red3":
                    break;
                case "jc-yellow1":
                    break;
                case "jc-yellow2":
                    break;
                case "jc-yellow3":
                    break;
            }//switch

            
            //tokens
            /*TokenA;
            TokenG;
            TokenB;
            TokenM;
            TokenD;
            TokenP;
            //spaces
            /*YTB;
            DYK;
            CP;
            BC;
            Normal;*/

            Debug.Log("Starting Coroutine");
            //StartCoroutine(Post(Name, Email, Field));
        }

        //game data that's been recorded. Probably need to grab from GameManager
        Duration = 69.ToString();
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

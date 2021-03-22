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
    int YTB;

    [SerializeField]
    //readonly string getURL;//currently unnecessary
    readonly string postURL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScvQKiFGYrCZ_PsFPssE3LNG5hF7WpYuUesrL_nLQqS6v1tow/formResponse";//not the final value; Justin's test form. Need to ask Designers to make their own Google Form

    void Start()//find GameManager so that the script can be attached literally anywhere and it doesn't matter (as long as the GameManager has all the data we need)
    {
        manager = FindObjectOfType<GameManager>();
    }

    IEnumerator Post(string nameIn, string emailIn, string fieldIn)
    {
        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        //look for the sections in the URL that require input. Tutorial to find that value here: https://www.youtube.com/watch?v=z9b5aRfrz7M&ab_channel=LuzanBaral
        form.Add(new MultipartFormDataSection("entry.2014565725", nameIn));
        form.Add(new MultipartFormDataSection("entry.2131894653", emailIn));
        form.Add(new MultipartFormDataSection("entry.119326422", fieldIn));
        //form.Add(new MultipartFormDataSection("entry.1833831744", careerIn));
        //purple green red pink yellow teal
        //marketing, graphic media management, design, business data analytics, public relations, advertising

        UnityWebRequest www = UnityWebRequest.Post(postURL, form);

        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) Debug.Log("error: " + www.error);
        else Debug.Log("Sent player data");
    }

    IEnumerator PostGameData(string ytbIn)
    {
        //wait two seconds so the organization works in the Google Sheet
        yield return new WaitForSeconds(2);

        List<IMultipartFormSection> form = new List<IMultipartFormSection>();

        form.Add(new MultipartFormDataSection("entry.659316869", ytbIn));

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

            Debug.Log("Starting Coroutine");
            StartCoroutine(Post(Name, Email, Field));
        }

        //game data that's been recorded. Probably need to grab from GameManager
        YTB = 1;
        StartCoroutine(PostGameData(YTB.ToString()));
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

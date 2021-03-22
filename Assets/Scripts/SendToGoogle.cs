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

    [SerializeField]
    //readonly string getURL;//currently unnecessary
    readonly string postURL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScvQKiFGYrCZ_PsFPssE3LNG5hF7WpYuUesrL_nLQqS6v1tow/formResponse";//not the final value; Justin's test form. Need to ask Designers to make their own Google Form

    void Start()//find GameManager so that the script can be attached literally anywhere and it doesn't matter (as long as the GameManager has all the data we need)
    {
        manager = FindObjectOfType<GameManager>();
    }

    IEnumerator Post(string nameIn)//will need to add email
    {
        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        //look for the sections in the URL that require input. Tutorial to find that value here: https://www.youtube.com/watch?v=z9b5aRfrz7M&ab_channel=LuzanBaral
        form.Add(new MultipartFormDataSection("entry.2014565725", nameIn));
        Debug.Log("Name added");

        UnityWebRequest www = UnityWebRequest.Post(postURL, form);

        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) Debug.Log("error: " + www.error);
        else Debug.Log("Sent player name");
    }

    public void SendData()
    {
        Debug.Log("SendData() called");
        //iterate through the list of players for their info
        for (int i = 0; i < manager.currPlayers; ++i)
        {
            Debug.Log("Getting Player " + (i + 1));
            Name = manager.players[i].GetComponent<PlayerInfo>().playerName;
            //Email = manager.players[i].GetComponent<PlayerInfo>().email;

            Debug.Log("Starting Coroutine");
            StartCoroutine(Post(Name));
        }
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

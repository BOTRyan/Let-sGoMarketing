using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenAnimation : MonoBehaviour
{
    private Vector3 buttonLocation;
    public Button[] playerButtons;
    public Transform[] purpleTokens;
    public Transform[] greenTokens;
    public Transform[] redTokens;
    public Transform[] pinkTokens;
    public Transform[] yellowTokens;
    public Transform[] blueTokens;
    public static int tokenColor;
    public Sprite tokenPurple;
    public Sprite tokenGreen;
    public Sprite tokenRed;
    public Sprite tokenPink;
    public Sprite tokenYellow;
    public Sprite tokenBlue;
    public GameObject token;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnToken("blue", (2, 3, 4), (7, 6, 5));
    }
    private Vector3 CalculatePosition(float percent)
    {
        Vector3 positionC = AnimMath.Lerp(new Vector3(0,0,0), transform.position, percent);
        Vector3 positionD = AnimMath.Lerp(transform.position,new Vector3(0, 0, 0), percent);
        Vector3 positionE = AnimMath.Lerp(positionC, positionD, percent);
        return positionE;
    }
    public void SpawnToken()
    {

    }
    public void GetButtonLocationAndColor(int value)
    {
        switch (tokenColor)
        {
            case 1:
                token.GetComponent<Image>().sprite = tokenPurple;
                break;
            case 2:
                token.GetComponent<Image>().sprite = tokenGreen;
                break;
            case 3:
                token.GetComponent<Image>().sprite = tokenRed;
                break;
            case 4:
                token.GetComponent<Image>().sprite = tokenPink;
                break;
            case 5:
                token.GetComponent<Image>().sprite = tokenYellow;
                break;
            case 6:
                token.GetComponent<Image>().sprite = tokenBlue;
                break;
        }
        switch (value)
        {
            case 1:
                //player 1
                break;
            case 2:
                //player 2
                break;
            case 3:
                //player 3
                break;
            case 4:
                //player 4
                break;
            case 5:
                //player 5
                break;
            case 6:
                //player 6
                break;
        }
    }

}

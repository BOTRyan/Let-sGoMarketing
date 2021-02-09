using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarMenu : MonoBehaviour
{
    public Button currButton;
    private List<Button> dogChoice = new List<Button>();
    public Button red, blue, green, yellow, brown, indigo;

    private bool[] isChosen = { false, false, false, false, false, false };

    // Start is called before the first frame update
    void Start()
    {
        dogChoice.Add(red);
        dogChoice.Add(blue);
        dogChoice.Add(green);
        dogChoice.Add(yellow);
        dogChoice.Add(brown);
        dogChoice.Add(indigo);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.y = currButton.transform.position.y;
        transform.position = temp;
        for (int i = 0; i < GameManager.instance.avatarObjects.Count; i++)
        {
            if(GameManager.instance.avatarObjects[i].GetComponent<Image>().sprite == GameManager.instance.avatars[GameManager.instance.playerInfo[1][i]] && GameManager.instance.avatarObjects[i].GetComponent<Image>().enabled)
            {
                isChosen[i] = true;
            }
            else
            {
                isChosen[i] = false;
            }
            
        }
        
    }

    public void setPlayerAvatar(Button b)
    {
        if(!isChosen[dogChoice.IndexOf(b)])
        {
            for (int i = 0; i < isChosen.Length; i++)
            {
                isChosen[i] = false;
            }
            
            GameManager.instance.playerInfo[1][GameManager.instance.bulldogButtons.IndexOf(currButton)] = dogChoice.IndexOf(b);
            GameManager.instance.setBulldogVis(false);
            GameManager.instance.avatarObjects[GameManager.instance.bulldogButtons.IndexOf(currButton)].GetComponent<Image>().enabled = true;
            currButton = null;
        }

    }
    
}

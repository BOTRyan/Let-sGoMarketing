using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExtraButtons : MonoBehaviour
{

    private Button button;

    
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(MainMenuClick);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(HowtoClick);
        }

    }

    void MainMenuClick()
    {
        SwitchScenes.instance.ToMainMenu();
        Destroy(GameManager.instance.gameObject);
    }

    void HowtoClick()
    {
        SwitchScenes.instance.BeginGame();
    }
}

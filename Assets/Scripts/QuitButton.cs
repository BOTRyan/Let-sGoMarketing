using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(MainMenuClick);
    }

    void MainMenuClick()
    {
        SwitchScenes.instance.ToMainMenu();
        Destroy(GameManager.instance.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public int SceneIndex = 0;

    public void BeginGame()
    {
        SceneManager.LoadScene("gameScene");
    }

    public void QuitGame()
    {

    }
}

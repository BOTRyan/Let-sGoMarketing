using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    #region Singleton

    public static SwitchScenes instance;
    public int SceneIndex = 0;

    private void Awake()
    {
        instance = this;
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("gameScene");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("startScene");
    }
    #endregion
}

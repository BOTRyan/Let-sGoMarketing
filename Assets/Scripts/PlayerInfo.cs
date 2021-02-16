using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    #region Singleton

    public static PlayerInfo instance;

    private void Awake()
    {
        instance = this;

        if(SceneManager.GetActiveScene().buildIndex != 2) DontDestroyOnLoad(this.gameObject);
    }

    #endregion

    public bool isPlaying;
    public string playerName;
    public Sprite avatar;
    public int[] tokens;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = avatar;
        GetComponentInChildren<TMPro.TextMeshPro>().text = playerName;
        if(GetComponent<PlayerMovement>().yourPlayerNum > GameManager.instance.currPlayers)
        {
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsButtons : MonoBehaviour
{
    public Button musicButt;
    public Button SFXButt;
    public Button QuitButt;
    public bool buttonsHidden = true;

    void Start()
    {
        buttonsHidden = true;
        SFXButt.gameObject.SetActive(false);
        musicButt.gameObject.SetActive(false);
        if (QuitButt) QuitButt.gameObject.SetActive(false);
    }

    void Update()
    {
        if (AudioManager.instance.musicMuted)
        {
            musicButt.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/sound-effects-off");
        }
        else
        {
            musicButt.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/sound-effects");
        }

        if (AudioManager.instance.sfxMuted)
        {
            SFXButt.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/sound-off");
        }
        else
        {
            SFXButt.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/sound");
        }

        if (buttonsHidden)
        {
            SFXButt.gameObject.SetActive(false);
            musicButt.gameObject.SetActive(false);
            if (QuitButt) QuitButt.gameObject.SetActive(false);
        }
        else
        {
            SFXButt.gameObject.SetActive(true);
            musicButt.gameObject.SetActive(true);
            if (QuitButt) QuitButt.gameObject.SetActive(true);
        }
    }

    public void switchMusic()
    {
        if (AudioManager.instance.musicMuted) AudioManager.instance.musicMuted = false;
        else AudioManager.instance.musicMuted = true;
    }

    public void switchSFX()
    {
        if (AudioManager.instance.sfxMuted) AudioManager.instance.sfxMuted = false;
        else AudioManager.instance.sfxMuted = true;
    }

    public void quitGame()
    {
        Destroy(GameManager.instance.gameObject);
        SceneManager.LoadScene("startScene");
    }

    public void buttonVisibility()
    {
        if (buttonsHidden) buttonsHidden = false;
        else buttonsHidden = true;
    }
}

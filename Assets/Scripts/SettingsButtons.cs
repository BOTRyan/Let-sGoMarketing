using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButtons : MonoBehaviour
{
    public Button musicButt;
    public Button SFXButt;
    public bool buttonsHidden = true;

    void Start()
    {
        buttonsHidden = true;
        SFXButt.gameObject.SetActive(false);
        musicButt.gameObject.SetActive(false);
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
        }
        else
        {
            SFXButt.gameObject.SetActive(true);
            musicButt.gameObject.SetActive(true);
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

    public void buttonVisibility()
    {
        if (buttonsHidden) buttonsHidden = false;
        else buttonsHidden = true;
    }
}

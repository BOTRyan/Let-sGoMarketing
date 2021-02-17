using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorCorrection : MonoBehaviour
{
    public void changeTextColorBack(InputField input)
    {
        input.GetComponent<InputField>().textComponent.color = new Color(0.8156863f, 0.7686275f, 0.772549f);
    }

    public void changeButtonColorBack(Button button)
    {
        button.GetComponentInChildren<TMPro.TextMeshProUGUI>().color= new Color(0.8156863f, 0.7686275f, 0.772549f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void feedbackSurvey()
    {

    }

    public void lgmMain()
    {
        Application.OpenURL("https://ferris.letsgo.careers");
    }

    public void playAgain()
    {
        Destroy(GameManager.instance.gameObject);
        SceneManager.LoadScene("startScene");
    }

    public void ferrisMain()
    {
        Application.OpenURL("https://business.ferris.edu/program/marketing/");
    }

    public void visitFerris()
    {
        Application.OpenURL("https://www.ferris.edu/admissions/schedule_visit.htm");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    #region Singleton

    public static EndGameManager instance;

    private void Awake()
    {
        instance = this;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("sceneManager");
        if (objs.Length > 1) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion
    private bool doOnce = true;

    public GameObject learnMore, emailInput, submitEmail, playerName;
    private Sprite advertAccount, bpManager, salesProf, marketResearchS, mDirector, salesManage, freelancer, healthMarketer, gmTech, gmTechSales, customerProject, bdAnalyst, marketResearchA, sysArch, creativeDirect, researchDirect, mPlanner, uxDesign, uiDesign, contentStrategist, corpCommManager, prDirect;

    private int currPlayer = 0;
    private int playerPlace = 0;

    void Start()
    {

    }

    void Update()
    {

    }

    void refreshObjects()
    {
        if (doOnce)
        {
            // Re-assign game objects based on tags and scene
            doOnce = false;
        }
    }
}

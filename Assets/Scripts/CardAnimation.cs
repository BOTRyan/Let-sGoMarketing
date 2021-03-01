﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class CardAnimation : MonoBehaviour
{

    #region Singleton

    public static CardAnimation instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Animator CardAnimator;
    public Animator SettingsAnimator;

    public Sprite didYouKnowCardBackBlue;
    public Sprite didYouKnowCardBackGreen;
    public Sprite didYouKnowCardBackYellow;
    public Sprite didYouKnowCardBackRed;
    public Sprite didYouKnowCardBackPink;
    public Sprite didYouKnowCardBackPurple;

    public Sprite brandCrisisCardBack;

    public Sprite careerPointCardBack;

    public Sprite youreTheBoss;

    public GameObject cardBack;
    public GameObject cardFront;

    public GameObject careerButtons;
    public GameObject didYouButtons;
    public GameObject youreTheButtons;
    public GameObject continueButton;

    public Sprite[] brandCrisisCardFront;
    public Sprite[] brandCrisisCardFrontIdentity;

    public Sprite[] careerPointCardFront;
    public Sprite[] careerPointCardFrontIdentity;

    public Sprite[] youreTheBossFront;
    public Sprite[] youreTheBossFrontIdentity;

    public Sprite[] didYouKnowCardFrontBlue;
    public Sprite[] didYouKnowCardFrontGreen;
    public Sprite[] didYouKnowCardFrontYellow;
    public Sprite[] didYouKnowCardFrontRed;
    public Sprite[] didYouKnowCardFrontPink;
    public Sprite[] didYouKnowCardFrontPurple;

    public Sprite didYouKnowButtonBlue;
    public Sprite didYouKnowButtonGreen;
    public Sprite didYouKnowButtonYellow;
    public Sprite didYouKnowButtonRed;
    public Sprite didYouKnowButtonPink;
    public Sprite didYouKnowButtonPurple;

    public GameObject[] didYouKnowButtons;
    public int playerMovementEffect = 0;
    public bool cardRead = false;
    public bool playerDoesntMove;

    private int currentBrandCrisisNumber = 0;

    private int currentCareerPointNumber = 0;

    private int currentYoureTheBossNumber = 0;

    private int currentDidYouKnowBlueNumber = 0;
    private int currentDidYouKnowGreenNumber = 0;
    private int currentDidYouKnowYellowNumber = 0;
    private int currentDidYouKnowRedNumber = 0;
    private int currentDidYouKnowPinkNumber = 0;
    private int currentDidYouKnowPurpleNumber = 0;
    private int didYouKnowTokenColor = 0;

    private PlayerInfo[] playersInfo;

    private bool p1hasTakenToken = true;
    private bool p2hasTakenToken = true;
    private bool p3hasTakenToken = true;
    private bool p4hasTakenToken = true;
    private bool p5hasTakenToken = true;
    private bool p6hasTakenToken = true;

    public int playersPressed = 0;
    public int bossColor = 0;

    public void Start()
    {
        // Knuth shuffle algorithms
        //brand crisis
        for (int t = 0; t < brandCrisisCardFront.Length; t++)
        {
            Sprite tmp = brandCrisisCardFront[t];
            int r = UnityEngine.Random.Range(t, brandCrisisCardFront.Length);
            brandCrisisCardFront[t] = brandCrisisCardFront[r];
            brandCrisisCardFront[r] = tmp;
        }
        //career point
        for (int t = 0; t < careerPointCardFront.Length; t++)
        {
            Sprite tmp = careerPointCardFront[t];
            int r = UnityEngine.Random.Range(t, careerPointCardFront.Length);
            careerPointCardFront[t] = careerPointCardFront[r];
            careerPointCardFront[r] = tmp;
        }
        //youre the boss
        for (int t = 0; t < youreTheBossFront.Length; t++)
        {
            Sprite tmp = youreTheBossFront[t];
            int r = UnityEngine.Random.Range(t, youreTheBossFront.Length);
            youreTheBossFront[t] = youreTheBossFront[r];
            youreTheBossFront[r] = tmp;
        }
        //did you know blue
        for (int t = 0; t < didYouKnowCardFrontBlue.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontBlue[t];
            int r = UnityEngine.Random.Range(t, didYouKnowCardFrontBlue.Length);
            didYouKnowCardFrontBlue[t] = didYouKnowCardFrontBlue[r];
            didYouKnowCardFrontBlue[r] = tmp;
        }
        //did you know green
        for (int t = 0; t < didYouKnowCardFrontGreen.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontGreen[t];
            int r = UnityEngine.Random.Range(t, didYouKnowCardFrontGreen.Length);
            didYouKnowCardFrontGreen[t] = didYouKnowCardFrontGreen[r];
            didYouKnowCardFrontGreen[r] = tmp;
        }
        //did you know Yellow
        for (int t = 0; t < didYouKnowCardFrontYellow.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontYellow[t];
            int r = UnityEngine.Random.Range(t, didYouKnowCardFrontYellow.Length);
            didYouKnowCardFrontYellow[t] = didYouKnowCardFrontYellow[r];
            didYouKnowCardFrontYellow[r] = tmp;
        }
        //did you know Red
        for (int t = 0; t < didYouKnowCardFrontRed.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontRed[t];
            int r = UnityEngine.Random.Range(t, didYouKnowCardFrontRed.Length);
            didYouKnowCardFrontRed[t] = didYouKnowCardFrontRed[r];
            didYouKnowCardFrontRed[r] = tmp;
        }
        //did you know Pink
        for (int t = 0; t < didYouKnowCardFrontPink.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontPink[t];
            int r = UnityEngine.Random.Range(t, didYouKnowCardFrontPink.Length);
            didYouKnowCardFrontPink[t] = didYouKnowCardFrontPink[r];
            didYouKnowCardFrontPink[r] = tmp;
        }
        //did you know Purple
        for (int t = 0; t < didYouKnowCardFrontPurple.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontPurple[t];
            int r = UnityEngine.Random.Range(t, didYouKnowCardFrontPurple.Length);
            didYouKnowCardFrontPurple[t] = didYouKnowCardFrontPurple[r];
            didYouKnowCardFrontPurple[r] = tmp;
        }

        playersInfo = GameObject.FindObjectsOfType<PlayerInfo>();

        for (int i = 0; i < GameManager.instance.currPlayers; i++)
        {
            didYouKnowButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playersInfo[i].playerName;
        }
        for (int i = didYouKnowButtons.Length - 1; i >= GameManager.instance.currPlayers; i--)
        {
            didYouKnowButtons[i].SetActive(false);
        }
    }
    public void CardDown()
    {
        CardAnimator.SetBool("CardIsUp", false);
        continueButton.SetActive(false);
        cardRead = true;
        playersPressed = 0;
        youreTheButtons.SetActive(false);
        careerButtons.SetActive(false);
        didYouButtons.SetActive(false);
        p1hasTakenToken = true;
        p2hasTakenToken = true;
        p3hasTakenToken = true;
        p4hasTakenToken = true;
        p5hasTakenToken = true;
        p6hasTakenToken = true;
    }

    public void SettingsDown()
    {
        SettingsAnimator.SetBool("isCardDown", true);
    }

    public void SettingsUp()
    {
        SettingsAnimator.SetBool("isCardDown", false);
    }

    public void CardButtonPressed(int buttonPressed)
    {
        switch (buttonPressed)
        {
            case 1:
                if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[0])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-1A");
                    playerMovementEffect = 2;
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[1])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-2A");
                    playerMovementEffect = -2;
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[2])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-3A");
                    playerMovementEffect = -1;
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[3])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-4A");
                    playerMovementEffect = 1;
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[4])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-5A");
                    playerMovementEffect = -1;
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[5])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-6A");
                    playerMovementEffect = 2;
                    CardAnimation.instance.continueButton.SetActive(true);

                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[6])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-7A");
                    playerMovementEffect = -1;
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[7])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-8A");
                    playerDoesntMove = true;
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                if (currentCareerPointNumber < (careerPointCardFront.Length - 1)) currentCareerPointNumber++;
                else currentCareerPointNumber = 0;
                break;
            case 2:
                if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[0])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-1B");
                    playerDoesntMove = true;
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[1])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-2B");
                    playerDoesntMove = true;
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[2])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-3B");
                    playerDoesntMove = true;
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[3])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-4B");
                    playerMovementEffect = -1;
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[4])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-5B");
                    playerDoesntMove = true;
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[5])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-6B");
                    playerDoesntMove = true;
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[6])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-7B");
                    playerMovementEffect = 2;
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[7])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-8B");
                    playerMovementEffect = 2;
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                if (currentCareerPointNumber < (careerPointCardFront.Length - 1)) currentCareerPointNumber++;
                else currentCareerPointNumber = 0;
                break;
            case 3:
                if (p1hasTakenToken)
                {
                    TokenAnimation.instance.isBoss = false;
                    TokenAnimation.instance.SpawnToken(1, didYouKnowTokenColor);
                    p1hasTakenToken = false;
                }
                else
                {
                    TokenAnimation.instance.SpriteSwap(1, didYouKnowTokenColor);
                    playersInfo[0].tokens[didYouKnowTokenColor - 1]--;
                    UIPlayerInfo.instance.setTokenAmounts();
                    p1hasTakenToken = true;
                }
                break;
            case 4:
                if (p2hasTakenToken)
                {
                    TokenAnimation.instance.isBoss = false;
                    TokenAnimation.instance.SpawnToken(2, didYouKnowTokenColor);
                    p2hasTakenToken = false;
                }
                else
                {
                    TokenAnimation.instance.SpriteSwap(2, didYouKnowTokenColor);
                    playersInfo[1].tokens[didYouKnowTokenColor - 1]--;
                    UIPlayerInfo.instance.setTokenAmounts();
                    p2hasTakenToken = true;
                }
                break;
            case 5:
                if (p3hasTakenToken)
                {
                    TokenAnimation.instance.isBoss = false;
                    TokenAnimation.instance.SpawnToken(3, didYouKnowTokenColor);
                    p3hasTakenToken = false;
                }
                else
                {
                    TokenAnimation.instance.SpriteSwap(3, didYouKnowTokenColor);
                    playersInfo[2].tokens[didYouKnowTokenColor - 1]--;
                    UIPlayerInfo.instance.setTokenAmounts();
                    p3hasTakenToken = true;
                }
                break;
            case 6:
                if (p4hasTakenToken)
                {
                    TokenAnimation.instance.isBoss = false;
                    TokenAnimation.instance.SpawnToken(4, didYouKnowTokenColor);
                    p4hasTakenToken = false;
                }
                else
                {
                    TokenAnimation.instance.SpriteSwap(4, didYouKnowTokenColor);
                    playersInfo[3].tokens[didYouKnowTokenColor - 1]--;
                    UIPlayerInfo.instance.setTokenAmounts();
                    p4hasTakenToken = true;
                }
                break;
            case 7:
                if (p5hasTakenToken)
                {
                    TokenAnimation.instance.isBoss = false;
                    TokenAnimation.instance.SpawnToken(5, didYouKnowTokenColor);
                    p5hasTakenToken = false;
                }
                else
                {
                    TokenAnimation.instance.SpriteSwap(5, didYouKnowTokenColor);
                    playersInfo[4].tokens[didYouKnowTokenColor - 1]--;
                    UIPlayerInfo.instance.setTokenAmounts();
                    p5hasTakenToken = true;
                }
                break;
            case 8:
                if (p6hasTakenToken)
                {
                    TokenAnimation.instance.isBoss = false;
                    TokenAnimation.instance.SpawnToken(6, didYouKnowTokenColor);
                    p6hasTakenToken = false;
                }
                else
                {
                    TokenAnimation.instance.SpriteSwap(6, didYouKnowTokenColor);
                    playersInfo[5].tokens[didYouKnowTokenColor - 1]--;
                    UIPlayerInfo.instance.setTokenAmounts();
                    p6hasTakenToken = true;
                }
                break;
            case 9:
                TokenAnimation.instance.isBoss = true;
                checkBossCard(1);
                if (playersPressed < GameManager.instance.currPlayers) playersPressed++;
                if (playersPressed >= GameManager.instance.currPlayers) CardAnimation.instance.continueButton.SetActive(true);
                break;
            case 10:
                TokenAnimation.instance.isBoss = true;
                checkBossCard(2);
                if (playersPressed < GameManager.instance.currPlayers) playersPressed++;
                if (playersPressed >= GameManager.instance.currPlayers) CardAnimation.instance.continueButton.SetActive(true);
                break;
            case 11:
                TokenAnimation.instance.isBoss = true;
                checkBossCard(3);
                if (playersPressed < GameManager.instance.currPlayers) playersPressed++;
                if (playersPressed >= GameManager.instance.currPlayers) CardAnimation.instance.continueButton.SetActive(true);
                break;
            case 12:
                TokenAnimation.instance.isBoss = true;
                checkBossCard(4);
                if (playersPressed < GameManager.instance.currPlayers) playersPressed++;
                if (playersPressed >= GameManager.instance.currPlayers) CardAnimation.instance.continueButton.SetActive(true);
                break;
            case 13:
                TokenAnimation.instance.isBoss = true;
                checkBossCard(5);
                if (playersPressed < GameManager.instance.currPlayers) playersPressed++;
                if (playersPressed >= GameManager.instance.currPlayers) CardAnimation.instance.continueButton.SetActive(true);
                break;
            case 14:
                TokenAnimation.instance.isBoss = true;
                checkBossCard(6);
                if (playersPressed < GameManager.instance.currPlayers) playersPressed++;
                if (playersPressed >= GameManager.instance.currPlayers) CardAnimation.instance.continueButton.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void checkBossCard(int val)
    {
        if (youreTheBossFront[currentYoureTheBossNumber] == youreTheBossFrontIdentity[0])
        {
            print("0");
            switch (val)
            {
                case 1:
                    print("blue");
                    bossColor = 6;
                    break;
                case 2:
                    print("green");
                    bossColor = 2;
                    break;
                case 3:
                    print("pink");
                    bossColor = 4;
                    break;
                case 4:
                    print("yellow");
                    bossColor = 5;
                    break;
                case 5:
                    print("purple");
                    bossColor = 1;
                    break;
                case 6:
                    break;
                default:
                    break;
            }
        }
        else if (youreTheBossFront[currentYoureTheBossNumber] == youreTheBossFrontIdentity[1])
        {
            print("1");
            switch (val)
            {
                case 1:
                    print("blue");
                    bossColor = 6;
                    break;
                case 2:
                    print("green");
                    bossColor = 2;
                    break;
                case 3:
                    print("pink");
                    bossColor = 4;
                    break;
                case 4:
                    print("yellow");
                    bossColor = 5;
                    break;
                case 5:
                    print("purple");
                    bossColor = 1;
                    break;
                case 6:
                    print("red");
                    bossColor = 3;
                    break;
                default:
                    break;
            }
        }
        else if (youreTheBossFront[currentYoureTheBossNumber] == youreTheBossFrontIdentity[2])
        {
            print("2");
            switch (val)
            {
                case 1:
                    print("blue");
                    bossColor = 6;
                    break;
                case 2:
                    print("green");
                    bossColor = 2;
                    break;
                case 3:
                    print("pink");
                    bossColor = 4;
                    break;
                case 4:
                    print("yellow");
                    bossColor = 5;
                    break;
                case 5:
                    print("purple");
                    bossColor = 1;
                    break;
                case 6:
                    print("red");
                    bossColor = 3;
                    break;
                default:
                    break;
            }
        }
        else if (youreTheBossFront[currentYoureTheBossNumber] == youreTheBossFrontIdentity[3])
        {
            print("3");
            switch (val)
            {
                case 1:
                    print("blue");
                    bossColor = 6;
                    break;
                case 2:
                    print("yellow");
                    bossColor = 5;
                    break;
                case 3:
                    print("pink");
                    bossColor = 4;
                    break;
                case 4:
                    print("red");
                    bossColor = 3;
                    break;
                case 5:
                    print("purple");
                    bossColor = 1;
                    break;
                case 6:
                    break;
                default:
                    break;
            }
        }
        else if (youreTheBossFront[currentYoureTheBossNumber] == youreTheBossFrontIdentity[4])
        {
            print("4");
            switch (val)
            {
                case 1:
                    print("blue");
                    bossColor = 6;
                    break;
                case 2:
                    print("green");
                    bossColor = 2;
                    break;
                case 3:
                    print("pink");
                    bossColor = 4;
                    break;
                case 4:
                    print("yellow");
                    bossColor = 5;
                    break;
                case 5:
                    print("purple");
                    bossColor = 1;
                    break;
                case 6:
                    print("red");
                    bossColor = 3;
                    break;
                default:
                    break;
            }
        }
        
        else if (youreTheBossFront[currentYoureTheBossNumber] == youreTheBossFrontIdentity[5])
        {
            print("5");
            switch (val)
            {
                case 1:
                    print("blue");
                    bossColor = 6;
                    break;
                case 2:
                    print("yellow");
                    bossColor = 5;
                    break;
                case 3:
                    print("pink");
                    bossColor = 4;
                    break;
                case 4:
                    print("red");
                    bossColor = 3;
                    break;
                case 5:
                    print("purple");
                    bossColor = 1;
                    break;
                case 6:
                    break;
                default:
                    break;
            }
        }
        else if (youreTheBossFront[currentYoureTheBossNumber] == youreTheBossFrontIdentity[6])
        {
            print("6");
            switch (val)
            {
                case 1:
                    print("blue");
                    bossColor = 6;
                    break;
                case 2:
                    print("green");
                    bossColor = 2;
                    break;
                case 3:
                    print("pink");
                    bossColor = 4;
                    break;
                case 4:
                    print("yellow");
                    bossColor = 5;
                    break;
                case 5:
                    print("purple");
                    bossColor = 1;
                    break;
                case 6:
                    print("red");
                    bossColor = 3;
                    break;
                default:
                    break;
            }
        }
        else if (youreTheBossFront[currentYoureTheBossNumber] == youreTheBossFrontIdentity[7])
        {
            print("7");
            switch (val)
            {
                case 1:
                    print("blue");
                    bossColor = 6;
                    break;
                case 2:
                    print("purple");
                    bossColor = 1;
                    break;
                case 3:
                    print("pink");
                    bossColor = 4;
                    break;
                case 4:
                    print("yellow");
                    bossColor = 5;
                    break;
                case 5:
                    break;
                case 6:
                    break;
                default:
                    break;
            }
        }
        if (playersPressed < GameManager.instance.currPlayers) TokenAnimation.instance.SpawnToken(playersPressed + 1, bossColor);
        print(youreTheBossFront[currentYoureTheBossNumber]);
    }

    public void SpriteSwap(int card)
    {
        switch (card)
        {
            case 1:
                cardBack.GetComponent<Image>().sprite = youreTheBoss;
                cardFront.GetComponent<Image>().sprite = youreTheBossFront[currentYoureTheBossNumber];
                if (currentYoureTheBossNumber < (youreTheBossFront.Length - 1)) currentYoureTheBossNumber++;
                else currentYoureTheBossNumber = 0;
                youreTheButtons.SetActive(true);
                FindObjectOfType<AudioManager>().Play("You're the Boss");
                break;
            case 2:
                cardBack.GetComponent<Image>().sprite = careerPointCardBack;
                cardFront.GetComponent<Image>().sprite = careerPointCardFront[currentCareerPointNumber];
                careerButtons.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Career Point");
                break;
            case 3:
                cardBack.GetComponent<Image>().sprite = brandCrisisCardBack;
                cardFront.GetComponent<Image>().sprite = brandCrisisCardFront[currentBrandCrisisNumber];
                if (brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[0] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[2] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[4] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[8])
                {
                    playerMovementEffect = -1;
                }
                else if (brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[3] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[5] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[6] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[7] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[10] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[11] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[12])
                {
                    playerMovementEffect = -2;
                }
                else if (brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[1] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[9])
                {
                    playerMovementEffect = -3;
                }
                if (currentBrandCrisisNumber < (brandCrisisCardFront.Length - 1)) currentBrandCrisisNumber++;
                else currentBrandCrisisNumber = 0;
                FindObjectOfType<AudioManager>().Play("Brand Crisis");
                break;
            case 4:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackPurple;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontPurple[currentDidYouKnowPurpleNumber];
                if (currentDidYouKnowPurpleNumber < (didYouKnowCardFrontPurple.Length - 1)) currentDidYouKnowPurpleNumber++;
                else currentDidYouKnowPurpleNumber = 0;
                didYouKnowTokenColor = 1;
                for (int i = 0; i < didYouKnowButtons.Length; i++)
                {
                    didYouKnowButtons[i].GetComponent<Image>().sprite = didYouKnowButtonPurple;
                }
                didYouButtons.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Did You Know");
                break;
            case 5:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackGreen;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontGreen[currentDidYouKnowGreenNumber];
                if (currentDidYouKnowGreenNumber < (didYouKnowCardFrontGreen.Length - 1)) currentDidYouKnowGreenNumber++;
                else currentDidYouKnowGreenNumber = 0;
                didYouKnowTokenColor = 2;
                for (int i = 0; i < didYouKnowButtons.Length; i++)
                {
                    didYouKnowButtons[i].GetComponent<Image>().sprite = didYouKnowButtonGreen;
                }
                didYouButtons.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Did You Know");
                break;
            case 6:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackRed;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontRed[currentDidYouKnowRedNumber];
                if (currentDidYouKnowRedNumber < (didYouKnowCardFrontRed.Length - 1)) currentDidYouKnowRedNumber++;
                else currentDidYouKnowRedNumber = 0;
                didYouKnowTokenColor = 3;
                for (int i = 0; i < didYouKnowButtons.Length; i++)
                {
                    didYouKnowButtons[i].GetComponent<Image>().sprite = didYouKnowButtonRed;
                }
                didYouButtons.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Did You Know");
                break;
            case 7:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackPink;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontPink[currentDidYouKnowPinkNumber];
                if (currentDidYouKnowPinkNumber < (didYouKnowCardFrontPink.Length - 1)) currentDidYouKnowPinkNumber++;
                else currentDidYouKnowPinkNumber = 0;
                didYouKnowTokenColor = 4;
                for (int i = 0; i < didYouKnowButtons.Length; i++)
                {
                    didYouKnowButtons[i].GetComponent<Image>().sprite = didYouKnowButtonPink;
                }
                didYouButtons.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Did You Know");
                break;
            case 8:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackYellow;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontYellow[currentDidYouKnowYellowNumber];
                if (currentDidYouKnowYellowNumber < (didYouKnowCardFrontYellow.Length - 1)) currentDidYouKnowYellowNumber++;
                else currentDidYouKnowYellowNumber = 0;
                didYouKnowTokenColor = 5;
                for (int i = 0; i < didYouKnowButtons.Length; i++)
                {
                    didYouKnowButtons[i].GetComponent<Image>().sprite = didYouKnowButtonYellow;
                }
                didYouButtons.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Did You Know");
                break;
            case 9:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackBlue;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontBlue[currentDidYouKnowBlueNumber];
                if (currentDidYouKnowBlueNumber < (didYouKnowCardFrontBlue.Length - 1)) currentDidYouKnowBlueNumber++;
                else currentDidYouKnowBlueNumber = 0;
                didYouKnowTokenColor = 6;
                for (int i = 0; i < didYouKnowButtons.Length; i++)
                {
                    didYouKnowButtons[i].GetComponent<Image>().sprite = didYouKnowButtonBlue;
                }
                didYouButtons.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Did You Know");
                break;
            default:
                break;
        }
    }
}
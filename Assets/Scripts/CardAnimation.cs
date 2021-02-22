using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

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


    public void Start()
    {
        // Knuth shuffle algorithms
        //brand crisis
        for (int t = 0; t < brandCrisisCardFront.Length; t++)
        {
            Sprite tmp = brandCrisisCardFront[t];
            int r = Random.Range(t, brandCrisisCardFront.Length);
            brandCrisisCardFront[t] = brandCrisisCardFront[r];
            brandCrisisCardFront[r] = tmp;
        }
        //career point
        for (int t = 0; t < careerPointCardFront.Length; t++)
        {
            Sprite tmp = careerPointCardFront[t];
            int r = Random.Range(t, careerPointCardFront.Length);
            careerPointCardFront[t] = careerPointCardFront[r];
            careerPointCardFront[r] = tmp;
        }
        //youre the boss
        for (int t = 0; t < youreTheBossFront.Length; t++)
        {
            Sprite tmp = youreTheBossFront[t];
            int r = Random.Range(t, youreTheBossFront.Length);
            youreTheBossFront[t] = youreTheBossFront[r];
            youreTheBossFront[r] = tmp;
        }
        //did you know blue
        for (int t = 0; t < didYouKnowCardFrontBlue.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontBlue[t];
            int r = Random.Range(t, didYouKnowCardFrontBlue.Length);
            didYouKnowCardFrontBlue[t] = didYouKnowCardFrontBlue[r];
            didYouKnowCardFrontBlue[r] = tmp;
        }
        //did you know green
        for (int t = 0; t < didYouKnowCardFrontGreen.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontGreen[t];
            int r = Random.Range(t, didYouKnowCardFrontGreen.Length);
            didYouKnowCardFrontGreen[t] = didYouKnowCardFrontGreen[r];
            didYouKnowCardFrontGreen[r] = tmp;
        }
        //did you know Yellow
        for (int t = 0; t < didYouKnowCardFrontYellow.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontYellow[t];
            int r = Random.Range(t, didYouKnowCardFrontYellow.Length);
            didYouKnowCardFrontYellow[t] = didYouKnowCardFrontYellow[r];
            didYouKnowCardFrontYellow[r] = tmp;
        }
        //did you know Red
        for (int t = 0; t < didYouKnowCardFrontRed.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontRed[t];
            int r = Random.Range(t, didYouKnowCardFrontRed.Length);
            didYouKnowCardFrontRed[t] = didYouKnowCardFrontRed[r];
            didYouKnowCardFrontRed[r] = tmp;
        }
        //did you know Pink
        for (int t = 0; t < didYouKnowCardFrontPink.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontPink[t];
            int r = Random.Range(t, didYouKnowCardFrontPink.Length);
            didYouKnowCardFrontPink[t] = didYouKnowCardFrontPink[r];
            didYouKnowCardFrontPink[r] = tmp;
        }
        //did you know Purple
        for (int t = 0; t < didYouKnowCardFrontPurple.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontPurple[t];
            int r = Random.Range(t, didYouKnowCardFrontPurple.Length);
            didYouKnowCardFrontPurple[t] = didYouKnowCardFrontPurple[r];
            didYouKnowCardFrontPurple[r] = tmp;
        }
    }
    public void CardDown()
    {
        CardAnimator.SetBool("CardIsUp", false);
        cardRead = true;
        youreTheButtons.SetActive(false);
        careerButtons.SetActive(false);
        didYouButtons.SetActive(false);
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
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[1])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-2A");
                    playerMovementEffect = -2;
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[2])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-3A");
                    playerMovementEffect = -1;
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[3])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-4A");
                    playerMovementEffect = 1;
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[4])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-5A");
                    playerDoesntMove = true;
                    print("5A NOT AVAILABLE");
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[5])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-6A");
                    playerMovementEffect = 2;

                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[6])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-7A");
                    playerMovementEffect = -1;
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[7])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-8A");
                    playerDoesntMove = true;
                }
                if (currentCareerPointNumber < (careerPointCardFront.Length - 1)) currentCareerPointNumber++;
                else currentCareerPointNumber = 0;
                break;
            case 2:
                if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[0])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-1B");
                    playerDoesntMove = true;
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[1])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-2B");
                    playerDoesntMove = true;
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[2])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-3B");
                    playerDoesntMove = true;
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[3])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-4B");
                    playerMovementEffect = -1;
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[4])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-5B");
                    playerDoesntMove = true;
                    print("5B NOT AVAILABLE");
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[5])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-6B");
                    playerDoesntMove = true;
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[6])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-7B");
                    playerMovementEffect = 2;
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[7])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-8B");
                    playerMovementEffect = 2;
                }
                if (currentCareerPointNumber < (careerPointCardFront.Length - 1)) currentCareerPointNumber++;
                else currentCareerPointNumber = 0;
                break;
            case 3:
                print("BUTTON 3 PRESSED!");
                break;
            case 4:
                print("BUTTON 4 PRESSED!");
                break;
            case 5:
                print("BUTTON 5 PRESSED!");
                break;
            case 6:
                print("BUTTON 6 PRESSED!");
                break;
            case 7:
                print("BUTTON 7 PRESSED!");
                break;
            case 8:
                print("BUTTON 8 PRESSED!");
                break;
            case 9:
                print("BUTTON 9 PRESSED!");
                break;
            case 10:
                print("BUTTON 10 PRESSED!");
                break;
            case 11:
                print("BUTTON 11 PRESSED!");
                break;
            case 12:
                print("BUTTON 12 PRESSED!");
                break;
            case 13:
                print("BUTTON 13 PRESSED!");
                break;
            case 14:
                print("BUTTON 14 PRESSED!");
                break;
            default:
                break;
        }
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
                didYouButtons.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Did You Know");
                break;
            case 5:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackGreen;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontGreen[currentDidYouKnowGreenNumber];
                if (currentDidYouKnowGreenNumber < (didYouKnowCardFrontGreen.Length - 1)) currentDidYouKnowGreenNumber++;
                else currentDidYouKnowGreenNumber = 0;
                didYouButtons.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Did You Know");
                break;
            case 6:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackRed;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontRed[currentDidYouKnowRedNumber];
                if (currentDidYouKnowRedNumber < (didYouKnowCardFrontRed.Length - 1)) currentDidYouKnowRedNumber++;
                else currentDidYouKnowRedNumber = 0;
                didYouButtons.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Did You Know");
                break;
            case 7:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackPink;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontPink[currentDidYouKnowPinkNumber];
                if (currentDidYouKnowPinkNumber < (didYouKnowCardFrontPink.Length - 1)) currentDidYouKnowPinkNumber++;
                else currentDidYouKnowPinkNumber = 0;
                didYouButtons.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Did You Know");
                break;
            case 8:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackYellow;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontYellow[currentDidYouKnowYellowNumber];
                if (currentDidYouKnowYellowNumber < (didYouKnowCardFrontYellow.Length - 1)) currentDidYouKnowYellowNumber++;
                else currentDidYouKnowYellowNumber = 0;
                didYouButtons.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Did You Know");
                break;
            case 9:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackBlue;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontBlue[currentDidYouKnowBlueNumber];
                if (currentDidYouKnowBlueNumber < (didYouKnowCardFrontBlue.Length - 1)) currentDidYouKnowBlueNumber++;
                else currentDidYouKnowBlueNumber = 0;
                didYouButtons.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Did You Know");
                break;
            default:
                break;
        }
    }
}
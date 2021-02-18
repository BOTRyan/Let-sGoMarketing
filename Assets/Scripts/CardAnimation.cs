using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Sprite didYouKnowCardBackOrange;
    public Sprite didYouKnowCardBackPink;
    public Sprite didYouKnowCardBackPurple;

    public Sprite brandCrisisCardBack;

    public Sprite careerPointCardBack;

    public Sprite youreTheBoss;

    public GameObject cardBack;
    public GameObject cardFront;

    public Sprite[] brandCrisisCardFront;
    public Sprite[] brandCrisisCardFrontCopy;

    public Sprite[] careerPointCardFront;

    public Sprite[] youreTheBossFront;

    public Sprite[] didYouKnowCardFrontBlue;
    public Sprite[] didYouKnowCardFrontGreen;
    public Sprite[] didYouKnowCardFrontYellow;
    public Sprite[] didYouKnowCardFrontRed;
    public Sprite[] didYouKnowCardFrontOrange;
    public Sprite[] didYouKnowCardFrontPink;
    public Sprite[] didYouKnowCardFrontPurple;

    public int playerMovementEffect = 0;
    public bool cardRead = false;

    private int currentBrandCrisisNumber = 0;

    private int currentCareerPointNumber = 0;

    private int currentYoureTheBossNumber = 0;

    private int currentDidYouKnowBlueNumber = 0;
    private int currentDidYouKnowGreenNumber = 0;
    private int currentDidYouKnowYellowNumber = 0;
    private int currentDidYouKnowRedNumber = 0;
    private int currentDidYouKnowOrangeNumber = 0;
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
        //did you know Orange
        for (int t = 0; t < didYouKnowCardFrontOrange.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontOrange[t];
            int r = Random.Range(t, didYouKnowCardFrontOrange.Length);
            didYouKnowCardFrontOrange[t] = didYouKnowCardFrontOrange[r];
            didYouKnowCardFrontOrange[r] = tmp;
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
    }

    public void SettingsDown()
    {
        SettingsAnimator.SetBool("isCardDown", true);
    }

    public void SettingsUp()
    {
        SettingsAnimator.SetBool("isCardDown", false);
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
                break;
            case 2:
                cardBack.GetComponent<Image>().sprite = careerPointCardBack;
                cardFront.GetComponent<Image>().sprite = careerPointCardFront[currentCareerPointNumber];
                if (currentCareerPointNumber < (careerPointCardFront.Length - 1)) currentCareerPointNumber++;
                else currentCareerPointNumber = 0;
                break;
            case 3:
                cardBack.GetComponent<Image>().sprite = brandCrisisCardBack;
                cardFront.GetComponent<Image>().sprite = brandCrisisCardFront[currentBrandCrisisNumber];
                if (brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontCopy[0] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontCopy[2] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontCopy[4] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontCopy[8])
                {
                    playerMovementEffect = 1;
                }
                else if (brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontCopy[3] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontCopy[5] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontCopy[6] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontCopy[7] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontCopy[10] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontCopy[11] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontCopy[12])
                {
                    playerMovementEffect = 2;
                }
                else if (brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontCopy[1] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontCopy[9])
                {
                    playerMovementEffect = 3;
                }
                if (currentBrandCrisisNumber < (brandCrisisCardFront.Length - 1)) currentBrandCrisisNumber++;
                else currentBrandCrisisNumber = 0;
                break;
            case 4:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackPurple;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontPurple[currentDidYouKnowPurpleNumber];
                if (currentDidYouKnowPurpleNumber < (didYouKnowCardFrontPurple.Length - 1)) currentDidYouKnowPurpleNumber++;
                else currentDidYouKnowPurpleNumber = 0;
                break;
            case 5:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackOrange;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontOrange[currentDidYouKnowOrangeNumber];
                if (currentDidYouKnowOrangeNumber < (didYouKnowCardFrontOrange.Length - 1)) currentDidYouKnowOrangeNumber++;
                else currentDidYouKnowOrangeNumber = 0;
                break;
            case 6:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackGreen;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontGreen[currentDidYouKnowGreenNumber];
                if (currentDidYouKnowGreenNumber < (didYouKnowCardFrontGreen.Length - 1)) currentDidYouKnowGreenNumber++;
                else currentDidYouKnowGreenNumber = 0;
                break;
            case 7:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackRed;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontRed[currentDidYouKnowRedNumber];
                if (currentDidYouKnowRedNumber < (didYouKnowCardFrontRed.Length - 1)) currentDidYouKnowRedNumber++;
                else currentDidYouKnowRedNumber = 0;
                break;
            case 8:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackPink;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontPink[currentDidYouKnowPinkNumber];
                if (currentDidYouKnowPinkNumber < (didYouKnowCardFrontPink.Length - 1)) currentDidYouKnowPinkNumber++;
                else currentDidYouKnowPinkNumber = 0;
                break;
            case 9:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackYellow;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontYellow[currentDidYouKnowYellowNumber];
                if (currentDidYouKnowYellowNumber < (didYouKnowCardFrontYellow.Length - 1)) currentDidYouKnowYellowNumber++;
                else currentDidYouKnowYellowNumber = 0;
                break;
            case 10:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackBlue;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontBlue[currentDidYouKnowBlueNumber];
                if (currentDidYouKnowBlueNumber < (didYouKnowCardFrontBlue.Length - 1)) currentDidYouKnowBlueNumber++;
                else currentDidYouKnowBlueNumber = 0;
                break;
            default:
                break;
        }
    }
}
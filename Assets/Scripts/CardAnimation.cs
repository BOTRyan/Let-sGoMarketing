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
    public Sprite didYouKnowCardBackBlue;
    public Sprite didYouKnowCardBackGreen;
    public Sprite didYouKnowCardBackYellow;
    public Sprite didYouKnowCardBackRed;
    public Sprite didYouKnowCardBackOrange;
    public Sprite didYouKnowCardBackPink;
    public Sprite didYouKnowCardBackPurple;
    public Sprite brandCrisisCardBack;
    public Sprite careerPointCardBack;
    public GameObject cardBack;
    public GameObject cardFront;
    public Sprite[] brandCrisisCardFront;
    public Sprite didYouKnowCardFront;
    public Sprite careerPointCardFront;
    private int currentBrandCrisisNumber = 0;
    public void Start()
    {
        // Knuth shuffle algorithm
        for (int t = 0; t < brandCrisisCardFront.Length; t++)
        {
            Sprite tmp = brandCrisisCardFront[t];
            int r = Random.Range(t, brandCrisisCardFront.Length);
            brandCrisisCardFront[t] = brandCrisisCardFront[r];
            brandCrisisCardFront[r] = tmp;
        }
    }
    public void CardDown()
    {
        CardAnimator.SetBool("CardIsUp", false);
    }

    public void SpriteSwap(int card)
    {

        switch (card)
        {
            case 1:
                //the boss
                break;
            case 2:
                cardBack.GetComponent<Image>().sprite = careerPointCardBack;
                cardFront.GetComponent<Image>().sprite = careerPointCardFront;
                break;
            case 3:
                cardBack.GetComponent<Image>().sprite = brandCrisisCardBack;
                cardFront.GetComponent<Image>().sprite = brandCrisisCardFront[currentBrandCrisisNumber];
                if (currentBrandCrisisNumber < 2) currentBrandCrisisNumber++;
                else currentBrandCrisisNumber = 0;
                break;
            case 4:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackPurple;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFront;
                break;
            case 5:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackOrange;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFront;
                break;
            case 6:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackGreen;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFront;
                break;
            case 7:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackRed;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFront;
                break;
            case 8:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackPink;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFront;
                break;
            case 9:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackYellow;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFront;
                break;
            case 10:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackBlue;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFront;
                break;
            default:
                break;
        }
    }
}

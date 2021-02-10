using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void Update()
    {
        
    }
    public void CardDown()
    {
        CardAnimator.SetBool("CardIsUp", false);
    }

    public void SpriteSwap(int card)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int targetPos = 0;
    private int currPos = 0;

    private float delay = .2f;
    private float alpha = 0;

    public int yourPlayerNum;

    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = GrabPositions.instance.boardPositions[currPos].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (yourPlayerNum == GameManager.instance.currPlayerTurn)
        {
            if (Spinner.instance.numPicked && !isMoving)
            {
                isMoving = true;
                Spinner.instance.numPicked = false;
                targetPos += Spinner.instance.targetNum;
            }

            if (currPos < targetPos && currPos < 55)
            {
                delay -= Time.deltaTime;
                if (delay <= 0)
                {
                    alpha += Time.deltaTime * 2;
                    transform.position = AnimMath.Lerp(GrabPositions.instance.boardPositions[currPos].position, GrabPositions.instance.boardPositions[currPos + 1].position, alpha);
                    if (alpha >= 1)
                    {
                        delay = 0.2f;
                        alpha = 0;
                        currPos++;

                        if (currPos == targetPos || currPos >= 55)
                        {
                            switch (currPos)
                            {
                                case 7:
                                case 15:
                                case 20:
                                case 34:
                                case 48:
                                    print("You're The Boss");
                                    CardAnimation.instance.SpriteSwap(1);
                                    CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                    break;
                                case 4:
                                case 12:
                                case 25:
                                case 37:
                                case 53:
                                    print("Career Point");
                                    CardAnimation.instance.SpriteSwap(2);
                                    CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                    break;
                                case 6:
                                case 18:
                                case 30:
                                case 45:
                                    print("Brand Crisis");
                                    CardAnimation.instance.SpriteSwap(3);
                                    CardAnimation.instance.CardAnimator.SetBool("CardIsUp",true);
                                    break;
                                case 1:
                                    print("Did You Know");
                                    CardAnimation.instance.SpriteSwap(4);
                                    CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                    break;
                                case 10:
                                    print("Did You Know");
                                    CardAnimation.instance.SpriteSwap(5);
                                    CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                    break;
                                case 17:
                                    print("Did You Know");
                                    CardAnimation.instance.SpriteSwap(6);
                                    CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                    break;
                                case 27:
                                    print("Did You Know");
                                    CardAnimation.instance.SpriteSwap(7);
                                    CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                    break;
                                case 32:
                                    print("Did You Know");
                                    CardAnimation.instance.SpriteSwap(8);
                                    CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                    break;
                                case 41:
                                    print("Did You Know");
                                    CardAnimation.instance.SpriteSwap(9);
                                    CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                    break;
                                case 50:
                                    print("Did You Know");
                                    CardAnimation.instance.SpriteSwap(10);
                                    CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                    break;
                                default:
                                    print("blank");
                                    break;
                            }
                                
                            GameManager.instance.currPlayerTurn++;
                            Spinner.instance.canSpin = true;
                            Spinner.instance.spinStarted = false;
                        }
                    }
                }
            }
        }
        else
        {
            isMoving = false;
        }
    }
}

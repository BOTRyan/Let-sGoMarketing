using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public int targetPos = 0;
    public int currPos = 0;

    private float delay = .2f;
    private float alpha = 0;

    private float jumpCounter = 0;
    private float hoverCounter = 0;
    private bool isHover = true;
    private bool isJump = true;
    //private bool doJump = true;

    public int yourPlayerNum;

    public bool isMoving = false;

    public bool moveOnce = true;

    public bool landedOnCard = false;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            transform.position = GrabPositions.instance.boardPositions[currPos].position;
            moveOnce = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {

            if (moveOnce)
            {
                transform.position = GrabPositions.instance.boardPositions[currPos].position;
                moveOnce = false;
            }
            if (isMoving) isHover = false;
            else isHover = true;
            if (isHover) Hover();

            if (yourPlayerNum == GameManager.instance.currPlayerTurn)
            {
                Jump();
                
                if (Spinner.instance.numPicked && !isMoving)
                {
                    print(gameObject.name + " Spun");
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
                        //transform.position = AnimMath.Lerp(GrabPositions.instance.boardPositions[currPos].position, GrabPositions.instance.boardPositions[currPos + 1].position, alpha);
                        transform.position = CalcPositionOnCurve(alpha);
                        if (alpha >= 1)
                        {
                            delay = 0.05f;
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
                                        landedOnCard = true;
                                        break;
                                    case 4:
                                    case 12:
                                    case 25:
                                    case 37:
                                    case 53:
                                        print("Career Point");
                                        CardAnimation.instance.SpriteSwap(2);
                                        CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                        landedOnCard = true;
                                        break;
                                    case 6:
                                    case 18:
                                    case 30:
                                    case 45:
                                        print("Brand Crisis");
                                        CardAnimation.instance.SpriteSwap(3);
                                        CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                        landedOnCard = true;
                                        break;
                                    case 1:
                                        print("Did You Know");
                                        CardAnimation.instance.SpriteSwap(4);
                                        CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                        landedOnCard = true;
                                        break;
                                    case 10:
                                        print("Did You Know");
                                        CardAnimation.instance.SpriteSwap(5);
                                        CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                        landedOnCard = true;
                                        break;
                                    case 17:
                                        print("Did You Know");
                                        CardAnimation.instance.SpriteSwap(6);
                                        CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                        landedOnCard = true;
                                        break;
                                    case 27:
                                        print("Did You Know");
                                        CardAnimation.instance.SpriteSwap(7);
                                        CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                        landedOnCard = true;
                                        break;
                                    case 32:
                                        print("Did You Know");
                                        CardAnimation.instance.SpriteSwap(8);
                                        CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                        landedOnCard = true;
                                        break;
                                    case 41:
                                        print("Did You Know");
                                        CardAnimation.instance.SpriteSwap(9);
                                        CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                        landedOnCard = true;
                                        break;
                                    case 50:
                                        print("Did You Know");
                                        CardAnimation.instance.SpriteSwap(10);
                                        CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
                                        landedOnCard = true;
                                        break;
                                    default:
                                        landedOnCard = false;
                                        GameManager.instance.currPlayerTurn++;
                                        Spinner.instance.canSpin = true;
                                        Spinner.instance.spinStarted = false;
                                        break;
                                }
                            }
                        }
                    }
                }
                else if (currPos >= 55)
                {
                    isMoving = false;
                    landedOnCard = false;
                    GameManager.instance.currPlayerTurn++;
                    Spinner.instance.canSpin = true;
                    Spinner.instance.spinStarted = false;
                }
            }
            else
            {
                isMoving = false;
                landedOnCard = false;
                isJump = true;
            }
        }
    }

    private Vector3 CalcPositionOnCurve(float percent)
    {
        // midway point between positions
        Vector3 handle;

        // get midway point for x, y, and z, add bounce in y axis
        handle.x = GrabPositions.instance.boardPositions[currPos].position.x + (GrabPositions.instance.boardPositions[currPos + 1].position.x - GrabPositions.instance.boardPositions[currPos].position.x) / 2;
        handle.y = GrabPositions.instance.boardPositions[currPos].position.y + (GrabPositions.instance.boardPositions[currPos + 1].position.y - GrabPositions.instance.boardPositions[currPos].position.y) / 2;
        handle.z = GrabPositions.instance.boardPositions[currPos].position.z + (GrabPositions.instance.boardPositions[currPos + 1].position.z - GrabPositions.instance.boardPositions[currPos].position.z) / 2;
        handle.y += 0.5f;

        // pC = lerp between pA and midway point (handle)
        Vector3 positionC = AnimMath.Lerp(GrabPositions.instance.boardPositions[currPos].position, handle, percent);

        // pD = lerp between midway point (handle) and pB
        Vector3 positionD = AnimMath.Lerp(handle, GrabPositions.instance.boardPositions[currPos + 1].position, percent);

        // pE = lerp between pC and pD
        Vector3 positionE = AnimMath.Lerp(positionC, positionD, percent);

        // return pE
        return positionE;
    }

    private void Hover()
    {
        hoverCounter += Time.deltaTime * 2.5f;
        Vector3 temp = transform.position;
        temp.y += Mathf.Sin(hoverCounter)/3000;
        transform.position = temp;
    }

    private void Jump()
    {
        if(isJump)
        {
            isHover = false;
            jumpCounter += Time.deltaTime * 5;
            Vector3 temp =  transform.position;
            temp.y += Mathf.Sin(jumpCounter) / 500;
            transform.position = temp;
            //transform.position = AnimMath.Slide(transform.position, temp, 0.5f);
            if (jumpCounter >= Mathf.PI * 2)
            {
                isHover = true;
                isJump = false;
            }
        }
    }
}

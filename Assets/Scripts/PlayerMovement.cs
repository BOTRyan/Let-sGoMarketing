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
    public float camOffset = 3.25f;

    private float jumpCounter = 0;
    private float hoverCounter = 0;
    private bool isHover = true;
    private bool isJump = true;

    private bool addOnce = true;

    public int yourPlayerNum;
    public bool isMoving = false;
    public bool moveOnce = true;
    public bool landedOnCard = false;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {

            if (moveOnce)
            {
                transform.position = GrabPositions.instance.boardPositions[currPos].position;
                camOffset = 3.25f;
                moveOnce = false;
                hoverCounter = Random.Range(0, Mathf.PI * 2);
            }

            if (yourPlayerNum == GameManager.instance.currPlayerTurn)
            {
                Jump();

                if (Spinner.instance.numPicked && !isMoving)
                {
                    isMoving = true;
                    Spinner.instance.numPicked = false;
                    targetPos += Spinner.instance.targetNum;
                }

                if (CardAnimation.instance.playerMovementEffect < 0 && landedOnCard)
                {
                    targetPos += CardAnimation.instance.playerMovementEffect;
                    isMoving = true;
                    CardAnimation.instance.playerMovementEffect = 0;
                }
                else if (CardAnimation.instance.playerMovementEffect > 0 && landedOnCard)
                {
                    targetPos += CardAnimation.instance.playerMovementEffect;
                    isMoving = true;
                    CardAnimation.instance.playerMovementEffect = 0;
                }
                else if (CardAnimation.instance.playerDoesntMove && landedOnCard)
                {
                    swapTurns(1);
                }

                if (!isMoving && landedOnCard && CardAnimation.instance.cardRead)
                {
                    swapTurns(0);
                }

                if (currPos > targetPos && currPos > 0 && landedOnCard && CardAnimation.instance.cardRead)
                {
                    delay -= Time.deltaTime;
                    if (delay <= 0)
                    {
                        alpha += Time.deltaTime * 2;
                        transform.position = CalcPositionOnCurveBackwards(alpha);

                        if (alpha >= 1)
                        {
                            delay = 0.05f;
                            alpha = 0;
                            currPos--;

                            if (currPos == targetPos || currPos <= 0)
                            {
                                swapTurns(1);
                            }
                        }
                    }
                }

                if (currPos < targetPos && currPos < 55)
                {
                    if (landedOnCard)
                    {
                        if (CardAnimation.instance.cardRead)
                        {
                            delay -= Time.deltaTime;
                            if (delay <= 0)
                            {
                                alpha += Time.deltaTime * 2;
                                transform.position = CalcPositionOnCurveForwards(alpha);

                                if (alpha >= 1)
                                {
                                    delay = 0.05f;
                                    alpha = 0;
                                    currPos++;

                                    if (currPos == targetPos || currPos >= 55)
                                    {
                                        swapTurns(1);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        delay -= Time.deltaTime;
                        if (delay <= 0)
                        {
                            alpha += Time.deltaTime * 2;
                            transform.position = CalcPositionOnCurveForwards(alpha);

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
                                            //print("You're The Boss");
                                            FlipCard(1);
                                            break;
                                        case 4:
                                        case 12:
                                        case 25:
                                        case 37:
                                        case 53:
                                            //print("Career Point");
                                            FlipCard(2);
                                            break;
                                        case 6:
                                        case 18:
                                        case 30:
                                        case 45:
                                            //print("Brand Crisis");
                                            FlipCard(3);
                                            break;
                                        case 1:
                                        case 10:
                                            //print("Did You Know");
                                            FlipCard(4);
                                            break;
                                        case 17:
                                            //print("Did You Know");
                                            FlipCard(5);
                                            break;
                                        case 27:
                                            //print("Did You Know");
                                            FlipCard(6);
                                            break;
                                        case 32:
                                            //print("Did You Know");
                                            FlipCard(7);
                                            break;
                                        case 42:
                                            //print("Did You Know");
                                            FlipCard(8);
                                            break;
                                        case 50:
                                            //print("Did You Know");
                                            FlipCard(9);
                                            break;
                                        default:
                                            swapTurns(0);
                                            break;
                                    }
                                }
                            }

                        }
                    }
                }
                else if (currPos >= 55)
                {
                    swapTurns(2);
                }
            }
            else
            {
                isMoving = false;
                isJump = true;
            }

            if (isMoving) isHover = false;
            else isHover = true;

            if (isHover) Hover();
        }
    }

    private void FlipCard(int val)
    {
        landedOnCard = true;
        isMoving = false;
        CardAnimation.instance.SpriteSwap(val);
        CardAnimation.instance.CardAnimator.SetBool("CardIsUp", true);
        FindObjectOfType<AudioManager>().PlayInSeconds("Card Flip", 1f);
    }

    private void swapTurns(int val)
    {
        landedOnCard = false;
        if (val >= 1)
        {
            isMoving = false;
            CardAnimation.instance.playerDoesntMove = false;
        }
        CameraControl.instance.jumpToOnce = true;
        GameManager.instance.currPlayerTurn++;
        CardAnimation.instance.cardRead = false;
        Spinner.instance.canSpin = true;
        Spinner.instance.spinStarted = false;
        if (val >= 2)
        {
            Spinner.instance.Rollednumber.text = "";

            if (addOnce)
            {
                GameManager.instance.playersDone++;
                addOnce = false;
            }
        }
    }

    private Vector3 CalcPositionOnCurveForwards(float percent)
    {
        // get cameraOffset
        Vector3 camPosition = AnimMath.Lerp(GrabPositions.instance.boardPositions[currPos].position, GrabPositions.instance.boardPositions[currPos + 1].position, percent);
        camOffset = camPosition.y;

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

    private Vector3 CalcPositionOnCurveBackwards(float percent)
    {
        // get cameraOffset
        Vector3 camPosition = AnimMath.Lerp(GrabPositions.instance.boardPositions[currPos].position, GrabPositions.instance.boardPositions[currPos - 1].position, percent);
        camOffset = camPosition.y;

        // midway point between positions
        Vector3 handle;

        // get midway point for x, y, and z, add bounce in y axis
        handle.x = GrabPositions.instance.boardPositions[currPos].position.x + (GrabPositions.instance.boardPositions[currPos - 1].position.x - GrabPositions.instance.boardPositions[currPos].position.x) / 2;
        handle.y = GrabPositions.instance.boardPositions[currPos].position.y + (GrabPositions.instance.boardPositions[currPos - 1].position.y - GrabPositions.instance.boardPositions[currPos].position.y) / 2;
        handle.z = GrabPositions.instance.boardPositions[currPos].position.z + (GrabPositions.instance.boardPositions[currPos - 1].position.z - GrabPositions.instance.boardPositions[currPos].position.z) / 2;
        handle.y += 0.5f;

        // pC = lerp between pA and midway point (handle)
        Vector3 positionC = AnimMath.Lerp(GrabPositions.instance.boardPositions[currPos].position, handle, percent);

        // pD = lerp between midway point (handle) and pB
        Vector3 positionD = AnimMath.Lerp(handle, GrabPositions.instance.boardPositions[currPos - 1].position, percent);

        // pE = lerp between pC and pD
        Vector3 positionE = AnimMath.Lerp(positionC, positionD, percent);

        // return pE
        return positionE;
    }

    private void Hover()
    {
        hoverCounter += Time.deltaTime * 2.5f;
        Vector3 temp = transform.position;
        temp.y += Mathf.Sin(hoverCounter) / 3000;
        transform.position = temp;
    }

    private void Jump()
    {
        if (isJump)
        {
            isHover = false;
            jumpCounter += Time.deltaTime * 5;
            jumpCounter = Mathf.Clamp(jumpCounter, 0, Mathf.PI * 2);
            Vector3 temp = transform.position;
            temp.y += Mathf.Sin(jumpCounter) / 250;

            transform.position = temp;

            if (jumpCounter >= Mathf.PI * 2)
            {
                if (Vector3.Distance(transform.position, GrabPositions.instance.boardPositions[currPos].position) >= 0.05f)
                {
                    transform.position = AnimMath.Slide(transform.position, GrabPositions.instance.boardPositions[currPos].position, 0.05f);
                }
                else
                {
                    jumpCounter = 0;
                    isHover = true;
                    isJump = false;
                }
            }
        }
    }
}

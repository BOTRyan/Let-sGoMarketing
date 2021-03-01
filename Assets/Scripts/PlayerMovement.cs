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
    private float grav = -9.8f;
    private float velY = 0;
    public float camOffset = 3.25f;

    private float hoverCounter = 0;
    private bool isHover = true;
    private bool isJump = true;
    private bool jumping = false;

    private bool addOnce = true;

    public int yourPlayerNum;
    public bool isMoving = false;
    public bool moveOnce = true;
    public bool landedOnCard = false;

    // Update is called once per frame
    void FixedUpdate()
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
                else if (CardAnimation.instance.playerDoesntMove && landedOnCard && CardAnimation.instance.cardRead)
                {
                    swapTurns(1);
                }

                if (!isMoving && landedOnCard && CardAnimation.instance.cardRead)
                {
                    swapTurns(0);
                }

                if (currPos > targetPos && currPos > 0 && landedOnCard && CardAnimation.instance.cardRead)
                {
                    delay -= Time.fixedDeltaTime;
                    if (delay <= 0)
                    {
                        alpha += Time.fixedDeltaTime * 2;
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
                            delay -= Time.fixedDeltaTime;
                            if (delay <= 0)
                            {
                                alpha += Time.fixedDeltaTime * 2;
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
                        delay -= Time.fixedDeltaTime;
                        if (delay <= 0)
                        {
                            alpha += Time.fixedDeltaTime * 2;
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
                                            swapTurns(1);
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
        if (val >= 3)
        {
            StartCoroutine(showButtonWithDelay(1.75f));
        }
    }

    IEnumerator showButtonWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        CardAnimation.instance.continueButton.SetActive(true);
    }

    private void swapTurns(int val)
    {
        landedOnCard = false;
        if (val >= 1)
        {
            isMoving = false;
            CardAnimation.instance.playerDoesntMove = false;
        }
        isJump = true;
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
        hoverCounter += Time.fixedDeltaTime * 2.5f;
        Vector3 temp = transform.position;
        temp.y += Mathf.Sin(hoverCounter) / 500;
        transform.position = temp;
    }

    private void Jump()
    {
        if (isJump)
        {
            velY = 4;
            jumping = true;
            isJump = false;
        }
        else if (jumping)
        {
            isHover = false;
            if (Vector3.Distance(transform.position, GrabPositions.instance.boardPositions[currPos].position) >= .01f || velY > 0)
            {
                if (transform.position.y >= GrabPositions.instance.boardPositions[currPos].position.y)
                {
                    Vector3 temp = transform.position;
                    velY += grav * Time.fixedDeltaTime;
                    temp.y += velY * Time.fixedDeltaTime;
                    transform.position = temp;
                }
                else
                {
                    velY = 0;
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, GrabPositions.instance.boardPositions[currPos].position) >= 0.05f)
                {
                    transform.position = AnimMath.Slide(transform.position, GrabPositions.instance.boardPositions[currPos].position, 0.05f);
                }
                else
                {
                    jumping = false;
                }
            }
        }
        else isHover = true;
    }
}

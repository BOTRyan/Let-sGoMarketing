using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public int targetPos = 40;
    public int currPos = 40;

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
    public int finishPlace = 0;
    public bool hasFinished = false;
    public bool doOnce = true;

    private bool offsetOnce = false;

    public Sprite baseDog;
    public Sprite walk01, walk02, walk03, walk04, walk05, walk06;
    private Sprite red01, red02, red03, red04, red05, red06, redBlink;
    private Sprite blue01, blue02, blue03, blue04, blue05, blue06, blueBlink;
    private Sprite green01, green02, green03, green04, green05, green06, greenBlink;
    private Sprite pink01, pink02, pink03, pink04, pink05, pink06, pinkBlink;
    private Sprite yel01, yel02, yel03, yel04, yel05, yel06, yelBlink;
    private Sprite purp01, purp02, purp03, purp04, purp05, purp06, purpBlink;
    private List<Sprite> walkSprites = new List<Sprite>();
    private float walkCounter;
    private bool blinking = false;
    private bool spriteOnce = true;


    void Start()
    {
        red01 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/bulldogRed1");
        red02 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/bulldogRed2");
        red03 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/bulldogRed3");
        red04 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/bulldogRed4");
        red05 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/bulldogRed5");
        red06 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/bulldogRed6");
        redBlink = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/bulldogRed4Blink");
        blue01 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Blue1");
        blue02 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Blue2");
        blue03 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Blue3");
        blue04 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Blue4");
        blue05 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Blue5");
        blue06 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Blue6");
        blueBlink = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Blue4Blink");
        green01 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Green1");
        green02 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Green2");
        green03 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Green3");
        green04 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Green4");
        green05 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Green5");
        green06 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Green6");
        greenBlink = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Green4Blink");
        pink01 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Pink1");
        pink02 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Pink2");
        pink03 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Pink3");
        pink04 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Pink4");
        pink05 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Pink5");
        pink06 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Pink6");
        pinkBlink = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Pink4Blink");
        yel01 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Yellow1");
        yel02 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Yellow2");
        yel03 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Yellow3");
        yel04 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Yellow4");
        yel05 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Yellow5");
        yel06 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Yellow6");
        yelBlink = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Yellow4Blink");
        purp01 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Purple1");
        purp02 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Purple2");
        purp03 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Purple3");
        purp04 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Purple4");
        purp05 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Purple5");
        purp06 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Purple6");
        purpBlink = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Purple4Blink");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (moveOnce)
            {
                transform.position = GrabPositions.instance.boardPositions[currPos].position;
                camOffset = 3.25f;
                moveOnce = false;
                hoverCounter = Random.Range(0, Mathf.PI * 2);
            }
            baseDog = GetComponent<PlayerInfo>().avatar;
            spritesUpdate();
            if (yourPlayerNum == GameManager.instance.currPlayerTurn)
            {
                print(hasFinished);
                if (isMoving)
                {
                    if (doOnce)
                    {
                        FindObjectOfType<AudioManager>().Play("Walk");
                        doOnce = false;
                    }
                }
                else
                {
                    doOnce = true;
                    FindObjectOfType<AudioManager>().Stop("Walk");
                }

                //Jump();

                if (Spinner.instance.numPicked && !isMoving)
                {
                    isMoving = true;
                    Spinner.instance.numPicked = false;
                    targetPos += Spinner.instance.targetNum;
                    //FindObjectOfType<AudioManager>().Play("Walk");
                }

                if (CardAnimation.instance.playerMovementEffect < 0 && landedOnCard && CardAnimation.instance.cardRead)
                {
                    targetPos += CardAnimation.instance.playerMovementEffect;
                    isMoving = true;
                    CardAnimation.instance.playerMovementEffect = 0;
                    //FindObjectOfType<AudioManager>().Play("Walk");
                }
                else if (CardAnimation.instance.playerMovementEffect > 0 && landedOnCard && CardAnimation.instance.cardRead)
                {
                    targetPos += CardAnimation.instance.playerMovementEffect;
                    isMoving = true;
                    CardAnimation.instance.playerMovementEffect = 0;
                    //FindObjectOfType<AudioManager>().Play("Walk");
                }
                else if (CardAnimation.instance.playerDoesntMove && landedOnCard && CardAnimation.instance.cardRead)
                {
                    //FindObjectOfType<AudioManager>().Stop("Walk");
                    swapTurns(1);
                }

                if (!isMoving && landedOnCard && CardAnimation.instance.cardRead)
                {
                    //FindObjectOfType<AudioManager>().Stop("Walk");
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
                            delay = 0.01f;
                            alpha = 0;
                            currPos--;

                            if (currPos == targetPos || currPos <= 0)
                            {
                                //FindObjectOfType<AudioManager>().Stop("Walk");
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
                                    delay = 0.01f;
                                    alpha = 0;
                                    currPos++;

                                    if (currPos == targetPos || currPos >= 55)
                                    {
                                        //FindObjectOfType<AudioManager>().Stop("Walk");
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
                                            // You're The Boss
                                            FlipCard(1);
                                            break;
                                        case 4:
                                        case 12:
                                        case 25:
                                        case 37:
                                        case 53:
                                            // Career Point
                                            FlipCard(2);
                                            break;
                                        case 6:
                                        case 18:
                                        case 30:
                                        case 45:
                                            // Brand Crisis
                                            FlipCard(3);
                                            break;
                                        case 1:
                                        case 10:
                                            // Did You Know
                                            FlipCard(4);
                                            break;
                                        case 17:
                                            // Did You Know
                                            FlipCard(5);
                                            break;
                                        case 27:
                                            // Did You Know
                                            FlipCard(6);
                                            break;
                                        case 32:
                                            // Did You Know
                                            FlipCard(7);
                                            break;
                                        case 42:
                                            // Did You Know
                                            FlipCard(8);
                                            break;
                                        case 50:
                                            // Did You Know
                                            FlipCard(9);
                                            break;
                                        case 55:
                                            if (GameManager.instance.playersDone == 0)
                                            {
                                                FlipCard(10);
                                            }
                                            if (GameManager.instance.playersDone != 0 && GameManager.instance.playersDone != GameManager.instance.currPlayers)
                                            {
                                                FlipCard(11);
                                            }
                                            if (GameManager.instance.playersDone == GameManager.instance.currPlayers - 1)
                                            {
                                                FlipCard(12);
                                            }
                                            FindObjectOfType<AudioManager>().PlayUninterrupted("Win");
                                            for (int i = 0; i < GameManager.instance.players.Count; i++)
                                            {
                                                if (GameManager.instance.players[i].GetComponent<PlayerMovement>().hasFinished) finishPlace++;
                                            }
                                            //hasFinished = true;
                                            GameManager.instance.playersDone++;
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
                else if (GameManager.instance.playersDone < GameManager.instance.currPlayers)
                {
                    if (currPos >= 55 && CardAnimation.instance.cardRead && !hasFinished) swapTurns(2);
                    else if (hasFinished && currPos >= 55) swapTurns(2);
                    else print("Heck");

                }
            }
            else
            {
                isMoving = false;
            }

            if (isMoving || Input.GetKey(KeyCode.A))
            {
                animWalk();
                isHover = false;
                offsetOnce = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = baseDog;
                isHover = true;
            }
            //if (isHover) Hover();
        }
    }

    private void FlipCard(int val)
    {
        //FindObjectOfType<AudioManager>().Stop("Walk");
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
            hasFinished = true;
            Spinner.instance.Rollednumber.text = "";
        }
    }

    private Vector3 CalcPositionOnCurveForwards(float percent)
    {
        // get cameraOffset
        Vector3 camPosition = AnimMath.Lerp(GrabPositions.instance.boardPositions[currPos].position, GrabPositions.instance.boardPositions[currPos + 1].position, percent);
        camOffset = camPosition.y;

        /*
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
        */

        Vector3 positionE = AnimMath.Lerp(GrabPositions.instance.boardPositions[currPos].position, GrabPositions.instance.boardPositions[currPos + 1].position, percent);

        // return pE
        return positionE;
    }

    private Vector3 CalcPositionOnCurveBackwards(float percent)
    {
        // get cameraOffset
        Vector3 camPosition = AnimMath.Lerp(GrabPositions.instance.boardPositions[currPos].position, GrabPositions.instance.boardPositions[currPos - 1].position, percent);
        camOffset = camPosition.y;

        /*
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
        */

        Vector3 positionE = AnimMath.Lerp(GrabPositions.instance.boardPositions[currPos].position, GrabPositions.instance.boardPositions[currPos - 1].position, percent);

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
            int barkNum = Random.Range(0, 3);
            FindObjectOfType<AudioManager>().PlayUninterrupted("Bark" + barkNum);
        }
        else if (jumping)
        {
            isHover = false;
            Vector3 temp = transform.position;
            velY += grav * Time.fixedDeltaTime;
            temp.y += velY * Time.fixedDeltaTime;
            transform.position = temp;

            if (transform.position.y <= GrabPositions.instance.boardPositions[currPos].position.y) velY = 0;

            if (Vector3.Distance(transform.position, GrabPositions.instance.boardPositions[currPos].position) >= 0.02f && velY == 0)
            {
                transform.position = AnimMath.Slide(transform.position, GrabPositions.instance.boardPositions[currPos].position, 0.05f);
                if (Vector3.Distance(transform.position, GrabPositions.instance.boardPositions[currPos].position) < 0.02f)
                {
                    transform.position = GrabPositions.instance.boardPositions[currPos].position;
                    jumping = false;
                }
            }

        }
        else isHover = true;
    }

    private void animWalk()
    {
        if (currPos < 8 || (currPos >= 12 && currPos < 14) || (currPos >= 19 && currPos < 23) || (currPos >= 28 && currPos < 41) || (currPos >= 46 && currPos < 51)) GetComponent<SpriteRenderer>().flipX = true;
        else GetComponent<SpriteRenderer>().flipX = false;
        if (walkCounter < walkSprites.Count) walkCounter += Time.deltaTime * 7.5f;
        if (walkCounter >= walkSprites.Count)
        {
            walkCounter = 0;
            blinking = !blinking;
        }
        int walkIndex = Mathf.FloorToInt(walkCounter);
        GetComponent<SpriteRenderer>().sprite = walkSprites[walkIndex];
    }

    public void setOffset()
    {
        if(!offsetOnce)
        {
            transform.position = GrabPositions.instance.boardPositions[currPos].position + new Vector3(Random.Range(0, 1), Random.Range(0, 1));
            offsetOnce = true;
        }
        
    }
    private void spritesUpdate()
    {
        if (baseDog == red01)
        {
            walk01 = red01;
            walk02 = red02;
            walk03 = red03;
            walk04 = red04;
            walk05 = red05;
            walk06 = red06;
        }
        else if (baseDog == blue01)
        {
            walk01 = blue01;
            walk02 = blue02;
            walk03 = blue03;
            walk04 = blue04;
            walk05 = blue05;
            walk06 = blue06;
        }
        else if (baseDog == green01)
        {
            walk01 = green01;
            walk02 = green02;
            walk03 = green03;
            walk04 = green04;
            walk05 = green05;
            walk06 = green06;
        }
        else if (baseDog == pink01)
        {
            walk01 = pink01;
            walk02 = pink02;
            walk03 = pink03;
            walk04 = pink04;
            walk05 = pink05;
            walk06 = pink06;
        }
        else if (baseDog == yel01)
        {
            walk01 = yel01;
            walk02 = yel02;
            walk03 = yel03;
            walk04 = yel04;
            walk05 = yel05;
            walk06 = yel06;
        }
        else if (baseDog == purp01)
        {
            walk01 = purp01;
            walk02 = purp02;
            walk03 = purp03;
            walk04 = purp04;
            walk05 = purp05;
            walk06 = purp06;
        }
        if(spriteOnce)
        {
            walkSprites.Add(walk01);
            walkSprites.Add(walk02);
            walkSprites.Add(walk03);
            walkSprites.Add(walk04);
            walkSprites.Add(walk05);
            walkSprites.Add(walk06);
            spriteOnce = false;
        }

        if(blinking)
        {
            if (baseDog == red01) walkSprites[3] = redBlink;
            if (baseDog == blue01) walkSprites[3] = blueBlink;
            if (baseDog == green01) walkSprites[3] = greenBlink;
            if (baseDog == pink01) walkSprites[3] = pinkBlink;
            if (baseDog == yel01) walkSprites[3] = yelBlink;
            if (baseDog == purp01) walkSprites[3] = purpBlink;
        }
        else
        {
            if (baseDog == red01) walkSprites[3] = red04;
            if (baseDog == blue01) walkSprites[3] = blue04;
            if (baseDog == green01) walkSprites[3] = green04;
            if (baseDog == pink01) walkSprites[3] = pink04;
            if (baseDog == yel01) walkSprites[3] = yel04;
            if (baseDog == purp01) walkSprites[3] = purp04;
        }
    }
}

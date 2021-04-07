﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public int targetPos = 1;
    public int currPos = 1;

    private float delay = 0f;
    private float alpha = 0f;
    public float camOffset = 7.74f;
    private Vector3 playerOffset;

    public int yourPlayerNum;
    public bool isMoving = false;
    public bool moveOnce = true;
    private Vector3 targetOffsetPosition;
    public bool landedOnCard = false;
    public int finishPlace = 0;
    private bool hasFinished = false;
    public bool doOnce = true;
    public bool callOnce = true;

    public Sprite baseDog;
    public Sprite walk01, walk02, walk03, walk04, walk05, walk06;
    private Sprite red01, red02, red03, red04, red05, red06, redBlink, redSit;
    private Sprite blue01, blue02, blue03, blue04, blue05, blue06, blueBlink, blueSit;
    private Sprite green01, green02, green03, green04, green05, green06, greenBlink, greenSit;
    private Sprite pink01, pink02, pink03, pink04, pink05, pink06, pinkBlink, pinkSit;
    private Sprite yel01, yel02, yel03, yel04, yel05, yel06, yelBlink, yelSit;
    private Sprite purp01, purp02, purp03, purp04, purp05, purp06, purpBlink, purpSit;
    private List<Sprite> walkSprites = new List<Sprite>();
    private float walkCounter;
    private bool blinking = false;
    private bool spriteOnce = true;

    private GameObject modal;

    void Start()
    {
        // Loads all images for players to use at the start
        red01 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/bulldogRed1");
        red02 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/bulldogRed2");
        red03 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/bulldogRed3");
        red04 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/bulldogRed4");
        red05 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/bulldogRed5");
        red06 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/bulldogRed6");
        redBlink = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/bulldogRed4Blink");
        redSit = Resources.Load<Sprite>("Materials/Avatars/Sitting/RedSit");
        blue01 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Blue1");
        blue02 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Blue2");
        blue03 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Blue3");
        blue04 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Blue4");
        blue05 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Blue5");
        blue06 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Blue6");
        blueBlink = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Blue4Blink");
        blueSit = Resources.Load<Sprite>("Materials/Avatars/Sitting/BlueSit");
        green01 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Green1");
        green02 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Green2");
        green03 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Green3");
        green04 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Green4");
        green05 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Green5");
        green06 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Green6");
        greenBlink = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Green4Blink");
        greenSit = Resources.Load<Sprite>("Materials/Avatars/Sitting/GreenSit");
        pink01 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Pink1");
        pink02 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Pink2");
        pink03 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Pink3");
        pink04 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Pink4");
        pink05 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Pink5");
        pink06 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Pink6");
        pinkBlink = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Pink4Blink");
        pinkSit = Resources.Load<Sprite>("Materials/Avatars/Sitting/PinkSit");
        yel01 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Yellow1");
        yel02 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Yellow2");
        yel03 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Yellow3");
        yel04 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Yellow4");
        yel05 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Yellow5");
        yel06 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Yellow6");
        yelBlink = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Yellow4Blink");
        yelSit = Resources.Load<Sprite>("Materials/Avatars/Sitting/YellowSit");
        purp01 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Purple1");
        purp02 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Purple2");
        purp03 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Purple3");
        purp04 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Purple4");
        purp05 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Purple5");
        purp06 = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Purple6");
        purpBlink = Resources.Load<Sprite>("Materials/Avatars/Walk Anim/Purple4Blink");
        purpSit = Resources.Load<Sprite>("Materials/Avatars/Sitting/PurpleSit");
    }


    void findPlayerOffset()
    {
        /// <summary>
        /// This function finds the players offsets at the beginning of the game
        /// based on which player they are 
        /// </summary>
        switch (GameManager.instance.currPlayers)
        {
            case 1:
                playerOffset = new Vector3(0, 0, 0);
                break;
            case 2:
                switch (yourPlayerNum)
                {
                    case 1:
                        playerOffset = new Vector3(.3f, 0, .05f);
                        break;
                    case 2:
                        playerOffset = new Vector3(-.3f, 0, .05f);
                        break;
                }
                break;
            case 3:
                switch (yourPlayerNum)
                {
                    case 1:
                        playerOffset = new Vector3(.3f, -.2f, .05f);
                        break;
                    case 2:
                        playerOffset = new Vector3(-.3f, -.2f, .05f);
                        break;
                    case 3:
                        playerOffset = new Vector3(0, .2f, .25f);
                        break;
                }
                break;
            case 4:
                switch (yourPlayerNum)
                {
                    case 1:
                        playerOffset = new Vector3(.3f, 0, .15f);
                        break;
                    case 2:
                        playerOffset = new Vector3(-.3f, 0, .15f);
                        break;
                    case 3:
                        playerOffset = new Vector3(0, .3f, .25f);
                        break;
                    case 4:
                        playerOffset = new Vector3(0, -.3f, .05f);
                        break;
                }
                break;
            case 5:
                switch (yourPlayerNum)
                {
                    case 1:
                        playerOffset = new Vector3(.4f, 0, .1f);
                        break;
                    case 2:
                        playerOffset = new Vector3(0, 0, .15f);
                        break;
                    case 3:
                        playerOffset = new Vector3(-.4f, 0, .2f);
                        break;
                    case 4:
                        playerOffset = new Vector3(0, .3f, .25f);
                        break;
                    case 5:
                        playerOffset = new Vector3(0, -.3f, .05f);
                        break;
                }
                break;
            case 6:
                switch (yourPlayerNum)
                {
                    case 1:
                        playerOffset = new Vector3(.4f, 0, .25f);
                        break;
                    case 2:
                        playerOffset = new Vector3(.2f, .1f, .275f);
                        break;
                    case 3:
                        playerOffset = new Vector3(0, .2f, .3f);
                        break;
                    case 4:
                        playerOffset = new Vector3(0, -.2f, .1f);
                        break;
                    case 5:
                        playerOffset = new Vector3(-.2f, -.1f, .15f);
                        break;
                    case 6:
                        playerOffset = new Vector3(-.4f, 0, .2f);
                        break;
                }
                break;
            default:
                break;
        }
    }

    void FixedUpdate()
    {
        // Makes sure it only updates in the game scene
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (moveOnce)
            {
                /// <summary>
                /// This move once makes sure all players are moved
                /// when the game is loaded and set to face the correct direction
                /// as well as setting a few other variables
                /// </summary>

                findPlayerOffset();
                transform.position = GrabPositions.instance.boardPositions[currPos].position + playerOffset;
                targetOffsetPosition = transform.position;
                camOffset = 7.74f;
                moveOnce = false;
                GetComponent<SpriteRenderer>().flipX = true;
                modal = FindObjectOfType<ModalFunction>().gameObject;
                if (!GameManager.instance.spinModalOnce)
                {
                    ModalFunction.instance.fadeModalIn("Spin");
                    modal.SetActive(true);
                    GameManager.instance.spinModalOnce = true;
                }
            }

            // These update the players sprite to animate
            baseDog = GetComponent<PlayerInfo>().avatar;
            spritesUpdate();

            // Check if it is the player's turn
            if (yourPlayerNum == GameManager.instance.currPlayerTurn)
            {
                // If they player is already done, switch turns
                if (hasFinished)
                {
                    swapTurns(2);
                }

                // If they player isn't moving, and the spinner picked a number
                // Start moving to the targetNum
                if (Spinner.instance.numPicked && !isMoving)
                {
                    isMoving = true;
                    Spinner.instance.numPicked = false;
                    targetPos += Spinner.instance.targetNum;
                }

                // This If, else if chain checks if they player has read the card and if they need to move forwards or backwards
                // if the player doesn't, it swaps turns
                if (CardAnimation.instance.playerMovementEffect < 0 && landedOnCard && CardAnimation.instance.cardRead)
                {
                    targetPos += CardAnimation.instance.playerMovementEffect;
                    isMoving = true;
                    CardAnimation.instance.playerMovementEffect = 0;
                }
                else if (CardAnimation.instance.playerMovementEffect > 0 && landedOnCard && CardAnimation.instance.cardRead)
                {
                    targetPos += CardAnimation.instance.playerMovementEffect;
                    isMoving = true;
                    CardAnimation.instance.playerMovementEffect = 0;
                }
                else if (CardAnimation.instance.playerDoesntMove && landedOnCard && CardAnimation.instance.cardRead)
                {
                    swapTurns(1);
                }

                // If the player isn't moving, and they read the card, swapTurns()
                if (!isMoving && landedOnCard && CardAnimation.instance.cardRead)
                {
                    swapTurns(0);
                }

                // This checks if the player has to move backwards due to Brand Crisis
                // and then moves them till they reach their target location, and swaps their turn
                if (currPos > targetPos && currPos > 0 && landedOnCard && CardAnimation.instance.cardRead)
                {
                    delay -= Time.fixedDeltaTime;
                    if (delay <= 0)
                    {
                        alpha += Time.fixedDeltaTime * 2;
                        transform.position = CalcPositionOnCurveBackwards(alpha);

                        if (alpha >= 1)
                        {
                            //alpha and delay were basically removed, this code should be reworked to not use them
                            delay = 0f;
                            alpha = 0;
                            currPos--;

                            if (currPos == targetPos || currPos <= 0)
                            {
                                swapTurns(1);
                            }
                        }
                    }
                }

                // This checks if the player has to move forwards and moves them till
                // they reach their target location
                if (currPos < targetPos && currPos < 54)
                {
                    // If the player is moving due to the influence of a card
                    // then once they reach their target location, they swap turns
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
                                    //alpha and delay were basically removed, this code should be reworked to not use them
                                    delay = 0f;
                                    alpha = 0;
                                    currPos++;

                                    if (currPos == targetPos || currPos >= 54)
                                    {
                                        switch (currPos)
                                        {
                                            case 54:
                                                // Finished Game Cards
                                                if (GameManager.instance.playersDone == 0)
                                                {
                                                    FlipCard(10);
                                                }
                                                if (GameManager.instance.playersDone != 0 && GameManager.instance.playersDone < GameManager.instance.currPlayers)
                                                {
                                                    FlipCard(11);
                                                }
                                                if (GameManager.instance.playersDone == GameManager.instance.currPlayers - 1 && GameManager.instance.currPlayers != 1)
                                                {
                                                    FlipCard(12);
                                                }
                                                FindObjectOfType<AudioManager>().PlayUninterrupted("Win");
                                                for (int i = 0; i < GameManager.instance.players.Count; i++)
                                                {
                                                    if (GameManager.instance.players[i].GetComponent<PlayerMovement>().hasFinished) finishPlace++;
                                                }
                                                GameManager.instance.playersDone++;
                                                CardAnimation.instance.finishCardUp = false;
                                                break;
                                            default:
                                                // SwapTurns if nothing else
                                                swapTurns(1);
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else // If the player is moving due to the spinner, move till they reach their target location, and check which space their on
                    {
                        delay -= Time.fixedDeltaTime;
                        if (delay <= 0)
                        {
                            alpha += Time.fixedDeltaTime * 2;
                            transform.position = CalcPositionOnCurveForwards(alpha);

                            if (alpha >= 1)
                            {
                                //alpha and delay were basically removed, this code should be reworked to not use them
                                delay = 0f;
                                alpha = 0;
                                currPos++;

                                if (currPos == targetPos || currPos >= 54)
                                {
                                    // This switch case checks which space the player landed on and flips card of swaps turn accordingly
                                    switch (currPos)
                                    {
                                        case 8:
                                        case 11:
                                        case 22:
                                        case 29:
                                        case 36:
                                        case 41:
                                        case 47:
                                            // You're The Boss
                                            FlipCard(1);
                                            if (!GameManager.instance.bossModalOnce)
                                            {
                                                modal.SetActive(true);
                                                ModalFunction.instance.fadeModalIn("YTB");
                                                GameManager.instance.bossModalOnce = true;
                                            }
                                            break;
                                        case 4:
                                        case 12:
                                        case 25:
                                        case 37:
                                        case 53:
                                            // Career Point
                                            FlipCard(2);
                                            if (!GameManager.instance.pointModalOnce)
                                            {
                                                modal.SetActive(true);
                                                ModalFunction.instance.fadeModalIn("Career");
                                                GameManager.instance.pointModalOnce = true;
                                            }
                                            break;
                                        case 18:
                                        case 30:
                                            // Brand Crisis
                                            FlipCard(3);
                                            break;
                                        case 1:
                                        case 6:
                                        case 10:
                                            // Did You Know Purple
                                            FlipCard(4);
                                            if (!GameManager.instance.didYouModalOnce)
                                            {
                                                modal.SetActive(true);
                                                ModalFunction.instance.fadeModalIn("DYK");
                                                GameManager.instance.didYouModalOnce = true;
                                            }
                                            break;
                                        case 15:
                                        case 17:
                                            // Did You Know Green
                                            FlipCard(5);
                                            if (!GameManager.instance.didYouModalOnce)
                                            {
                                                modal.SetActive(true);
                                                ModalFunction.instance.fadeModalIn("DYK");
                                                GameManager.instance.didYouModalOnce = true;
                                            }
                                            break;
                                        case 21:
                                        case 27:
                                            // Did You Know Red
                                            FlipCard(6);
                                            if (!GameManager.instance.didYouModalOnce)
                                            {
                                                modal.SetActive(true);
                                                ModalFunction.instance.fadeModalIn("DYK");
                                                GameManager.instance.didYouModalOnce = true;
                                            }
                                            break;
                                        case 32:
                                        case 34:
                                            // Did You Know Pink
                                            FlipCard(7);
                                            if (!GameManager.instance.didYouModalOnce)
                                            {
                                                modal.SetActive(true);
                                                ModalFunction.instance.fadeModalIn("DYK");
                                                GameManager.instance.didYouModalOnce = true;
                                            }
                                            break;
                                        case 39:
                                        case 42:
                                            // Did You Know Yellow
                                            FlipCard(8);
                                            if (!GameManager.instance.didYouModalOnce)
                                            {
                                                modal.SetActive(true);
                                                ModalFunction.instance.fadeModalIn("DYK");
                                                GameManager.instance.didYouModalOnce = true;
                                            }
                                            break;
                                        case 46:
                                        case 50:
                                            // Did You Know Blue
                                            FlipCard(9);
                                            if (!GameManager.instance.didYouModalOnce)
                                            {
                                                modal.SetActive(true);
                                                ModalFunction.instance.fadeModalIn("DYK");
                                                GameManager.instance.didYouModalOnce = true;
                                            }
                                            break;
                                        case 54:
                                            // Finished Game Cards
                                            if (GameManager.instance.playersDone == 0)
                                            {
                                                FlipCard(10);
                                            }
                                            if (GameManager.instance.playersDone != 0 && GameManager.instance.playersDone < GameManager.instance.currPlayers)
                                            {
                                                FlipCard(11);
                                            }
                                            if (GameManager.instance.playersDone == GameManager.instance.currPlayers - 1 && GameManager.instance.currPlayers != 1)
                                            {
                                                FlipCard(12);
                                            }
                                            FindObjectOfType<AudioManager>().PlayUninterrupted("Win");
                                            for (int i = 0; i < GameManager.instance.players.Count; i++)
                                            {
                                                if (GameManager.instance.players[i].GetComponent<PlayerMovement>().hasFinished) finishPlace++;
                                            }
                                            GameManager.instance.playersDone++;
                                            CardAnimation.instance.finishCardUp = false;
                                            break;
                                        default:
                                            // SwapTurns if nothing else
                                            swapTurns(1);
                                            break;
                                    }
                                }
                            }

                        }
                    }
                }
                /// <summary>
                /// This else if checks if all the players have finished or not yet
                /// If not and the player has reached the end position and hasn't finished already
                /// checks if the player has read the finished game card and swaps turn when they have
                /// </summary>
                else if (GameManager.instance.playersDone < GameManager.instance.currPlayers)
                {
                    if (currPos >= 54 && !hasFinished)
                    {
                        if (CardAnimation.instance.finishCardUp)
                        {
                            swapTurns(2);
                        }
                    }
                }
            }

            if (isMoving)
            {
                // if moving, animate the dog walking
                animWalk();

                // if moving, move the player to the front of others
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            }
            else
            {
                // if not moving, animate the dog sitting
                animSit();

                // move dog to targetOffsetPosition if they're not moving, and haven't landed on a card
                if (!landedOnCard)
                {
                    transform.position = AnimMath.Slide(transform.position, targetOffsetPosition, .01f);
                }
            }
        }
    }

    private void FlipCard(int val)
    {
        /// <summary>
        /// This function sets the variables and calls to
        /// functions inside CardAnimation to bring up the card
        /// and flip it
        /// </summary>

        landedOnCard = true;
        isMoving = false;
        CardAnimation.instance.cardRead = false;
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
        /// <summary>
        /// This function end the player's turn and resets variables
        /// then changes to the next player's turn
        /// </summary>

        landedOnCard = false;
        if (val >= 1)
        {
            isMoving = false;
            CardAnimation.instance.playerDoesntMove = false;
        }
        CameraControl.instance.jumpToOnce = true;
        CardAnimation.instance.cardRead = false;
        Spinner.instance.canSpin = true;
        Spinner.instance.spinStarted = false;
        if (currPos >= 54) hasFinished = true;
        if (val >= 2)
        {
            Spinner.instance.Rollednumber.text = "";
        }
        checkPlayerOffset();
        GameManager.instance.currPlayerTurn++;
    }

    private void checkPlayerOffset()
    {
        /// <summary>
        /// This function checks the amount of players on the same tile
        /// and updates those player's offset accordingly
        /// </summary>

        int playersOnSameSpot = 0;
        List<PlayerMovement> players = new List<PlayerMovement>();

        // Check how many players are on the same tile
        for (int i = 0; i < GameManager.instance.currPlayers; i++)
        {
            if (GameManager.instance.players[i].GetComponent<PlayerMovement>().currPos == currPos)
            {
                playersOnSameSpot++;
                // Get players on the same tile
                players.Add(GameManager.instance.players[i].GetComponent<PlayerMovement>());
            }
        }

        // Removes players self from check list
        playersOnSameSpot--;

        // Set players offsets accordingly to how many are on the same tile
        switch (playersOnSameSpot)
        {
            case 0:
                playerOffset = new Vector3(0, 0, .05f);
                break;
            case 1:
                playerOffset = new Vector3(.2f, 0, .1f);
                players[0].playerOffset = new Vector3(-.2f, 0, .05f);
                break;
            case 2:
                playerOffset = new Vector3(.2f, -.1f, .05f);
                players[0].playerOffset = new Vector3(-.2f, -.1f, .05f);
                players[1].playerOffset = new Vector3(0, .1f, .25f);
                break;
            case 3:
                playerOffset = new Vector3(.2f, 0, .15f);
                players[0].playerOffset = new Vector3(-.2f, 0, .15f);
                players[1].playerOffset = new Vector3(0, .2f, .25f);
                players[2].playerOffset = new Vector3(0, -.2f, .05f);
                break;
            case 4:
                playerOffset = new Vector3(.3f, 0, .1f);
                players[0].playerOffset = new Vector3(0, 0, .15f);
                players[1].playerOffset = new Vector3(-.3f, 0, .2f);
                players[2].playerOffset = new Vector3(0, .2f, .25f);
                players[3].playerOffset = new Vector3(0, -.2f, .05f);
                break;
            case 5:
                playerOffset = new Vector3(.4f, 0, .25f);
                players[0].playerOffset = new Vector3(.2f, .1f, .275f);
                players[1].playerOffset = new Vector3(0, .2f, .3f);
                players[2].playerOffset = new Vector3(0, -.2f, .1f);
                players[3].playerOffset = new Vector3(-.2f, -.1f, .15f);
                players[4].playerOffset = new Vector3(-.4f, 0, .2f);
                break;
            default:
                break;
        }

        // Sets Players targetOffsetPosition properly
        transform.position = GrabPositions.instance.boardPositions[currPos].position;
        targetOffsetPosition = transform.position + playerOffset;

        for (int i = 0; i < players.Count; i++)
        {
            players[i].transform.position = GrabPositions.instance.boardPositions[currPos].position;
            players[i].targetOffsetPosition = players[i].transform.position + players[i].playerOffset;
        }
    }

    private Vector3 CalcPositionOnCurveForwards(float percent)
    {
        /// <summary>
        ///  This function lerps the player between two tiles (current, and 1 ahead)
        ///  and calculates it's position with the added offset
        ///  then returns the position
        /// </summary>

        // get cameraOffset
        Vector3 camPosition = AnimMath.Lerp(GrabPositions.instance.boardPositions[currPos].position, GrabPositions.instance.boardPositions[currPos + 1].position, percent);
        camOffset = camPosition.y;

        // lerp position between two tiles
        Vector3 positionE = AnimMath.Lerp(GrabPositions.instance.boardPositions[currPos].position, GrabPositions.instance.boardPositions[currPos + 1].position, percent);

        // add the player offset vector to the position
        Vector3 finalPos = positionE + playerOffset;

        playerOffset = AnimMath.Lerp(playerOffset, new Vector3(0, 0, 0), percent / 2);

        // return finalPos
        return finalPos;
    }

    private Vector3 CalcPositionOnCurveBackwards(float percent)
    {
        /// <summary>
        ///  This function lerps the player between two tiles (current, and 1 behind)
        ///  and calculates it's position with the added offset
        ///  then returns the position
        /// </summary>

        // get cameraOffset
        Vector3 camPosition = AnimMath.Lerp(GrabPositions.instance.boardPositions[currPos].position, GrabPositions.instance.boardPositions[currPos - 1].position, percent);
        camOffset = camPosition.y;

        // lerp position between two tiles
        Vector3 positionE = AnimMath.Lerp(GrabPositions.instance.boardPositions[currPos].position, GrabPositions.instance.boardPositions[currPos - 1].position, percent);

        // add the player offset vector to the position
        Vector3 finalPos = positionE + playerOffset;

        playerOffset = AnimMath.Lerp(playerOffset, new Vector3(0, 0, 0), percent / 2);

        // return finalPos
        return finalPos;
    }

    private void animWalk()
    {
        /// <summary>
        ///  This function updates the dogs sprites to make them animate
        ///  it also flips the x axis of the dog when reaching certain parts of the board
        /// </summary>

        if (currPos < 8 || (currPos >= 12 && currPos < 14) || (currPos >= 19 && currPos < 23) || (currPos >= 28 && currPos < 36) || (currPos >= 43 && currPos < 46) || (currPos >= 49)) GetComponent<SpriteRenderer>().flipX = true;
        else GetComponent<SpriteRenderer>().flipX = false;
        if (walkCounter < walkSprites.Count) walkCounter += Time.deltaTime * 12f;
        if (walkCounter >= walkSprites.Count)
        {
            walkCounter = 0;
            blinking = !blinking;
        }
        int walkIndex = Mathf.FloorToInt(walkCounter);
        GetComponent<SpriteRenderer>().sprite = walkSprites[walkIndex];
    }

    private void animSit()
    {
        /// <summary>
        ///  This function checks which dog the player had as their base avatar
        ///  and then when sitting, picks the color accordingly
        /// </summary>

        if (baseDog == redSit)
        {
            GetComponent<SpriteRenderer>().sprite = redSit;
        }
        else if (baseDog == blueSit)
        {
            GetComponent<SpriteRenderer>().sprite = blueSit;
        }
        else if (baseDog == greenSit)
        {
            GetComponent<SpriteRenderer>().sprite = greenSit;
        }
        else if (baseDog == pinkSit)
        {
            GetComponent<SpriteRenderer>().sprite = pinkSit;
        }
        else if (baseDog == yelSit)
        {
            GetComponent<SpriteRenderer>().sprite = yelSit;
        }
        else if (baseDog == purpSit)
        {
            GetComponent<SpriteRenderer>().sprite = purpSit;
        }
    }

    private void spritesUpdate()
    {
        /// <summary>
        ///  This function checks which dog the player had as their base avatar
        ///  and then loads the correct color in to the walk sprites
        /// </summary>

        if (baseDog == redSit)
        {
            walk01 = red01;
            walk02 = red02;
            walk03 = red03;
            walk04 = red04;
            walk05 = red05;
            walk06 = red06;
        }
        else if (baseDog == blueSit)
        {
            walk01 = blue01;
            walk02 = blue02;
            walk03 = blue03;
            walk04 = blue04;
            walk05 = blue05;
            walk06 = blue06;
        }
        else if (baseDog == greenSit)
        {
            walk01 = green01;
            walk02 = green02;
            walk03 = green03;
            walk04 = green04;
            walk05 = green05;
            walk06 = green06;
        }
        else if (baseDog == pinkSit)
        {
            walk01 = pink01;
            walk02 = pink02;
            walk03 = pink03;
            walk04 = pink04;
            walk05 = pink05;
            walk06 = pink06;
        }
        else if (baseDog == yelSit)
        {
            walk01 = yel01;
            walk02 = yel02;
            walk03 = yel03;
            walk04 = yel04;
            walk05 = yel05;
            walk06 = yel06;
        }
        else if (baseDog == purpSit)
        {
            walk01 = purp01;
            walk02 = purp02;
            walk03 = purp03;
            walk04 = purp04;
            walk05 = purp05;
            walk06 = purp06;
        }
        if (spriteOnce)
        {
            walkSprites.Add(walk01);
            walkSprites.Add(walk02);
            walkSprites.Add(walk03);
            walkSprites.Add(walk04);
            walkSprites.Add(walk05);
            walkSprites.Add(walk06);
            spriteOnce = false;
        }

        if (blinking)
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

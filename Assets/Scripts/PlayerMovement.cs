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

    private bool isMoving = false;

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

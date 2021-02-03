using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int targetPos = 0;
    public int currPos = 0;

    private float delay = .2f;
    private float alpha = 0;

    public int yourPlayerNum;

    private int[] spinnerNums = { 1, 2, 3, 3, 4, 5, 5, 6 };

    // Start is called before the first frame update
    void Start()
    {
        transform.position = GrabPositions.instance.boardPositions[currPos].position;
    }

    // Update is called once per frame
    void Update()
    {
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
                }
            }
        }
        else
        {
            // if (GameManager.currPlayerTurn == yourPlayerNum)
            // {
            //      Check Tiles to see if you're on an action tile
            //      checkTiles();
            // }
        }
    }

    private void setTargetNum()
    {
        int randSpin = Mathf.FloorToInt(Random.Range(0, 8));
        targetPos += spinnerNums[randSpin];
    }
}

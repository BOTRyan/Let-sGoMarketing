using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    #region Singleton

    public static Spinner instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    private float rotSpeed = 0;
    private float dragAmt = 0.98f;

    public bool canSpin = true;
    public bool spinStarted = false;
    public bool numPicked = false;

    public int targetNum;

    // Start is called before the first frame update
    void Start()
    {
        rotSpeed = 0;
        transform.rotation = Quaternion.Euler(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        rotSpeed *= dragAmt;

        transform.Rotate(0, 0, rotSpeed);

        if (rotSpeed <= 0.5f && spinStarted)
        {
            rotSpeed = 0;
            spinStarted = false;
            float tempAngle = transform.rotation.eulerAngles.z;

            if (tempAngle >= 350 || tempAngle <= 17)
            {
                targetNum = 6;
            }
            else if (tempAngle > 17 && tempAngle <= 48)
            {
                targetNum = 3;
            }
            else if (tempAngle > 48 && tempAngle <= 79)
            {
                targetNum = 4;
            }
            else if (tempAngle > 79 && tempAngle <= 110)
            {
                targetNum = 6;
            }
            else if (tempAngle > 110 && tempAngle <= 141)
            {
                targetNum = 5;
            }
            else if (tempAngle > 141 && tempAngle <= 172)
            {
                targetNum = 4;
            }
            else if (tempAngle > 172 && tempAngle <= 195)
            {
                targetNum = 1;
            }
            else if (tempAngle > 195 && tempAngle <= 230)
            {
                targetNum = 5;
            }
            else if (tempAngle > 230 && tempAngle <= 259)
            {
                targetNum = 6;
            }
            else if (tempAngle > 259 && tempAngle <= 290)
            {
                targetNum = 3;
            }
            else if (tempAngle > 290 && tempAngle <= 320)
            {
                targetNum = 2;
            }
            else if (tempAngle > 320 && tempAngle < 350)
            {
                targetNum = 4;
            }

            numPicked = true;
        }
    }

    public void spinWheel()
    {
        if (!spinStarted && canSpin)
        {
            rotSpeed = Random.Range(20, 40);
            dragAmt = Random.Range(0.97f, 0.99f);
            spinStarted = true;
            canSpin = false;
        }
    }
}

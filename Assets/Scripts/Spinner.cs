using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private float accSpeed = 0;
    private float dragAmt = 0.98f;

    public bool canSpin = true;
    public bool spinStarted = false;
    public bool numPicked = false;

    public int targetNum;
    public float fadeTimer = 0;
    public float alpha = 0;
    public TMPro.TextMeshProUGUI Rollednumber;

    // Start is called before the first frame update
    void Start()
    {
        rotSpeed = 0;
        accSpeed = 0;
        transform.rotation = Quaternion.Euler(0, 0, -10);
        alpha = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fadeTimer <= 0)
        {
            FadeText();
        }
        else
        {
            fadeTimer -= Time.fixedDeltaTime;
        }

        Rollednumber.color = new Color(1, 1, 1, alpha);

        rotSpeed += accSpeed * Time.fixedDeltaTime;

        transform.Rotate(0, 0, rotSpeed);

        rotSpeed *= dragAmt;
        accSpeed *= dragAmt;

        if (rotSpeed <= 0.5f && spinStarted)
        {
            rotSpeed = 0;
            accSpeed = 0;
            spinStarted = false;
            float tempAngle = transform.rotation.eulerAngles.z;

            if (tempAngle >= 350 || tempAngle <= 17)
            {
                targetNum = 6;
                Rollednumber.text = "6";
                alpha = 1;
                fadeTimer = 2;
            }
            else if (tempAngle > 17 && tempAngle <= 48)
            {
                targetNum = 3;
                Rollednumber.text = "3";
                alpha = 1;
                fadeTimer = 2;
            }
            else if (tempAngle > 48 && tempAngle <= 79)
            {
                targetNum = 4;
                Rollednumber.text = "4";
                alpha = 1;
                fadeTimer = 2;
            }
            else if (tempAngle > 79 && tempAngle <= 110)
            {
                targetNum = 6;
                Rollednumber.text = "6";
                alpha = 1;
                fadeTimer = 2;
            }
            else if (tempAngle > 110 && tempAngle <= 141)
            {
                targetNum = 5;
                Rollednumber.text = "5";
                alpha = 1;
                fadeTimer = 2;
            }
            else if (tempAngle > 141 && tempAngle <= 172)
            {
                targetNum = 4;
                Rollednumber.text = "4";
                alpha = 1;
                fadeTimer = 2;
            }
            else if (tempAngle > 172 && tempAngle <= 195)
            {
                targetNum = 1;
                Rollednumber.text = "1";
                alpha = 1;
                fadeTimer = 2;
            }
            else if (tempAngle > 195 && tempAngle <= 230)
            {
                targetNum = 5;
                Rollednumber.text = "5";
                alpha = 1;
                fadeTimer = 2;

            }
            else if (tempAngle > 230 && tempAngle <= 259)
            {
                targetNum = 6;
                Rollednumber.text = "6";
                alpha = 1;
                fadeTimer = 2;
            }
            else if (tempAngle > 259 && tempAngle <= 290)
            {
                targetNum = 3;
                Rollednumber.text = "3";
                alpha = 1;
                fadeTimer = 2;
            }
            else if (tempAngle > 290 && tempAngle <= 320)
            {
                targetNum = 2;
                Rollednumber.text = "2";
                alpha = 1;
                fadeTimer = 2;
            }
            else if (tempAngle > 320 && tempAngle < 350)
            {
                targetNum = 4;
                Rollednumber.text = "4";
                alpha = 1;
                fadeTimer = 2;
            }
            if (Input.GetKey(KeyCode.W)) targetNum = 54;
            numPicked = true;
        }
    }

    public void spinWheel()
    {
        if (!spinStarted && canSpin)
        {
            accSpeed = Random.Range(500, 600);
            dragAmt = Random.Range(0.88f, 0.92f);
            spinStarted = true;
            canSpin = false;
        }
    }

    public void FadeText()
    {
        if (alpha >= 0) alpha -= Time.fixedDeltaTime;
        else alpha = 0;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenInfo : MonoBehaviour
{
    private float alpha = 0;
    private float animAlpha = 0;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public Vector3 handlePosition;

    private bool startLerp = false;
    private float animDelay = 1;

    void Start()
    {
        startPosition = TokenAnimation.instance.buttonLocation;
        endPosition = TokenAnimation.instance.endPosition.position;
        handlePosition = TokenAnimation.instance.gameObject.transform.position;
        GetComponent<Image>().sprite = TokenAnimation.instance.playerSprite;
        transform.localScale = new Vector3(8, 8, 0);
    }

    void Update()
    {
        if (startLerp)
        {
            if (Vector3.Distance(transform.position, endPosition) <= 4)
            {
                // ++ to player pressed
                Destroy(this.gameObject);
            }
            else
            {
                animAlpha += Time.deltaTime;
                transform.position = CalculatePosition(animAlpha);
                transform.localScale = CalculateScale(animAlpha);
            }
        }
        else
        {
            alpha += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, AnimMath.Slide(transform.position.y, startPosition.y + 100, alpha), transform.position.z);
            animDelay -= Time.deltaTime;
            if(animDelay <= 0)
            {
                animDelay = 0;
                startLerp = true;
                startPosition = new Vector3(startPosition.x, startPosition.y + 100, startPosition.z);
            }
        }
    }

    private Vector3 CalculateScale(float alpha)
    {
        Vector3 scaleValue = AnimMath.Lerp(transform.localScale, new Vector3(4, 4, 1), alpha);
        return scaleValue;
    }

    private Vector3 CalculatePosition(float percent)
    {
        Vector3 positionC = AnimMath.Lerp(startPosition, handlePosition, percent);

        Vector3 positionD = AnimMath.Lerp(handlePosition, endPosition, percent);
        Vector3 positionE = AnimMath.Lerp(positionC, positionD, percent);

        return positionE;
    }
}

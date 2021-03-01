﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ATTACHED TO: howToScene > Canvas > Slides

public class HowToButtons : MonoBehaviour
{
    public GameObject slide1, slide2, slide3, slide4, slide5, slide6, buttonL, buttonR, playButton;
    public Image knob1, knob2, knob3, knob4, knob5, knob6;
    public GameObject[] slides = new GameObject[6];
    public Image[] knobs = new Image[6];
    Color col;
    int currentSlide = 0;

    // Start is called before the first frame update
    void Start()
    {
        slides[0] = slide1;
        slides[1] = slide2;
        slides[2] = slide3;
        slides[3] = slide4;
        slides[4] = slide5;
        slides[5] = slide6;

        knobs[0] = knob1;
        knobs[1] = knob2;
        knobs[2] = knob3;
        knobs[3] = knob4;
        knobs[4] = knob5;
        knobs[5] = knob6;
    }

    public void RightButtonClick()
    {
        LowerOpacity();
        ++currentSlide;
        RaiseOpacity();

        if (currentSlide == 5)
        {
            buttonR.SetActive(false);
            playButton.SetActive(true);
        }
        if (currentSlide > 0) buttonL.SetActive(true);
    }

    public void LeftButtonClick()
    {
        LowerOpacity();
        --currentSlide;
        RaiseOpacity();

        if (currentSlide == 0) buttonL.SetActive(false);
        if (currentSlide < 5) buttonR.SetActive(true);
    }

    public void ResetHowTo()
    {
        for(int i = 1; i < 6; ++i)
        {
            currentSlide = i;
            LowerOpacity();
        }
        slide1.SetActive(true);
        buttonL.SetActive(false);
        buttonR.SetActive(true);
        playButton.SetActive(false);
        col = knobs[0].color;
        col.a = 1f;
        knobs[0].color = col;
        currentSlide = 0;
    }

    void LowerOpacity()
    {
        slides[currentSlide].SetActive(false);
        col = knobs[currentSlide].color;
        col.a = .2f;
        knobs[currentSlide].color = col;
    }

    void RaiseOpacity()
    {
        slides[currentSlide].SetActive(true);
        col = knobs[currentSlide].color;
        col.a = 1f;
        knobs[currentSlide].color = col;
    }
}

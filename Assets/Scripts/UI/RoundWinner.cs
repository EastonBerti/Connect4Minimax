﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundWinner : MonoBehaviour {

    static Text mText;
    // Use this for initialization
    void Start()
    {
        mText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void UpdateRoundWinnerText(string winner)
    {
        mText.text = winner + " Won The Round!";
    }
}
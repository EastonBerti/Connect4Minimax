using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourBadges : MonoBehaviour {
    Image mBadge;
	// Use this for initialization
	void Start () {
        mBadge = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        Color temp = mBadge.color;
        if (LevelManager._isPlayer1Red)
        {
            temp.a = 0;
        }
        else
        {
            temp.a = 1;
        }
        mBadge.color = temp;
    }
}

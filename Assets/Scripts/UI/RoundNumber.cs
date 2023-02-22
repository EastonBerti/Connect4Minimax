using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundNumber : MonoBehaviour {
    static Text mText;
	// Use this for initialization
	void Start () {
        mText = GetComponent<Text>();
        UpdateRoundNumber(LevelManager.GetNumberOfRounds());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void UpdateRoundNumber(int numOfRounds)
    {
        SoundManager.PlaySound(SoundType.BUTTON);
        int winningNum = (int)(((float)numOfRounds / 2) + 1);
        if (winningNum == 1)
        {
            mText.text = numOfRounds + " Round";
        }
        else
        {
            mText.text = numOfRounds + " Rounds\nFirst to " + winningNum;
        }
    }

}

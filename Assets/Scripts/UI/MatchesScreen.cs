using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchesScreen : MonoBehaviour {
     CanvasGroup mCanvasGroup;
     bool mIsToggled = false;
	// Use this for initialization
	void Start () {
        mCanvasGroup = GetComponent<CanvasGroup>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ToggleMatchesList()
    {
        mIsToggled = !mIsToggled;
        if (mIsToggled)
        {
            mCanvasGroup.alpha = 1;
            mCanvasGroup.blocksRaycasts = true;
            mCanvasGroup.interactable = true;
        }
        else
        {
            mCanvasGroup.alpha = 0;
            mCanvasGroup.blocksRaycasts = false;
            mCanvasGroup.interactable = false;
        }
    }
}

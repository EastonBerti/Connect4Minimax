using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour {
    static Animator mAnimator;
	// Use this for initialization
	void Start () {
        mAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void TriggerWinScreen()
    {
        SoundManager.StopSound(SoundType.BATTLE);
        SoundManager.PlaySound(SoundType.FANFARE);
        mAnimator.SetTrigger("appear");
    }
}

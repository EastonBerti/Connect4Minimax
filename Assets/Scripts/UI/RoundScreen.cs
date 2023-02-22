using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundScreen : MonoBehaviour {
    static Animator mAnimator;
    // Use this for initialization
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void TriggerRoundWinScreen()
    {
        SoundManager.StopSound(SoundType.BATTLE);
        SoundManager.PlaySound(SoundType.FANFARE);
        mAnimator.SetTrigger("appear");
    }
    public static void ResetTriggerRoundWinScreen()
    {
        mAnimator.SetTrigger("disappear");
    }
}

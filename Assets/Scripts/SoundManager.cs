using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType { PRELUDE, BATTLE, BUTTON, FANFARE, DROP, POINT};

//This class manages the sound
public class SoundManager : MonoBehaviour {
    static AudioSource[] audioSources;
	// Use this for initialization
	void Start () {
        audioSources = GetComponents<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound(SoundType soundType)
    {
        audioSources[(int)soundType].Play();
    }
    public static void StopSound(SoundType soundType)
    {
        audioSources[(int)soundType].Stop();
    }
}

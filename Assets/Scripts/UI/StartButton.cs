using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
    Button mButton;
	// Use this for initialization
	void Start () {
        mButton = GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
		if(LevelManager._Player1.Length==0 || LevelManager._Player2.Length == 0)
        {
            mButton.interactable = false;
        }
        else
        {
            mButton.interactable = true;
        }
    }
}

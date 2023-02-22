using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenericButton : MonoBehaviour {
    Button mButton;
    // Use this for initialization
    void Start () {
        mButton = GetComponent<Button>();
        mButton.onClick.AddListener(delegate () { SoundManager.PlaySound(SoundType.BUTTON); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

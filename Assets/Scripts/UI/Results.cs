using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour {
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
    public static void UpdateResultsText()
    {
        Match matchResult = new Match(LevelManager.GetRedPlayer(), LevelManager.GetYellowPlayer(), MatchManager.GetRedPlayerScore(), MatchManager.GetYellowPlayerScore(), LevelManager.GetNumberOfRounds());
        mText.text = matchResult.toReadableString(); ;
    }
}

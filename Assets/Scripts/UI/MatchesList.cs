using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchesList : MonoBehaviour {
    static Text mText;
    // Use this for initialization
    void Start()
    {
        mText = GetComponent<Text>();
        UpdateMatchList();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void UpdateMatchList()
    {
        List<Match> matches = SaveManager.LoadMatches()._Matches;
        matches.Reverse();

        string matchesString = "";

        matches.ForEach((entry) => {
            matchesString += entry.toReadableString() + "\n";
        });

        mText.text = matchesString;
    }

}

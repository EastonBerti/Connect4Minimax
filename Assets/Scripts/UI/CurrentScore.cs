using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour {
    static Text mText;
    // Use this for initialization
    void Start()
    {
        mText = GetComponent<Text>();
        UpdateScoreText("");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void UpdateScoreText(string winner)
    {
        int player1Points = MatchManager._Player1Points;
        int player2Points = MatchManager._Player2Points;

        string text = LevelManager._Player1 + ": "+ player1Points + "\n" + LevelManager._Player2 + ": " + player2Points;

        if(winner.Length > 0)
        {
            text += "\n" + winner + " won the round!";
        }
        mText.text = text;
    }
}

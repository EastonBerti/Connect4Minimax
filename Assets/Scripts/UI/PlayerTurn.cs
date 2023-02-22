using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurn : MonoBehaviour {
    static Text mText;
	// Use this for initialization
	void Start () {
       // UpdatePlayerTurnText(MatchManager.GetCurrentPlayerName());
    }
    private void Awake()
    {
        mText = GetComponent<Text>();
        UpdatePlayerTurnText(LevelManager._Player1);
    }
    // Update is called once per frame
    void Update () {
		
	}
    public static void UpdatePlayerTurnText(string playerName)
    {
        if(playerName.Length == 0)
        {
            playerName = "Default";
        }
        mText.text = "It's " + playerName + "'s turn.";
    }
}

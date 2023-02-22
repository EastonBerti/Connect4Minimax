using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Match
{
    string _RedPlayer;
    string _YellowPlayer;
    int _RedPlayerScore;
    int _YellowPlayerScore;
    int _NumberOfRounds;
    public Match(string _RedPlayer, string _YellowPlayer, int _RedPlayerScore, int _YellowPlayerScore, int _NumberOfRounds)
    {
        this._RedPlayer = _RedPlayer;
        this._YellowPlayer = _YellowPlayer;
        this._RedPlayerScore = _RedPlayerScore;
        this._YellowPlayerScore = _YellowPlayerScore;
        this._NumberOfRounds = _NumberOfRounds;
    }
    public string toReadableString()
    {
        return "Red: " + _RedPlayer + ": " + _RedPlayerScore + " , " + "Yellow: " + _YellowPlayer + ": " + _YellowPlayerScore + " , Rounds: " + _NumberOfRounds;
    }
}

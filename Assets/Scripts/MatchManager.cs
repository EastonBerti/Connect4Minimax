using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Class manages the match logic
public class MatchManager : MonoBehaviour {
    public static PieceType _isPlayerTurn = PieceType.RED;
    public static bool _CanPlay = true;
    public static int _Player1Points = 0;
    public static int _Player2Points = 0;
    public static bool _IsGameOver = true;

    // Use this for initialization
    void Start () {
        _IsGameOver = false;
        if (!LevelManager._isPlayer1Red)
        {
            EndTurn();
        }
       // RoundNumber.UpdateRoundNumber(LevelManager.GetNumberOfRounds());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void EndTurn()
    {
        if(_isPlayerTurn ==  PieceType.RED){
            _isPlayerTurn = PieceType.YELLOW;
        }
        else
        {
            _isPlayerTurn = PieceType.RED;
        }
        PlayerTurn.UpdatePlayerTurnText(GetCurrentPlayerName());
        RunAIIfCan();
    }
    public static string GetCurrentPlayerName()
    {
        if (LevelManager._isPlayer1Red)
        {
            if (_isPlayerTurn == PieceType.RED)
            {
                return LevelManager._Player1;
            }
            else
            {
                return LevelManager._Player2;
            }
        }
        else
        {
            if (_isPlayerTurn == PieceType.RED)
            {
                return LevelManager._Player2;
            }
            else
            {
                return LevelManager._Player1;
            }
        }
    }
    public static void DetermineWinnerOfRound(PieceType type)
    {
        if (LevelManager._isPlayer1Red)
        {
            if (_isPlayerTurn == PieceType.RED)
            {
                _Player1Points++;
            }
            else
            {
                _Player2Points++;
            }
        }
        else
        {
            if (_isPlayerTurn == PieceType.RED)
            {
                _Player2Points++;
            }
            else
            {
                _Player1Points++;
            }
        }
        CurrentScore.UpdateScoreText(GetCurrentPlayerName());

        int winningScore = (int)(((float)LevelManager.GetNumberOfRounds() / 2) + 1);

        if (winningScore <= _Player1Points || winningScore <= _Player2Points)//Game is won
        {
            UltimateWinner.UpdateUltimateWinnerText(GetCurrentPlayerName());
            Results.UpdateResultsText();
            SaveMatch();
            WinScreen.TriggerWinScreen();
            _IsGameOver = true;
        }
        else//round won
        {
            RoundScreen.TriggerRoundWinScreen();
            RoundWinner.UpdateRoundWinnerText(GetCurrentPlayerName());
            _IsGameOver = true;
        }
    }
    public void CleanBoard()
    {
        Board.CleanBoard();
        RoundScreen.ResetTriggerRoundWinScreen();
        _IsGameOver = false;
        RunAIIfCan();
    }
    private static void RunAIIfCan()
    {
        if (GetCurrentPlayerName() == "AI" && LevelManager._isAIPlaying)
        {
            AIManager.PlayMove(Board.GetGrid(), _isPlayerTurn);
        }
    }
    public static int GetRedPlayerScore()
    {
        if (LevelManager._isPlayer1Red)
        {
            return _Player1Points;
        }
        else
        {
            return _Player2Points;
        }
    }
    public static int GetYellowPlayerScore()
    {
        if (LevelManager._isPlayer1Red)
        {
            return _Player2Points;
        }
        else
        {
            return _Player1Points;
        }
    }
    private static void SaveMatch()
    {
        SaveManager.SaveMatch(new Match(LevelManager.GetRedPlayer(),LevelManager.GetYellowPlayer(),GetRedPlayerScore(), GetYellowPlayerScore(), LevelManager.GetNumberOfRounds()));
    }
}

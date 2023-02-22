using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//This class is used to manage scene loading and extra meta data
public class LevelManager : MonoBehaviour {
    const string MAIN_SCENE = "MainScreen";
    const string PLAY_SCENE = "PlayScreen";

    public static string _Player1="";
    public static string _Player2="";

    public static bool _isPlayer1Red=true;
    public static bool _isAIPlaying=false;

    static int mNumOfRounds = 1;
    static int depth = 2;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
    public static int GetNumberOfRounds()
    {
        if (mNumOfRounds == 0)
        {
            mNumOfRounds = 1;
        }
        return mNumOfRounds;
    }
    public static int GetDepth()
    {
        return depth;
    }
    public void SetPlayer1(string name)
    {
        _Player1 = name;
    }
    public void SetPlayer2(string name)
    {
        _Player2 = name;
    }
    public void SetNumOfRounds(Slider slider)
    {
        int num = (int)slider.value;
        if (num % 2 == 0)
        {
            num++;
        }
        mNumOfRounds = num;
        RoundNumber.UpdateRoundNumber(mNumOfRounds);
    }

    public void SetDepthNum(Slider slider)
    {
        int num = (int)slider.value;
        depth = num;
        DifficultyNum.UpdateDifficultyNumber(depth);
    }

    public static void SwitchColours()
    {
        _isPlayer1Red = !_isPlayer1Red;
    }

    public void LoadPlayScreen()
    {
        SceneManager.LoadScene(PLAY_SCENE);
    }
    public void LoadPlayScreenAI()
    {
        _Player2 = "AI";
        _isAIPlaying = true;
        SceneManager.LoadScene(PLAY_SCENE);
    }
    public void LoadMainScreen()
    {
        SceneManager.LoadScene(MAIN_SCENE);
        ResetParameters();
    }

    static void ResetParameters()
    {
        _isPlayer1Red = true;
        mNumOfRounds = 0;
        _Player1 = "";
        _Player2 = "";
        MatchManager._CanPlay = true;
        MatchManager._IsGameOver = false;
        MatchManager._isPlayerTurn = PieceType.RED;
        MatchManager._Player1Points = 0;
        MatchManager._Player2Points = 0;
        Board.CleanBoard();
    }

    public static string GetRedPlayer()
    {
        if (_isPlayer1Red)
        {
            return _Player1;
        }
        else
        {
            return _Player2;
        }
    }
    public static string GetYellowPlayer()
    {
        if (_isPlayer1Red)
        {
            return _Player2;
        }
        else
        {
            return _Player1;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is used to maintain the inner game logic
public class Board : MonoBehaviour {

    public const int mGridWidth = 7;
    public const int mGridHeight = 6;
    static PieceType[,] mGrid = new PieceType[mGridWidth, mGridHeight];

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
   public static PieceType[,] GetGrid()
    {
        return mGrid;
    }
    public static bool ColumnHasRoom(int colNum)
    {
        return mGrid[colNum, 0] == PieceType.EMPTY;
    }
    public static void InsertToBoard(Vector2Int insertPoint, PieceType type)
    {
        if (mGrid[insertPoint.x, insertPoint.y] == PieceType.RED|| mGrid[insertPoint.x, insertPoint.y] == PieceType.YELLOW) {
            Debug.LogError("Overlapping insertion");
        }

        mGrid[insertPoint.x, insertPoint.y] = type;
        CheckWinner(insertPoint,type);
    }
    public static void CheckWinner(Vector2Int startingPoint, PieceType type)
    {
        if(CheckHorizontal(startingPoint, type) ||
            CheckDiagTLDR(startingPoint, type) ||
            CheckDiagDLTR(startingPoint, type) ||
            CheckDown(startingPoint, type)) 
        {
            //Determine who actually one and if there's an ultimate winner
            MatchManager.DetermineWinnerOfRound(type);
            MatchManager._CanPlay = false;
        }
        else if (GridIsFull())//Theres no more moves left
        {
            RoundScreen.TriggerRoundWinScreen();
            RoundWinner.UpdateRoundWinnerText("TIE! No one");
            MatchManager._IsGameOver = true;
        }
        else
        {
            MatchManager._CanPlay = true;
            MatchManager.EndTurn();
        }
    }
    //Check to see if theres a winning condition
    static bool CheckHorizontal(Vector2Int startingPoint, PieceType type)
    {

        if ((CountRight(startingPoint, type, mGrid) + CountLeft(startingPoint, type, mGrid)) >= 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static bool CheckDiagTLDR(Vector2Int startingPoint, PieceType type)
    {
        if( (CountDownRight(startingPoint, type, mGrid) + CountUpLeft(startingPoint, type, mGrid)) >= 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static bool CheckDiagDLTR(Vector2Int startingPoint, PieceType type)
    {
        if( (CountUpRight(startingPoint, type, mGrid) + CountDownLeft(startingPoint, type, mGrid)) >= 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static bool CheckDown(Vector2Int startingPoint, PieceType type)
    {
        int count = CountDown(startingPoint,type,mGrid);
        if (count >= 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Count all ways you can win based on the last token dropped
    public static int CountDown(Vector2Int startingPoint, PieceType type, PieceType[,] grid)
    {
        int count = 0;
        for (int i = startingPoint.y + 1; i < mGridHeight; i++)
        {
            if (grid[startingPoint.x, i] == type)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        return count;
    }

    public static int CountRight(Vector2Int startingPoint, PieceType type, PieceType[,] grid)
    {
        int count = 0;
        for (int i = startingPoint.x+1; i < mGridWidth; i++)
        {
            if (grid[i, startingPoint.y] == type)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        return count;
    }
    public static int CountLeft(Vector2Int startingPoint, PieceType type,PieceType[,] grid)
    {
        int count = 0;
        for (int i = startingPoint.x-1; i >= 0; i--)
        {
            if (grid[i, startingPoint.y] == type)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        return count;
    }

    public static int CountDownRight(Vector2Int startingPoint, PieceType type, PieceType[,] grid)
    {
        int count = 0;
        int i = startingPoint.x+1;
        int j = startingPoint.y+1;

        for (; i <mGridWidth && j<mGridHeight; i++, j++)
        {
            if (grid[i, j] == type)
            {
                count++;
            }
            else {
                break;
            }
        }
        return count;
    }

    public static int CountUpLeft(Vector2Int startingPoint, PieceType type, PieceType[,] grid)
    {
        int count = 0;
        int i = startingPoint.x-1;
        int j = startingPoint.y-1;

        for (; i >= 0 && j >= 0; i--, j--)
        {
            if (grid[i, j] == type)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        return count;
    }
    public static int CountUpRight(Vector2Int startingPoint, PieceType type, PieceType[,] grid)
    {
        int count = 0;
        int i = startingPoint.x+1;
        int j = startingPoint.y-1;

        for (; i <mGridWidth && j >= 0; i++, j--)
        {
            if (grid[i, j] == type)
            {
                count++;
            }
            else {
                break;
            }
        }
        return count;
    }
    public static int CountDownLeft(Vector2Int startingPoint, PieceType type, PieceType[,] grid)
    {
        int count = 0;
        int i = startingPoint.x-1;
        int j = startingPoint.y+1;

        for (; i >= 0 && j < mGridHeight; i--, j++)
        {
            if (grid[i, j] == type)
            {
                count++;
            }
            else {
                break;
            }
        }
        return count;
    }
    //clean board for next round
    public static void CleanBoard()
    {
        for(int i = 0; i < mGridWidth; i++)
        {
            for (int j = 0; j < mGridHeight; j++)
            {
                mGrid[i, j] = PieceType.EMPTY;
            }
        }
        Token[] tokens = GameObject.FindObjectsOfType<Token>();
        for(int i = 0; i < tokens.Length; i++)
        {
            Destroy(tokens[i].gameObject);
        }
        MatchManager._CanPlay = true;
        SoundManager.PlaySound(SoundType.BATTLE);
    }
    //returns a deep copy of the grid
    public static PieceType[,] BoardCopy(PieceType[,] board)
    {
        PieceType[,] copy = new PieceType[Board.mGridWidth, Board.mGridHeight];
        for (int i = 0; i < Board.mGridWidth; i++)
        {
            for (int j = 0; j < Board.mGridHeight; j++)
            {
                copy[i, j] = board[i, j];
            }
        }
        return copy;
    }
    public static void PrintBoard(PieceType[,] board)
    {
        string str = "";
        for (int j = 0; j < mGridHeight; j++)
        {
            for (int i = 0; i < mGridWidth; i++)
            {
                str += board[i,j]+" ";
            }
            str += "\n";
        }
        Debug.Log(str);
    }

    //checks to see if there is room left in the grid
    public static bool GridIsFull()
    {
        for (int j = 0; j < mGridHeight; j++)
        {
            for (int i = 0; i < mGridWidth; i++)
            {
                if(mGrid[i,j] == PieceType.EMPTY)
                {
                    return false;
                }
            }
        }
        return true;
    }
}

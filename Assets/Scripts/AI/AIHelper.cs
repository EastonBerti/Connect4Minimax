//Easton Berti
//eberti@nevada.unr.edu
//Reworked existing ai functions 491 minimax
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Helper functions for the AI
public class AIHelper {
    public static int choiceMaker(int[] value)
    {
        int choice = 0;
        int invalidCount = 0;
        int initializedCount = 0;
        Debug.Log("value length = " + value.Length);
        while (true)
        {
            invalidCount = 0;
            initializedCount = 0;
            for (int i = 0; i < value.Length; i++)
            {

                if (value[i] == 0)
                {
                    initializedCount++;
                    if (initializedCount >= Board.mGridWidth)
                    {
                        //init choice if the board is empty, randomize
                        choice = Random.Range(0, Board.mGridWidth);
                        break;
                    }
                }
                if (value[i] > value[choice])
                {
                    choice = i;
                }
            }
            if (Board.ColumnHasRoom(choice))
            {
                break;
            }
            else
            {
                value[choice] = -1;
                invalidCount++;
                if (invalidCount >= Board.mGridWidth)
                {
                    //no options
                    choice = -1;
                    break;
                }

            }

        }
        return choice;
    }



    public static int miniMax(PieceType[,] board, PieceType type, int columnNum, int depth)
    {
        PieceType enemy;
        if (type == PieceType.RED)
        {
            enemy = PieceType.YELLOW;
        }
        else
        {
            enemy = PieceType.RED;
        }

        int value = 0;

        // check if search tree has reached maximum depth
        if (depth == LevelManager.GetDepth())
        {
            return AIManager.EvaluateBoard(board, type, depth);
        }

        // generate all possible moves
        List<int> possibleMoves = getValidColumns(board);
        //Maximize ai's value
        if (type == PieceType.RED)
        {
            int maxVal = int.MinValue;
            foreach (int move in possibleMoves)
            {
                PieceType[,] boardCopy = Board.BoardCopy(board);
                int rowNum = CreateNextState(ref boardCopy, type, move);
                Vector2Int startingPoint = new Vector2Int(move, rowNum);
                int score = rowCount(startingPoint, type, boardCopy);

                // recursive call to minimax
                score += miniMax(boardCopy, enemy, move, depth + 1);
                if (score > maxVal)
                {
                    maxVal = score;
                }
            }
            return maxVal;
        }
        else {
            //Minimizes players value
            int minVal = int.MaxValue;
            foreach (int move in possibleMoves)
            {
                PieceType[,] boardCopy = Board.BoardCopy(board);
                int enemyRowNum = CreateNextState(ref boardCopy, enemy, move);
                Vector2Int enemyStartingPoint = new Vector2Int(move, enemyRowNum);
                int score = rowCount(enemyStartingPoint, enemy, boardCopy);

                // recursive call to minimax
                score += miniMax(boardCopy, type, move, depth + 1);
                if (score < minVal)
                {
                    minVal = score;
                }

            }
            return minVal;
        }


    }


    //returns valid columns
    private static List<int> getValidColumns(PieceType[,] board)
    {
        List<int> validColumns = new List<int>();

        for (int column = 0; column < Board.mGridWidth; column++)
        {
            if (board[column, Board.mGridHeight - 1] == PieceType.EMPTY)
            {
                validColumns.Add(column);
            }
        }

        return validColumns;
    }
    //checks the next state to evaluate choice
    private static int CreateNextState(ref PieceType[,] boardCopy, PieceType type, int columnNum){
        int row = 0;
        for (int j = 0; j <= Board.mGridHeight; j++){
            if (j == Board.mGridHeight){
                boardCopy[columnNum, j - 1] = type;
                row = j - 1;
                break;
            }
            else if ((boardCopy[columnNum, j] != PieceType.EMPTY) && (j - 1) >= 0){
                boardCopy[columnNum, j - 1] = type;
                row = j - 1;
                break;
            }
        }
        return row;
    }

    //check how many of a team type are in a row
    private static int rowCount(Vector2Int startingPoint, PieceType type, PieceType[,] grid){
        int count = 0;
        count += CountHorizontal(startingPoint, type, grid);
        count += CountDiagUpLeft(startingPoint, type, grid);
        count += CountDiagUpRight(startingPoint, type, grid);
        count += CountVertical(startingPoint, type, grid);
        return count;
    }

    private static int CountHorizontal(Vector2Int startingPoint, PieceType type, PieceType[,] grid){
        int value = Board.CountRight(startingPoint, type, grid) + Board.CountLeft(startingPoint, type, grid);
        int count = 0;
        if (value == 2)        {
            count += 5;
        }
        if (value >= 3)        {
            count += 50;
        }
        return count;

    }

    private static int CountDiagUpLeft(Vector2Int startingPoint, PieceType type, PieceType[,] grid){
        int value = Board.CountDownRight(startingPoint, type, grid) + Board.CountUpLeft(startingPoint, type, grid);
        int count = 0;
        if (value == 2){
            count += 5;
        }
        if (value >= 3)
        {
            count += 50;
        }

        return count;

    }

    private static int CountDiagUpRight(Vector2Int startingPoint, PieceType type, PieceType[,] grid){
        int value = Board.CountUpRight(startingPoint, type, grid) + Board.CountDownLeft(startingPoint, type, grid);
        int count = 0;
        if (value == 2)
        {
            count += 5;
        }
        if (value >= 3)
        {
            count += 50;
        }
        return count;
    }

    private static int CountVertical(Vector2Int startingPoint, PieceType type, PieceType[,] grid){
        int value = Board.CountDown(startingPoint, type, grid);
        int count = 0;
        if (value == 2)
        {
            count += 5;
        }
        if (value >= 3)
        {
            count += 50;
        }
        return count;
    }

    
}

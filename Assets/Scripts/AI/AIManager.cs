//Easton Berti
//eberti@nevada.unr.edu
//Reworked existing ai functions for 491 minimax
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This manages AI's behaviour
public class AIManager : MonoBehaviour {
    public static Column[] mColumns;
    // Use this for initialization
    void Start() {
        Debug.Log("depth = " + LevelManager.GetDepth());
        mColumns = FindObjectsOfType<Column>();
        SortColumns();
    }

    // Update is called once per frame
    void Update() {

    }

    public static void PlayMove(PieceType[,] board, PieceType type)
    {
        int choice = EvaluateBoard(board, type, 0);
        if (choice >= 0)
        {
            mColumns[choice].SpawnToken();
        }
    }
    public static int EvaluateBoard(PieceType[,] board, PieceType type, int depth)
    {
        int choice = 0;
        int[] values = new int[mColumns.Length];
        if (depth >= LevelManager.GetDepth() ) { return AIHelper.choiceMaker(values); }
        for (int i = 0; i < mColumns.Length; i++)
        {
            //evaluates all possible choices for the AI
            values[i] = AIHelper.miniMax(board, type, i, depth);
        }
        choice = AIHelper.choiceMaker(values);
        return choice;
    }

    private static void SortColumns()
    {
        Column[] tempColumns = new Column[mColumns.Length];
        for (int i = 0; i < mColumns.Length; i++)
        {
            tempColumns[i] = mColumns[i];
        }

        for (int i = 0; i < mColumns.Length; i++)
        {
            mColumns[tempColumns[i].mColumnNumber] = tempColumns[i];
        }
    }



}

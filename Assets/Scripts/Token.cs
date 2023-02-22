using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceType { EMPTY = 0, RED, YELLOW }

public class Token : MonoBehaviour
{
    Rigidbody mRigidbody;
    bool mIsLanded;
    Vector2Int mCoordinate;
    public PieceType mType;
    
    // Use this for initialization
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
        mRigidbody.velocity = new Vector3(0, -50, 0);
        SoundManager.PlaySound(SoundType.DROP);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetColumn(int column)
    {
        mCoordinate.x = column;
    }
    public void SetRow(int row)
    {
        mCoordinate.y = row;
    }
    public int GetColumn()
    {
        return mCoordinate.x;
    }
    public int GetRow()
    {
        return mCoordinate.y;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!mIsLanded && (collision.gameObject.tag == "Base" || collision.gameObject.tag == "Token"))
        {
            mRigidbody.velocity = new Vector3(0, 0, 0);
            Destroy(mRigidbody);
            mIsLanded = true;

            if (collision.gameObject.tag == "Base")
            {
                SetRow(Board.mGridHeight - 1);
            }
            else if (collision.gameObject.tag == "Token")
            {
                int tokenCollidedRow = collision.gameObject.GetComponent<Token>().GetRow();
                SetRow(tokenCollidedRow - 1);
            }
            //insert to inner logic grid
            Board.InsertToBoard(mCoordinate, mType);
            SoundManager.PlaySound(SoundType.POINT);
        }
    }
}

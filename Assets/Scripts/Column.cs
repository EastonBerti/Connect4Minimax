using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This object is used to indicated where the play wants to drop the token
public class Column : MonoBehaviour {
    MeshRenderer mMeshRenderer;
    public int mColumnNumber;
    [SerializeField]
    GameObject mRedToken;
    [SerializeField]
    GameObject mYellowToken;

    Transform SpawnPoint;


    // Use this for initialization
    void Start () {
        mMeshRenderer = GetComponent<MeshRenderer>();
        SpawnPoint = this.gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnMouseOver()
    {
        if (!MatchManager._IsGameOver)
        {
            mMeshRenderer.enabled = true;
        }
    }
    private void OnMouseDown()
    {
        SpawnToken();
    }
    public void SpawnToken()
    {
        if (MatchManager._CanPlay && Board.ColumnHasRoom(mColumnNumber) && !MatchManager._IsGameOver)
        {
            GameObject instantiatedToken;
            if (MatchManager._isPlayerTurn == PieceType.RED)
            {
                instantiatedToken = Instantiate(mRedToken, SpawnPoint.position, Quaternion.identity) as GameObject;
            }
            else
            {
                instantiatedToken = Instantiate(mYellowToken, SpawnPoint.position, Quaternion.identity) as GameObject;
            }
            instantiatedToken.GetComponentInChildren<Token>().SetColumn(mColumnNumber);
            MatchManager._CanPlay = false;

        }
    }
    private void OnMouseExit()
    {
        mMeshRenderer.enabled = false;
    }
}

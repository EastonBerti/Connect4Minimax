using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultyNum : MonoBehaviour
{

    static Text mText;
    // Use this for initialization
    void Start()
    {
        mText = GetComponent<Text>();
        UpdateDifficultyNumber(LevelManager.GetDepth());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void UpdateDifficultyNumber(int depth)
    {
        SoundManager.PlaySound(SoundType.BUTTON);
        mText.text = "Depth of Search / \nDifficulty: " + depth;

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveFile {
    public List<Match> _Matches;
    public SaveFile(List<Match> matches)
    {
        _Matches = matches;
    }
    public SaveFile()
    {
        _Matches = new List<Match>();
    }
}


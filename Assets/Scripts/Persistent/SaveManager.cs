using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void SaveMatch(Match match)
    {
        SaveFile loadedMatches = LoadMatches();
        loadedMatches._Matches.Add(match);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Connect4.save");
        bf.Serialize(file, loadedMatches);
        file.Close();
    }

    public static SaveFile LoadMatches()
    {
        SaveFile loadedMatches;
        if (File.Exists(Application.persistentDataPath + "/Connect4.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Connect4.save", FileMode.Open);
            loadedMatches = (SaveFile)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            loadedMatches = new SaveFile();
        }
        return loadedMatches;
    }
}

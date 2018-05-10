using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // Handle Configuration settings
        if (Config.ClearSaveDataOnStart) {
            SaveData.DeleteData();
        }

        // GameManager startup
        Application.runInBackground = true;
        DontDestroyOnLoad(gameObject);
        SaveData.Load();
	}
}

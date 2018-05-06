using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Application.runInBackground = true;
        DontDestroyOnLoad(gameObject);
        SaveData.Load();
	}
}

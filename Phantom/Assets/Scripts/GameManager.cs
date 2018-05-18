using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public bool isVeronicaAdded = true; //checks if Veronica has joined party
	// Use this for initialization
	void Start () {
				Debug.Log("GAMEMANAGER START CALLED");
				if (isVeronicaAdded == true) {
						Debug.Log("ISVERONICAADDED IS TRUE!!!!!!!!!");
						GameObject.Find("Companion2").transform.localScale = new Vector3(1, 1, 1);
						GameObject.Find("Companion2").GetComponent<Rigidbody>().useGravity = true;
						GameObject.Find("Companion2").GetComponent<CompanionMovement>().enabled = true;
				}
				if (isVeronicaAdded == false) {
						Debug.Log("ISVERONICAADDED IS FALSE!!!!!!!!");
				}

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

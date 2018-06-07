using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static bool isVeronicaAdded; //checks if Veronica has joined party
	// Use this for initialization
	void Start () {
				Debug.Log("Gamemanager start called.");
				if (isVeronicaAdded == true) {
						Debug.Log("isVeronicaAdded is true");
						GameObject.Find("Veronica").transform.localScale = new Vector3(1, 1, 1);
						GameObject.Find("Veronica").GetComponent<Rigidbody>().useGravity = true;
						GameObject.Find("Veronica").GetComponent<CompanionMovement>().enabled = true;
				}
				if (isVeronicaAdded == false) {
						Debug.Log("isVeronicaAdded is false");
				}

				Scene currentScene = SceneManager.GetActiveScene();
				string sceneName = currentScene.name;

				if (sceneName == "InsideTheEmployeeLoungeCutScene" ||
				sceneName == "driving_to_the_park"){
					GameObject.Find("Panel").GetComponent<TimedDialogue>().enabled = true;
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

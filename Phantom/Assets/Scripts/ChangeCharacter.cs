using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour {
	public GameObject activeCharacter;
	public GameObject[] characters;

	public void Swap(int i){
		activeCharacter.GetComponent<Movement>().enabled = false;
		activeCharacter.GetComponent<PlayerEventTrigger> ().enabled = false;
		characters[i].GetComponent<CompanionMovement> ().enabled = false;
		activeCharacter.GetComponent<Player>().enabled = false;

		//Set new active character to player character
		characters[i].GetComponent<Movement>().enabled = true;
		characters[i].GetComponent<PlayerEventTrigger> ().enabled = true;
		characters[i].GetComponent<Player>().enabled = true;
		activeCharacter.GetComponent<CompanionMovement> ().enabled = true;


		characters[i].layer = 8; //Player
		activeCharacter.layer = 9; //Companion

		//Set activeCharacter
		activeCharacter = characters [i];

		//Swap camera
		CameraController.target = activeCharacter;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (activeCharacter == characters [0]) {
				Swap (1);
			} else {
				Swap (0);
			}
		}
	}
}

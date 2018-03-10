using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour {
	[SerializeField] GameObject textObjPrefab;
	[SerializeField] GameObject dialogueUI;
	[SerializeField] Dialogue[] conversation;
	int currentIndex = 0;

	public void TriggerDialogue(){
		dialogueUI.SetActive (true);
	}

	public void Next(){
		GameObject temp = Instantiate (textObjPrefab, gameObject.transform);
		temp.GetComponent<Text> ().text = conversation [currentIndex].name;
		temp.GetComponent<Text> ().color = conversation [currentIndex].GetNameColor ();

		temp = Instantiate (textObjPrefab, gameObject.transform);
		temp.GetComponent<Text> ().text = conversation [currentIndex].text;

		currentIndex++;
	}

	[System.Serializable]
	class Dialogue{
		public string name;
		public string text;

		public Color GetNameColor(){
			if (name == "test1") {
				return Color.blue;
			} else if (name == "test2") {
				return Color.red;
			}
			return Color.white;
		}
	}

	void FixedUpdate(){
		if (Input.GetKeyDown (KeyCode.T)) {
			Debug.Log ("Next");
			Next ();
		}
	}


}


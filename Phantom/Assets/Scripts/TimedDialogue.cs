using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedDialogue : MonoBehaviour {

	[SerializeField] GameObject textObjPrefab;
	[SerializeField] GameObject dialogueUI;
	[SerializeField] Dialogue[] conversation;
	int currentIndex = 0;
	float timer = 0;

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
		public float timeToDisplay;

		public Color GetNameColor(){
			if (name == "test1") {
				//return Color.blue;
				return new Color(0,0,1,0);
			} else if (name == "test2") {
				//return Color.red;
				return new Color(1,0,0,0);
			}
			return Color.white;
		}
	}

	void FixedUpdate(){
		timer += Time.fixedDeltaTime;
		if (currentIndex < conversation.Length && timer >= conversation[currentIndex].timeToDisplay) {
			Debug.Log ("Next");
			Next ();
		}
	}

}

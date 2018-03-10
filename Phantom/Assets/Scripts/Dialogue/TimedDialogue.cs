﻿using System.Collections;
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
        temp.GetComponent<Text>().fontStyle = FontStyle.Bold;


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
            Debug.Log("Setting name color: " + name);
            if (name == "Veronica") {
                //return Color.blue;
                return ConvertColor(83,126,162);
            }
            else if (name == "Robbie") {
                //return Color.red;
                return ConvertColor(97,160,112);
            }
            else if (name == "Christopher") {
                //return Color.red;
                return ConvertColor(124,95,149);
            }
        
            else {

                Debug.Log("No valid color");
                return Color.white;
            }
		}

        Color ConvertColor(int r, int g, int b) {
            return new Color(r / 255f, g / 255f, b / 255f);
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

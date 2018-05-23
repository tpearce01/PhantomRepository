using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedDialogue : MonoBehaviour {
    [SerializeField] float timeBetweenText;
	[SerializeField] GameObject textObjPrefab;
	[SerializeField] GameObject dialogueUI;
    [TextArea(3,10)]
    public string dialogue;

    List<Dialogue> conversation = new List<Dialogue>();
    int currentIndex = 0;
	float timer = 0;

    void Awake() {
        ParseDialogue();
    }

    void Start() {
        // Required to resolve rendering bug when adding the first TextObject to the dialogue panel
        GameObject temp = Instantiate(textObjPrefab, gameObject.transform);
        temp.GetComponent<Text>().text = "";
    }

    public void ParseDialogue() {
        string[] dialogueData = dialogue.Split(new string[] { Environment.NewLine, ":", "\n"}, System.StringSplitOptions.None);
        for (int i = 0; i < dialogueData.Length; i += 2) {
            Dialogue temp = new Dialogue();
            temp.name = dialogueData[i];
            temp.text = dialogueData[i + 1];
            conversation.Add(temp);
        }
    }

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
    
		public Color GetNameColor(){
            if (name.ToLower() == "veronica") {
                //return Color.blue;
                return ConvertColor(83,126,162);
            }
            else if (name.ToLower() == "robbie") {
                //return Color.red;
                return ConvertColor(97,160,112);
            }
            else if (name.ToLower() == "christopher") {
                //return Color.red;
                return ConvertColor(124,95,149);
            }
            else {
                return Color.white;
            }
		}

        Color ConvertColor(int r, int g, int b) {
            return new Color(r / 255f, g / 255f, b / 255f);
        }
    }

	void FixedUpdate(){
		timer += Time.fixedDeltaTime;
		if (currentIndex < conversation.Count && timer >= timeBetweenText) {
			Next ();
            timer = 0;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionalDialogue : MonoBehaviour {

	public GameObject dialogueCanvas;

	void OnTriggerEnter2D(Collider2D other){
		dialogueCanvas.SetActive(true);
	}
}

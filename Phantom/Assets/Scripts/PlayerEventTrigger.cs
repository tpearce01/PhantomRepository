using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventTrigger : MonoBehaviour {

	public static PlayerEventTrigger instance;

	public bool triggerActive;
	public bool activeThisFrame;

	void OnEnable(){
		instance = this;
	}

	void FixedUpdate(){
		if (activeThisFrame) {
			activeThisFrame = false;
		}
	}

	public void ActivateTrigger(){
		triggerActive = true;
		activeThisFrame = true;
	}

	public void DeactivateTrigger(){
		triggerActive = false;
	}
}


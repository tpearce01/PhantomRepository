using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Used by Tyler for testing - Attach to a GameObject with a Text UI component to display a timer. Format: "F1"
public class Timer : MonoBehaviour {
    Text timerText;
    float timer = 0;

	void Start () {
        timerText = gameObject.GetComponent<Text>();
	}
	
	void FixedUpdate () {
        timer += Time.deltaTime;
        timerText.text = "Time: " + timer.ToString("F1");
	}
}

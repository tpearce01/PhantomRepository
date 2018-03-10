using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForward : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Time.timeScale = 6.0f;
            Debug.Log("Time Scale: " + Time.timeScale);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Time.timeScale = 1.0f;
            Debug.Log("Time Scale: " + Time.timeScale);
        }
	}
}

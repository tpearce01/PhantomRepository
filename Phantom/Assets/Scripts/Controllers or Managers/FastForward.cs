using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForward : MonoBehaviour {

    public float timeModifier;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Time.timeScale = timeModifier;
            Debug.Log("Time Scale: " + Time.timeScale);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Time.timeScale = 1.0f;
            Debug.Log("Time Scale: " + Time.timeScale);
        }
	}
}

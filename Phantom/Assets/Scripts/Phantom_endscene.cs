using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phantom_endscene : MonoBehaviour {
    Vector3 startPosition;
    public GameObject followTarget;

    void Awake() {
        startPosition = gameObject.transform.position;
    }

    void Start() {
        Instantiate(followTarget);
        CameraFollow.AddTarget(followTarget);
    }

	void FixedUpdate () {
        transform.position = startPosition + new Vector3(0, Mathf.Sin(Time.time)*0.1f, 0);  // Move in sin pattern
    }
}

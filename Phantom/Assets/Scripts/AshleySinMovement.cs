using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshleySinMovement : MonoBehaviour {
    Vector3 startPosition;

    private void Start()
    {
        startPosition = gameObject.transform.localPosition;
    }
    void FixedUpdate()
    {
        gameObject.transform.localPosition = startPosition + new Vector3(0, Mathf.Sin(Time.time) * 0.1f, 0);  // Move in sin pattern
    }
}

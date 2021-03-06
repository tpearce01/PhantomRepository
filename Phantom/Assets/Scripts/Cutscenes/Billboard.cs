﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {
    public Vector2 showAtPos;
    public float showAtTime;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
        gameObject.transform.position = showAtPos;
        // Adding this here since this is the only scene that uses it. 
        AudioManager.instance.PlaySoundLoop(Sound.Track1);
	}
	
	// Update is called once per frame
	void Update () {
        showAtTime -= Time.deltaTime;
        if (showAtTime <= 0) {
            Move();
        }
	}

    void Move() {
        gameObject.transform.position -= Vector3.left * moveSpeed/10f;
    }
}

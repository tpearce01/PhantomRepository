﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//public static Camera mainCamera;
	public static GameObject target;
	public float sizeLerpSpeed;
	public float followLerpSpeed;
	public Vector2 offset;

	float defaultSize = 5;

	void Awake(){
        //mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		target = GameObject.FindGameObjectWithTag ("Player");
	}

	void LateUpdate(){
		Follow ();
		Resize ();
	}

	void Follow(){
		GetComponent<Camera>().transform.position = Vector3.Lerp (gameObject.transform.position, new Vector3(target.transform.position.x, target.transform.position.y, gameObject.transform.position.z), followLerpSpeed) + (Vector3)offset;
	}

	void Resize(){
		float newSize;
		newSize = defaultSize;
		GetComponent<Camera>().orthographicSize = Mathf.Lerp (GetComponent<Camera>().orthographicSize, newSize, sizeLerpSpeed);
	}
}

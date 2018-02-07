using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
	Vector3 defaultScale;
	bool gaining = true;
	public float magnitudeGain;
	[SerializeField] GameObject popup;
	[SerializeField] GameObject spriteObject;
	[SerializeField] Color hoverColor;
	Color defaultColor = Color.white;

	// Use this for initialization
	void Start () {
		defaultScale = gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Idle ();
	}

	void Idle(){
		if (gaining) {
			gameObject.transform.localScale = gameObject.transform.localScale * 1.005f;
			if (gameObject.transform.localScale.magnitude > defaultScale.magnitude + magnitudeGain) {
				gaining = !gaining;
			}
		} else {
			gameObject.transform.localScale = gameObject.transform.localScale * 0.995f;
			if (gameObject.transform.localScale.magnitude < defaultScale.magnitude) {
				gaining = !gaining;
			}
		}
		spriteObject.transform.Rotate (new Vector3 (0, 0, 1));
	}

	void OnMouseEnter(){
		spriteObject.GetComponent<SpriteRenderer> ().color = hoverColor;
		popup.SetActive (true);
	}

	void OnMouseExit(){
		spriteObject.GetComponent<SpriteRenderer> ().color = defaultColor;
		popup.SetActive (false);
	}

	void OnMouseDown(){
		TriggerEvent ();
		PlayerEventTrigger.instance.ActivateTrigger ();
	}

	public virtual void TriggerEvent (){

	}
}

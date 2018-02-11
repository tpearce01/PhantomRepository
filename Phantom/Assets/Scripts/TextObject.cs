using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextObject : MonoBehaviour {
	float timer;
	bool activated;

	void Update () {
		timer += Time.deltaTime;
		if (timer >= 3.0f && !activated) {
			StartCoroutine (Fade());
			activated = true;
		}
	}

	IEnumerator Fade(){
		Text dialogueText = gameObject.GetComponent<Text> ();
		for (int i = 0; i < 50; i++) {
			dialogueText.color = new Color (dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, dialogueText.color.a - .02f);
			yield return new WaitForSeconds(0.02f);
		}
		Destroy (gameObject);
	}
}

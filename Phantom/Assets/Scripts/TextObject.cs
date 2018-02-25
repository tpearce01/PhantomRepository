using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextObject : MonoBehaviour {
	float timer;
	bool activated;

	public float fadeTime = 3.0f;

	void OnEnable(){
		StartCoroutine (FadeIn());
	}

	void Update () {
		timer += Time.deltaTime;
		if (timer >= fadeTime && !activated) {
			StartCoroutine (Fade());
			activated = true;
		}
	}

	IEnumerator Fade(){
		Debug.Log ("Fade");
		Text dialogueText = gameObject.GetComponent<Text> ();
		dialogueText.color = new Color (dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, 1f);
		for (int i = 0; i < 50; i++) {
			dialogueText.color = new Color (dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, dialogueText.color.a - .02f);
			yield return new WaitForSeconds(0.02f);
		}
		Destroy (gameObject);
	}

	IEnumerator FadeIn(){
		Text dialogueText = gameObject.GetComponent<Text> ();
		RectTransform rt = gameObject.GetComponent<RectTransform> ();

		dialogueText.color = new Color (dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, 0f);
		rt.sizeDelta = new Vector2 (rt.sizeDelta.x,0);
		for (int i = 0; i < 20; i++) {
			rt.sizeDelta = new Vector2 (rt.sizeDelta.x,rt.sizeDelta.y + 2);
			yield return new WaitForSeconds(0.01f);
		}
			
		for (int i = 0; i < 50; i++) {
			dialogueText.color = new Color (dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, dialogueText.color.a + .05f);
			yield return new WaitForSeconds(0.02f);
		}

	}
}

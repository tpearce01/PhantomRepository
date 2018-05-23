using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextObject : MonoBehaviour {
	float timer;
	bool activated;

	public float fadeTime = 3.0f;

	void Start(){
        Text dialogueText = gameObject.GetComponent<Text>();
        RectTransform rt = gameObject.GetComponent<RectTransform>();

        dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, 0f);
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, 0);

        StartCoroutine (FadeIn(dialogueText, rt));
	}

	void Update () {
		timer += Time.deltaTime;
		if (timer >= fadeTime && !activated) {
			StartCoroutine (Fade());
			activated = true;
		}
	}

	IEnumerator Fade(){
		Text dialogueText = gameObject.GetComponent<Text> ();
		dialogueText.color = new Color (dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, 1f);
		for (int i = 0; i < 50; i++) {
			dialogueText.color = new Color (dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, dialogueText.color.a - .02f);
			yield return new WaitForSeconds(0.02f);
		}
		Destroy (gameObject);
	}

	IEnumerator FadeIn(Text dialogueText, RectTransform rt) {
        yield return new WaitForEndOfFrame();   // I don't know why, but this seems to fix a rendering bug?

        for (int i = 0; i < 20; i++) {
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.y + (dialogueText.preferredHeight / 20));
            yield return new WaitForSeconds(0.02f);
        }

        for (int i = 0; i < 50; i++) {
			dialogueText.color = new Color (dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, dialogueText.color.a + .04f);
			yield return new WaitForSeconds(0.02f);
		}
    }
}

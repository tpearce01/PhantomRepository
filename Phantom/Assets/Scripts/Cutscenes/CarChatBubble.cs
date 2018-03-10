using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChatBubble : MonoBehaviour {
    public float timeToBegin = 0;
	public float timeBetweenSwap;
	float timer = 0;

	public GameObject[] chatBubbles;
	int index = 0;

	public int numChatBubblesToDisplay;
	int displayed = 0;

	void Update(){
        if (timeToBegin <= 0) {
            timer += Time.deltaTime;
            DisplayBubble();
        }
        else {
            timeToBegin -= Time.deltaTime;
        }
	}

    void DisplayBubble() {
        if (displayed < numChatBubblesToDisplay && timer >= timeBetweenSwap) {
            timer = 0;
            //chatBubbles[index].SetActive(false);
            StartCoroutine(FadeOut(index));
            index = (index + 1) % chatBubbles.Length;
            //chatBubbles[index].SetActive(true);
            StartCoroutine(FadeIn(index));
            displayed++;
        }
        else if (displayed == numChatBubblesToDisplay && timer >= timeBetweenSwap) {
            //chatBubbles[index].SetActive(false);
            StartCoroutine(FadeOut(index));
            displayed++;
        }
    }

    IEnumerator FadeIn(int index) {
        chatBubbles[index].SetActive(true);
        SpriteRenderer s = chatBubbles[index].GetComponent<SpriteRenderer>();
        s.color = new Color(1, 1, 1, 0);
        for (int i = 0; i < 50; i++) {
            s.color = new Color(s.color.r, s.color.g, s.color.b, s.color.a + .02f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator FadeOut(int index) {
        SpriteRenderer s = chatBubbles[index].GetComponent<SpriteRenderer>();
        s.color = new Color(1, 1, 1, 1);
        for (int i = 0; i < 50; i++) {
            s.color = new Color(s.color.r, s.color.g, s.color.b, s.color.a - .02f);
            yield return new WaitForSeconds(0.01f);
        }
        chatBubbles[index].SetActive(false);
    }
}

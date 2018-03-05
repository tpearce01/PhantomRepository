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
            chatBubbles[index].SetActive(false);
            index = (index + 1) % chatBubbles.Length;
            chatBubbles[index].SetActive(true);
            displayed++;
        }
        else if (displayed == numChatBubblesToDisplay && timer >= timeBetweenSwap) {
            chatBubbles[index].SetActive(false);
            displayed++;
        }
    }
}

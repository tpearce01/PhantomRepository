using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarouselSceneController : MonoBehaviour {
    public GameObject blackOverlayPrefab;
    public float fadeTime = 3;

    void Start() {
        BlackOverlaySetup overlay = Instantiate(blackOverlayPrefab).GetComponent<BlackOverlaySetup>();
        overlay.FadeOut(fadeTime);
    }
    
}

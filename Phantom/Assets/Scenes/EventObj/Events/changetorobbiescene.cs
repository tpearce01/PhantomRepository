using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    Event to change scenes. Specift the scene to load from the dropdown in the Unity inspector.
    blackOverlayPrefab should not be changed - It needs to be the overlay prefab to fade out properly
     */
public class changetorobbiescene : Event
{
    //public Scenes sceneToLoad;              // Scene to load
    public float delay;                     // Delay before the fading starts
    public GameObject blackOverlayPrefab;   // Black screen overlay
    float fadeTime = 3;                     // Fade duration

    // Fade to black then change scenes
    public override IEnumerator TriggerEvent()
    {
        yield return new WaitForSeconds(delay);
        BlackOverlaySetup overlay = Instantiate(blackOverlayPrefab).GetComponent<BlackOverlaySetup>();
        overlay.FadeIn(fadeTime);
        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene("ferriswheelwithrobbie");
        yield break;
    }

}

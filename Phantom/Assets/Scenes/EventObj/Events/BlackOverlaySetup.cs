using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    BlackOverlaySetup

    Purpose:
        This is used to fade a scene to or from a black screen. Create a local
        reference then initiate fade in or out. See the following example case: 

        BlackOverlaySetup overlay = Instantiate(blackOverlayPrefab).GetComponent<BlackOverlaySetup>();
        overlay.FadeIn(fadeTime);
     */
public class BlackOverlaySetup : MonoBehaviour {

    Image overlay;                      // Black Image Overlay
    bool fadeIn = false;                // Is the background currently fading in?
    private float callsPerSec;          // FixedUpdate calls per second
    private float alphaChangePerFrame;  // Amount to fade each frame

    // Set default values
    void Initialize(float alpha) {
        callsPerSec = 1 / Time.fixedDeltaTime;
        overlay = gameObject.transform.Find("Canvas").Find("Overlay").GetComponent<Image>();
        overlay.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, alpha);
    }

    /// <summary>
    /// Fade FROM black
    /// </summary>
    /// <param name="duration"></param>
    public void FadeIn(float duration) {
        StartCoroutine(FadeInOverlay(duration));
    }
    /// <summary>
    /// Fade TO black
    /// </summary>
    /// <param name="duration"></param>
    public void FadeOut(float duration) {
        StartCoroutine(FadeOutOverlay(duration));
    }

    // Coroutine to fade out
    IEnumerator FadeOutOverlay(float a_fadeDuration) {
        Initialize(1);
        fadeIn = false;
        StopCoroutine("FadeInOverlay");
        alphaChangePerFrame = 1 / (a_fadeDuration * callsPerSec);

        // Fade Out
        while (overlay.color.a > 0 && !fadeIn) {
            overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, overlay.color.a - alphaChangePerFrame);
            yield return new WaitForFixedUpdate();
        }
    }

    // Coroutine to fade in
    IEnumerator FadeInOverlay(float a_fadeDuration) {
        Initialize(0);
        fadeIn = true;
        StopCoroutine("FadeOutOverlay");
        alphaChangePerFrame = 1 / (a_fadeDuration * callsPerSec);

        // Fade In
        while (overlay.color.a < 1 && fadeIn) {
            overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, overlay.color.a + alphaChangePerFrame);
            yield return new WaitForFixedUpdate();
        }

    }
}

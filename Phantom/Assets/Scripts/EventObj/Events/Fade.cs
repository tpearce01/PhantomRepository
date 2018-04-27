using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {
    Coroutine coroutine;              // Currently executing coroutine
    private float fadeDuration = 1;     // Default fade duration = 1 second
    private float callsPerSec;          // FixedUpdate frames per second
    private float alphaChangePerFrame;  // Amount to fade per frame
    bool fadeIn = false;                // Is this currently fading in?

    // Set default values
    void Initialize() {
        callsPerSec = 1 / Time.fixedDeltaTime;
        alphaChangePerFrame = 1 / (fadeDuration * callsPerSec);
    }

    /// <summary>
    /// INPUT : Gameobject to attach fade component to
    /// </summary>
    /// <param name="callSource"></param>
    /// <returns></returns>
    public static Fade CreateFade(GameObject a_callSource) {
        Fade toReturn = a_callSource.AddComponent<Fade>();
        toReturn.Initialize();
        return toReturn;
    }

    /// <summary>
    /// INPUT : Gameobject to attach fade component to
    /// </summary>
    /// <param name="callSource"></param>
    /// <returns></returns>
    public static Fade CreateFade(GameObject a_callSource, float a_fadeDuration) {
        Fade toReturn = a_callSource.AddComponent<Fade>();
        toReturn.fadeDuration = a_fadeDuration;
        toReturn.Initialize();
        return toReturn;
    }

    /// <summary>
    /// Fade in target text
    /// </summary>
    /// <param name="target"></param>
    public void FadeInText(Text target) {
        coroutine = StartCoroutine(FadeInTextCR(target, fadeDuration));
    }

    /// <summary>
    /// Fade out target text
    /// </summary>
    /// <param name="target"></param>
    public void FadeOutText(Text target) {
        coroutine = StartCoroutine(FadeOutTextCR(target, fadeDuration));
    }

    public void FadeOutSprite(SpriteRenderer target, float a_duration) {
        StartCoroutine(FadeOutSpriteCR(target, a_duration));
    }

    public void FadeInImage(Image target, float a_duration) {
        coroutine = StartCoroutine(FadeInImageCR(target, a_duration));
    }

    public void FadeOutImage(Image target, float a_duration) {
        coroutine = StartCoroutine(FadeOutImageCR(target, a_duration));
    }

    // Coroutine to fade in Image
    IEnumerator FadeInImageCR(Image target, float a_fadeDuration) {
        Initialize();

        // Fade In
        while (target.color.a < 1) {
            target.color = new Color(target.color.r, target.color.g, target.color.b, target.color.a + alphaChangePerFrame);
            yield return new WaitForFixedUpdate();
        }
    }

    // Coroutine to fade out Image
    IEnumerator FadeOutImageCR(Image target, float a_fadeDuration) {
        Initialize();

        // Fade Out
        while (target.color.a > 0) {
            target.color = new Color(target.color.r, target.color.g, target.color.b, target.color.a - alphaChangePerFrame);
            yield return new WaitForFixedUpdate();
        }
    }

    // Coroutine to fade in
    IEnumerator FadeInTextCR(Text target, float a_fadeDuration) {
        Initialize();
        fadeIn = true;
        if (coroutine != null)
            StopCoroutine(coroutine);

        // Fade In
        while (target.color.a < 1 && fadeIn) {
            target.color = new Color(target.color.r, target.color.g, target.color.b, target.color.a + alphaChangePerFrame);
            yield return new WaitForFixedUpdate();
        }

    }

    // Coroutine to fade out
    IEnumerator FadeOutTextCR(Text target, float a_fadeDuration) {
        Initialize();
        fadeIn = false;
        if(coroutine != null)
            StopCoroutine(coroutine);

        // Fade Out
        while (target.color.a > 0 && !fadeIn) {
            target.color = new Color(target.color.r, target.color.g, target.color.b, target.color.a - alphaChangePerFrame);
            yield return new WaitForFixedUpdate();
        }
    }

    // Coroutine to fade out a SpriteRenderer
    IEnumerator FadeOutSpriteCR(SpriteRenderer target, float a_fadeDuration) {
        Initialize();
        fadeIn = false;
        StopCoroutine("FadeInOverlay");

        // Fade Out
        while (target.color.a > 0) {
            target.color = new Color(target.color.r, target.color.g, target.color.b, target.color.a - alphaChangePerFrame);
            yield return new WaitForFixedUpdate();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    private float fadeDuration = 1;     // Default fade duration = 1 second
    private float callsPerSec;          // FixedUpdate frames per second
    private float alphaChangePerFrame;  // Amount to fade per frame
    bool fadeIn = false;                // Is this currently fading in?

    // Set default values
    void Start() {
        callsPerSec = 1 / Time.fixedDeltaTime;
        alphaChangePerFrame = 1 / (fadeDuration * callsPerSec);
    }

    /// <summary>
    /// INPUT : Gameobject to attach fade component to
    /// </summary>
    /// <param name="callSource"></param>
    /// <returns></returns>
    public static Fade CreateFade(GameObject a_callSource) {
        return a_callSource.AddComponent<Fade>();
    }

    /// <summary>
    /// INPUT : Gameobject to attach fade component to
    /// </summary>
    /// <param name="callSource"></param>
    /// <returns></returns>
    public static Fade CreateFade(GameObject a_callSource, float a_fadeDuration) {
        Fade temp = a_callSource.AddComponent<Fade>();
        temp.fadeDuration = a_fadeDuration;
        return temp;
    }

    /// <summary>
    /// Fade in target text
    /// </summary>
    /// <param name="target"></param>
    public void FadeInText(Text target) {
        StartCoroutine(FadeInTextCR(target, fadeDuration));
    }

    /// <summary>
    /// Fade out target text
    /// </summary>
    /// <param name="target"></param>
    public void FadeOutText(Text target) {
        StartCoroutine(FadeOutTextCR(target, fadeDuration));
    }

    // Coroutine to fade out
    IEnumerator FadeOutTextCR(Text target, float a_fadeDuration) {
        fadeIn = false;
        StopCoroutine("FadeInTextCR");
        alphaChangePerFrame = 1 / (a_fadeDuration * callsPerSec);
        //target.color = new Color(target.color.r, target.color.g, target.color.b, 1f);
        while (target.color.a > 0 && !fadeIn) {
            target.color = new Color(target.color.r, target.color.g, target.color.b, target.color.a - alphaChangePerFrame);
            yield return new WaitForFixedUpdate();
        }
    }

    // Coroutine to fade in
    IEnumerator FadeInTextCR(Text target, float a_fadeDuration) {
        fadeIn = true;
        StopCoroutine("FadeOutTextCR");
        alphaChangePerFrame = 1 / (a_fadeDuration * callsPerSec);
        //target.color = new Color(target.color.r, target.color.g, target.color.b, 0f);
        while (target.color.a < 1 && fadeIn) {
            target.color = new Color(target.color.r, target.color.g, target.color.b, target.color.a + alphaChangePerFrame);
            yield return new WaitForFixedUpdate();
        }

    }
}

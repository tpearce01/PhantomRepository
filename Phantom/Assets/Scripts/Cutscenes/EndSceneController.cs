using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneController : MonoBehaviour {
    Fade fade;
    float timer;
    Text text;
    // Use this for initialization
    void Start () {
        
        StartCoroutine(End());
	}

    IEnumerator End() {
        fade = Fade.CreateFade(gameObject, 3);
        text = gameObject.GetComponent<Text>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        yield return new WaitForSeconds(1);
        fade.FadeInText(text);
        yield return new WaitForSeconds(6);
        fade.FadeOutText(text);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(Scenes.MainMenu.ToString());
    }
}

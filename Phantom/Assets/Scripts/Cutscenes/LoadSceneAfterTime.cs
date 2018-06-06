using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneAfterTime : MonoBehaviour {
    public float timeToLoad;
    public Scenes sceneToLoad;
    public bool withFade = false;
    bool isFading = false;
    public GameObject fadePanel;
	
	// Update is called once per frame
	void Update () {
        timeToLoad -= Time.deltaTime;
        if (timeToLoad <= 0) {
            if (withFade && !isFading) {
                StartCoroutine(Fade());
            }
            else if (!withFade) {
                SceneManager.LoadScene(sceneToLoad.ToString());
            }
        }
	}

    IEnumerator Fade() {
        isFading = true;
        fadePanel.SetActive(true);
        Image s = fadePanel.GetComponent<Image>();
        for (int i = 0; i < 50; i++) {
            s.color = new Color(s.color.r, s.color.g, s.color.b, s.color.a + .02f);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneToLoad.ToString());
    }
}

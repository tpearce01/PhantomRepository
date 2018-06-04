using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene_InsidetheEmployeeLounge : MonoBehaviour
{
    public float timeToLoad;
    //public Scenes sceneToLoad;
    public bool withFade = false;
    public GameObject playerIn_Caroline;
    public GameObject playerout_robbie;
    public GameObject playerout_veronica;
    public GameObject playerout_yvette;
    public GameObject playerout_caroline;

    bool isFading = false;
    public GameObject fadePanel;

    // Update is called once per frame
    void Update()
    {
        timeToLoad -= Time.deltaTime;

        if (timeToLoad < 160 & timeToLoad > 160-Time.deltaTime) //caroline enters after some time
        {
            playerIn_Caroline.SetActive(true);
        }

        if (timeToLoad < 135 & timeToLoad > 135-Time.deltaTime) //robbie and veronica leave after some time
        {
            AudioManager.instance.PlaySound(Sound.GluggingWater);
        }

        if (timeToLoad < 70) //robbie and veronica leave after some time
        {
            playerout_robbie.SetActive(false);
            playerout_veronica.SetActive(false);
        }

        if (timeToLoad < 24)//yvette leaves
        {
            playerout_yvette.SetActive(false);
        }

        if (timeToLoad < 7 & timeToLoad > 7-Time.deltaTime) //caroline leaves
        {
            playerIn_Caroline.SetActive(false);
            AudioManager.instance.PlaySound(Sound.Thud);
        }

        if (timeToLoad <= 0)
        {
            if (withFade && !isFading)
            {
                StartCoroutine(Fade());
            }
            else if (!withFade)
            {
                SceneManager.LoadScene("InsideTheEmployeeLounge");
            }
        }
    }

    IEnumerator Fade()
    {
        isFading = true;
        fadePanel.SetActive(true);
        Image s = fadePanel.GetComponent<Image>();
        for (int i = 0; i < 50; i++)
        {
            s.color = new Color(s.color.r, s.color.g, s.color.b, s.color.a + .02f);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("InsideTheEmployeeLounge");
    }
}
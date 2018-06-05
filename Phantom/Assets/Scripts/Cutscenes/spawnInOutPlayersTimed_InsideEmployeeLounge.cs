using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class spawnInOutPlayersTimed_InsideEmployeeLounge : MonoBehaviour
{
    public float timeToLoad;
    //public Scenes sceneToLoad;
    public bool withFade = false;
    public GameObject playerIn_ashley;
    public GameObject door;

   

    bool isFading = false;
    public GameObject fadePanel;

    // Update is called once per frame
    void Update()
    {
        timeToLoad -= Time.deltaTime;

        if (timeToLoad < 42 & timeToLoad > 42-Time.deltaTime) //ghost enters after some time
        {
            playerIn_ashley.SetActive(true);
        }
        if (timeToLoad < 15) //ghost enters after some time
        {
            playerIn_ashley.SetActive(false);
        }


        if (timeToLoad < 0)
            {
            door.SetActive(true);
        }

        

        //if (timeToLoad <= 0)
        //{
        //    if (withFade && !isFading)
        //    {
        //        StartCoroutine(Fade());
        //    }
        //    else if (!withFade)
        //    {
        //        SceneManager.LoadScene("InsideTheEmployeeLounge");
        //    }
        //}
    }

    
}
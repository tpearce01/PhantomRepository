using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Journalentry2message : MonoBehaviour
{
    public GameObject JounralEntry2;

    public GameObject scene;
    //public GameObject AppearingTimer;


    // Update is called once per frame
    private void Update()
    {
        //if all these items are collected, set caroline active
        if ((JounralEntry2.GetComponent("Fade") as Fade) != null)
        {
            scene.SetActive(true);
        }
    }

}


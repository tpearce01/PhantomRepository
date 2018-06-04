using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerOnItems : MonoBehaviour
{
    public GameObject doll;
    public GameObject Jounral1;
    public GameObject dinerKey;

    public GameObject Player_caroline;

    public GameObject dialogue;
    //public GameObject AppearingTimer;
   

    // Update is called once per frame
    void Update()
    {
        //if all these items are collected, set caroline active
        if((doll.GetComponent("Fade") as Fade) != null & (Jounral1.GetComponent("Fade") as Fade) != null & (dinerKey.GetComponent("Fade") as Fade) != null)
        {
            Player_caroline.SetActive(true);
        }
    }
    
}

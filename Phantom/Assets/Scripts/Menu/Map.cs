using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public static bool GameIsMap = false;

    public GameObject mapMenuUI;

    // Update is called once per frame


    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    void Resume()
    {
        mapMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsMap = false;
    }

    void Pause()
    {
        mapMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsMap = true;
    }
}

	

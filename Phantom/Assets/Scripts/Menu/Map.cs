using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{

    public static bool GameIsMap = false;

    public GameObject mapMenuUI;
    public GameObject[] greenDots;

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (GameIsMap)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Resume()
    {
        mapMenuUI.SetActive(false);

       
        Time.timeScale = 1f;
        GameIsMap = false;

        if  (SceneManager.GetActiveScene().buildIndex == 2)
        {
            greenDots[1].SetActive(false);

        }
    }

    void Pause()
    {
        mapMenuUI.SetActive(true);

        if (SceneManager.GetActiveScene().buildIndex == 2) //get scene number to turn on correct dot
        {
            greenDots[1].SetActive(true);

        }


        Time.timeScale = 0f;
        GameIsMap = true;
    }

   

}


	

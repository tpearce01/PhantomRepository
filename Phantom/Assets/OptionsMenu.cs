using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour {

    public void MuteAudio()
    {
        AudioListener.pause = !AudioListener.pause;
        Debug.Log("Mute");
    }
}

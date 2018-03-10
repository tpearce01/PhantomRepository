using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour {

    public void MuteAudio()
    {
        Debug.Log("Mute");
        AudioListener.pause = !AudioListener.pause;
        
    }

    public void testgame()
    {
        Debug.Log("lick my ass");

    }
}

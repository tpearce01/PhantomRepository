using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarouselSceneController : MonoBehaviour {
    public GameObject blackOverlayPrefab;
    BlackOverlaySetup overlay;
    public float fadeTime = 3;
    float timer = 0;
    bool burnedFadeIn = false;
    bool burnedFadeOut = false;
    bool ghostNoise = false;
    bool curseVoice = false;
    bool curseVoiceFadeOut = false;
    public MoveObjectEvent ashleyLeavesEvent;
    bool ashelyLeft = false;
    bool ashleyRemoved = false;
    public ChangeSceneEvent changeSceneEvent;
    bool sceneEnd = false;

    void Start() {
        overlay = Instantiate(blackOverlayPrefab).GetComponent<BlackOverlaySetup>();
        overlay.FadeOut(fadeTime);
        AudioManager.instance.PlaySoundLoop(Sound.Track2);
    }

    void FixedUpdate() {
        timer += Time.deltaTime;

        // Phantom Appears - Spawn handled by SpawnAfterTime
        if (timer >= 68 && !ghostNoise) {
            AudioManager.instance.PlaySound(Sound.GhostNoise);
            ghostNoise = true;
        }
        if (timer >= 70 && !curseVoice) {
            AudioManager.instance.PlaySoundLoop(Sound.CurseVoice);
            curseVoice = true;
        }
        if (timer >= 496 && !curseVoiceFadeOut) {
            AudioManager.instance.EndSoundFade(Sound.CurseVoice, fadeTime);
            curseVoiceFadeOut = true;
        }

        // Ashley Leaves
        if (timer >= 440 && !ashelyLeft) {
            StartCoroutine(ashleyLeavesEvent.TriggerEvent());
            ashelyLeft = true;
        }
        if (timer >= 447 && !ashleyRemoved) {
            CameraFollow.RemoveTarget("Ashley");
            ashleyRemoved = true;
        }

        // Fade to burn body
        if (timer >= 496 && !burnedFadeIn) {
            overlay.FadeIn(fadeTime);
            burnedFadeIn = true;
            AudioManager.instance.PlaySound(Sound.Lighter);
        }
        if (timer >= 504 && !burnedFadeOut) {
            CameraFollow.RemoveTarget("CameraFollowTarget");
            Destroy(GameObject.Find("Phantom(Clone)"));
            Destroy(GameObject.Find("CameraFollowTarget(Clone)"));
            overlay.FadeOut(fadeTime);
            burnedFadeOut = true;
        }

        // Scene End
        if (timer >= 654 && !sceneEnd) {
            AudioManager.instance.EndAllSoundsFade(3);
            StartCoroutine(changeSceneEvent.TriggerEvent());
            sceneEnd = true;
        }
        
    }
    
}

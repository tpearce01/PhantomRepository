using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    AudioManager

    *Note: For audio to be playable, an instance of AudioManager must exist in the scene. For development, this generally means
    *       an instance of AudioManager will exist in every scene. Before we package the game for release, we absolutely must 
    *       remove these extra instances from each scene. Loading audio files is a very costly operation which will drastically
    *       increase load times. AudioManager should only need to load once - when the game is started. This will cause a longer 
    *       initial load time, but scene transitions will be quicker (as compared to loading audio files on a per-scene basis)
    *       because the audio files are kind of "cached". We should really convert these files to mp3

     - To play a sound: AudioManager.instance.PlaySound(Sound.MyAudioFileName);

     - When adding a new sound, be sure to
        1. Add the audio file to the AutoManager of the GameManager Prefab
        2. Add the name of the audio file to the Sound enum with a value corresponding to its index on the GameManager Prefab.
            Please do not move around the files already implemented - changing the index may break the AudioManager. Only make
            changes if you know what you are doing. 

     - Ask Tyler if you have any questions

     */
public class AudioManager : MonoBehaviour {
	public static AudioManager instance;

	[SerializeField] AudioClip[] audioFiles;
	List<AudioSource> sources = new List<AudioSource>();
	AudioSource target;
    float volume = 0.5f;

	void Awake(){
        if (AudioManager.instance != null) {
            Destroy(this);  // If an instance already exists, destroy this instance to reduce memory usage
        }
        else {
            instance = this;
        }
	}

    // TESTING ONLY
    //void Start() {
    //    AudioManager.instance.PlaySoundLoop(Sound.AmbientWind);
    //    AudioManager.instance.PlaySoundLoop(Sound.CurseVoice);
    //    AudioManager.instance.PlaySoundLoop(Sound.FireCraclking);
    //    AudioManager.instance.EndSoundFade(Sound.FireCraclking, 3);
    //    AudioManager.instance.EndAllSoundsFade(3);
    //}

	void Update(){
		Cleanup ();
	}

    public void UpdateVolume(float value) {
        volume = Mathf.Clamp(value, 0, 1);
    }

	/// <summary>
	/// Play a sound once.
	/// </summary>
	/// <param name="s">S.</param>
	public void PlaySound(Sound s){
		target = gameObject.AddComponent<AudioSource> ();
		target.clip = audioFiles [(int)s];
		target.Play ();
        target.volume = volume;
		sources.Add (target);
	}

    /// <summary>
    /// If you need to play an audio file at a specific relative volume, use this PlaySound method. It 
    /// will modify the master volume by a percentage. For example, if the master volume is 0.6f (60%)
    /// and you call "PlaySound(Sound.MySound, 0.5f);", it will play the sound at 0.3f (30%) volume
    /// </summary>
    /// <param name="s"></param>
    /// <param name="PercentVolumeModifier"></param>
    public void PlaySound(Sound s, float percentVolumeModifier) {
        target = gameObject.AddComponent<AudioSource>();
        target.clip = audioFiles[(int)s];
        target.Play();
        target.volume = Mathf.Clamp(volume * percentVolumeModifier, 0, 1);
        sources.Add(target);
    }

	/// <summary>
	/// Play a sound on a loop.
	/// </summary>
	/// <param name="s">S.</param>
	public void PlaySoundLoop(Sound s){
		target = gameObject.AddComponent<AudioSource> ();
		target.clip = audioFiles [(int)s];
		target.Play ();
        target.volume = volume;
        target.loop = true;
		sources.Add (target);
	}

	/// <summary>
	/// End a sound abruptly
	/// </summary>
	/// <param name="s">S.</param>
	public void EndSoundAbrupt(Sound s){
		for (int i = sources.Count - 1; i >= 0; i--) {
			if (sources [i].clip == audioFiles[(int)s]) {
				Destroy (sources [i]);
				sources.RemoveAt (i);
			}
		}
	}

	/// <summary>
	/// Ends all sounds abruptly
	/// </summary>
	public void EndAllSoundsAbrupt(){
		for (int i = sources.Count - 1; i >= 0; i--) {
			Destroy (sources [i]);
			sources.RemoveAt (i);
		}
	}

	/// <summary>
	/// Destroy all components which have finished playing
	/// </summary>
	void Cleanup(){
		for (int i = sources.Count - 1; i >= 0; i--) {
			if (!sources [i].isPlaying || sources[i].volume <= 0) {
				Destroy (sources [i]);
				sources.RemoveAt (i);
			}
		}
	}

	/// <summary>
	/// Fades a sound out over a duration.
	/// </summary>
	/// <param name="s">S.</param>
	/// <param name="duration">Duration.</param>
	public void EndSoundFade(Sound s, float duration){
		for (int i = 0; i < sources.Count; i++) {
			if (sources [i].clip == audioFiles [(int)s]) {
				StartCoroutine (Fadeout (sources[i], duration));
			}
		}
	}

    /// <summary>
    /// Ends all sounds by fading out over a duration. May cause multiple Fadeout coroutines
    /// for the same audiosource, but I don't think it'll cause serious issues. If strange
    /// behavior is noticed when fading out, consider testing this method.
    /// </summary>
    /// <param name="duration"></param>
    public void EndAllSoundsFade(float duration) {
        for (int i = 0; i < sources.Count; i++) {
            StartCoroutine(Fadeout(sources[i], duration));
        }
    }

    /// <summary>
    /// Checks if a sound is playing
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
	public bool IsPlaying(Sound s){
		for (int i = 0; i < sources.Count; i++) {
			if (sources [i].clip == audioFiles [(int)s]) {
				return true;
			}
		}
		return false;
	}

    /// <summary>
    /// Coroutine to fade out a single audio file
    /// </summary>
    /// <param name="a"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
	IEnumerator Fadeout(AudioSource a, float duration){
        float durationMod = a.volume;
        for (int i = 0; i < 50; i++) {
            if (a == null)
                yield break;    // Sound was likely already ended from a duplicate fadeout

            a.volume -= 0.02f * durationMod;
            yield return new WaitForSeconds(duration / 50);
        }
        a.volume = 0;
	}
}

// These need to match up with the audio files in AudioManager of the GameManager Prefab
public enum Sound{
    // SFX
	AmbientWind = 0,
    BottleClinking = 1,
    BreakingGlass = 2,
    BreakingSmallGlass = 3,
    BreakingTiles = 4,
    BunchOfFallingStuff = 5,
    CorkPop = 6,
    Creaking = 7,
    CurseVoice = 8,
    Digging = 9,
    Explosion = 10,
    FeedbackGlitch = 11,
    FireCraclking = 12,
    GhostNoice = 13,
    GhostSound1 = 14,
    GhostSound2 = 15,
    GhostSound3 = 16,
    GhostSound4 = 17,
    GluggingWater = 18,
    HorrorCurse1 = 19,
    LightSwitch = 20,
    Lighter = 21,
    Notification = 22,
    OpeningMetallicObject = 23,
    PhoneRing = 24,
    PhoneVibrate = 25,
    PouringSalt = 26,
    PressureValveRelease = 27,
    RainAndThunder = 28,
    RevealSoundFX = 29,
    RollerCoasterTrackMovement = 30,
    RopeStrain = 31,
    Rumble = 32,
    Scraping = 33,
    SonarPing = 34,
    SubsonicBassDrop1 = 35,
    SubsonicBassDrop2 = 36,
    SubsonicBassDrop3 = 37,
    TelephoneSound = 38,
    Thud = 39,
    TVStatic = 40,
    WaterDrip = 41,
    Welder = 42,
    WoodCrackling = 43,
    Writing = 44,
    Zipper = 45,

    // BGM
}

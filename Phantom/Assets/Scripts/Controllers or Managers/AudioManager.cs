using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public static AudioManager instance;

	[SerializeField] AudioClip[] audioFiles;
	List<AudioSource> sources = new List<AudioSource>();
	AudioSource target;
    float volume = 0.5f;

	void Awake(){
		instance = this;
		Application.runInBackground = true;
	}

	void Update(){
		Cleanup ();
	}

    void UpdateVolume(float value) {
        volume = value;
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

	public bool IsPlaying(Sound s){
		for (int i = 0; i < sources.Count; i++) {
			if (sources [i].clip == audioFiles [(int)s]) {
				return true;
			}
		}

		return false;
	}


	IEnumerator Fadeout(AudioSource a, float duration){
        float durationMod = a.volume;
		for (int i = 0; i < 50; i++) {
			a.volume -= 0.02f * durationMod;
			yield return new WaitForSeconds (duration / 50);
		}
		a.volume = 0;
	}
}

public enum Sound{
	Test = 0,
}

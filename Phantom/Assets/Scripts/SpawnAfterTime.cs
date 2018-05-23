using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawns a prefab after a set amount of time
public class SpawnAfterTime : MonoBehaviour {
    public GameObject prefabToSpawn;
    public float timeToSpawn;
    public float fadeDuration;
    public Vector2 positionToSpawn;
    Fade fade;
	
	void Update () {
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn <= 0) {
            Spawn();
        }
	}

    void Spawn() {
        GameObject go = Instantiate(prefabToSpawn, positionToSpawn, Quaternion.identity);
        fade = Fade.CreateFade(go, fadeDuration);

        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
        fade.FadeInSprite(go.GetComponent<SpriteRenderer>());
        Destroy(gameObject);
    }
}

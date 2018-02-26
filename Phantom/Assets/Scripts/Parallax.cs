using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
	[SerializeField] BackgroundLayer[] backgroundLayers;

	/// <summary>
	/// Set the initial positions of the backgrounds
	/// </summary>
	void SetPosition(){
		for (int i = 0; i < backgroundLayers.Length; i++) {
			//background[0] is in good starting position
			backgroundLayers[i].backgrounds [1].transform.position = new Vector3 (backgroundLayers[i].background.bounds.max.x * 2, backgroundLayers[i].backgrounds [1].transform.position.y, backgroundLayers[i].backgrounds [1].transform.position.z);
		}
	}

	void Initialize(){
		for (int i = 0; i < backgroundLayers.Length; i++) {
			backgroundLayers [i].backgrounds = new GameObject[2];
			backgroundLayers [i].backgrounds [0] = new GameObject ("b1" + i);
			backgroundLayers [i].backgrounds [0].AddComponent<SpriteRenderer> ().sprite = backgroundLayers[i].background;
			backgroundLayers [i].backgrounds [1] = new GameObject ("b2" + i);
			backgroundLayers [i].backgrounds [1].AddComponent<SpriteRenderer> ().sprite = backgroundLayers[i].background;
		}
	}

	void Move(){
		for (int i = 0; i < backgroundLayers.Length; i++) {
			if (backgroundLayers [i].backgrounds [0].transform.position.x <= -backgroundLayers [i].background.bounds.max.x * 2) {
				backgroundLayers [i].backgrounds [0].transform.position = Vector3.right * backgroundLayers [i].background.bounds.max.x * 2;
			}
			else if(backgroundLayers [i].backgrounds [1].transform.position.x <= -backgroundLayers [i].background.bounds.max.x ) {
				backgroundLayers [i].backgrounds [1].transform.position = Vector3.right * backgroundLayers [i].background.bounds.max.x * 2;
			}

			for (int j = 0; j < backgroundLayers [i].backgrounds.Length; j++) {
				backgroundLayers [i].backgrounds [j].transform.position += Vector3.left * backgroundLayers [i].speed;
			}
		}
	}

	void Start(){
		Initialize ();
		SetPosition ();
	}

	void FixedUpdate(){
		Move ();
	}

	[System.Serializable]
	public class BackgroundLayer{
		public Sprite background;
		public GameObject[] backgrounds;
		public float speed;
	}
}

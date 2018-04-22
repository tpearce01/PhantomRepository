using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbWall : Interactable {
	GameObject player;
	GameObject companion;

	public MovementPoint[] points;

	public Collider wallCollider;

	bool triggered = false;

	public override void TriggerEvent(){
		player = Player.instance.gameObject;
		companion = GameObject.FindGameObjectWithTag ("Companion");

		Debug.Log ("Triggered");
		if (!triggered) {
			Player.instance.DisableMovement ();
			companion.GetComponent<CompanionMovement> ().enabled = false;
			StartCoroutine (Move ());
			triggered = true;
		}
	}

	//Fixed update = 0.01s
	//Time to destination = 4s
	public IEnumerator Move(){
		wallCollider.enabled = false;
		for (int i = 0; i < points.Length; i++) {
			Vector3 startLocation = player.transform.position;
			while (Mathf.Abs(Vector2.Distance ((Vector2)player.transform.position, points [i].destination)) > 0.1f) {
				player.transform.position = Vector3.MoveTowards (player.transform.position, new Vector3(points [i].destination.x, points [i].destination.y, player.transform.position.z), 0.01f * points[i].speed);
				yield return new WaitForFixedUpdate ();
			}
		}
		wallCollider.enabled = true;
		Player.instance.EnableMovement ();
		Debug.Log ("Done");

		PlayerEventTrigger.instance.DeactivateTrigger ();
		triggered = false;
	}

	[System.Serializable]
	public class MovementPoint{
		public Vector2 destination;
		public float speed;
	}
}

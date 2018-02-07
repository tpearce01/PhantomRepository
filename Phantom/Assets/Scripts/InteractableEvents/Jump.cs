using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Interactable {

	public Vector3 destination;
	GameObject targetObj;
	[SerializeField] float initialAngle;
	bool hasJumped = false;

	public override void TriggerEvent(){
		targetObj = Player.instance.gameObject;
		JumpAction ();
	}

	void Update(){
		if (targetObj != null && targetObj.GetComponent<Rigidbody>().velocity == Vector3.zero) {
			EndJump ();
		}
	}

	void JumpAction(){
		Player.instance.DeactivateAgent ();
		Rigidbody rigid = Player.instance.gameObject.GetComponent<Rigidbody>();

		float gravity = 10.0f;
		float yOffset = targetObj.transform.position.y - destination.y + 1.25f;

		float distance = Mathf.Abs(targetObj.transform.position.x - destination.x);

		float xForce;
		float yForce;


		float initialVelocity = (1 / Mathf.Cos(initialAngle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(initialAngle) + yOffset));

		Vector3 velocity = new Vector3(initialVelocity * Mathf.Cos(initialAngle), initialVelocity * Mathf.Sin(initialAngle), 0);

		rigid.AddForce(velocity * rigid.mass, ForceMode.Impulse);
		hasJumped = true;
	}

	void EndJump(){
		Debug.Log ("End Jump");
		Player.instance.ActivateAgent ();
	}
}

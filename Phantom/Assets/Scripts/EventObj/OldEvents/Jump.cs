using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Interactable {

	public Vector3 destination;
	GameObject targetObj;
	[SerializeField] float initialAngle;
	//bool jumpThisFrame = false;
    int jumpTriggeredThisFrame = 0;
    bool falling = false;
    bool rising = false;

	public override void TriggerEvent(){
		targetObj = Player.instance.gameObject;
        Player.instance.DeactivateAgent();
        jumpTriggeredThisFrame = 1;
	}

	void FixedUpdate(){
        if (!rising && targetObj != null && targetObj.GetComponent<Rigidbody>().velocity.y > 0) {
            rising = true;
        }
        else if (rising && !falling && targetObj != null && targetObj.GetComponent<Rigidbody>().velocity.y < 0) {
            falling = true;
        }
        else if (targetObj != null && targetObj.GetComponent<Rigidbody>().velocity == Vector3.zero) {
            falling = false;
            rising = false;
            EndJump();
        }

        if (jumpTriggeredThisFrame == 1) {
            jumpTriggeredThisFrame = 2;
        }
        else if (jumpTriggeredThisFrame == 2 && rising == false && falling == false) {
            jumpTriggeredThisFrame = 0;
            JumpAction();
        }
	}

	void JumpAction(){
		
		Rigidbody rigid = Player.instance.gameObject.GetComponent<Rigidbody>();

		float gravity = 10.0f;
		float yOffset = targetObj.transform.position.y - destination.y + 1.25f;

		float distance = Mathf.Abs(targetObj.transform.position.x - destination.x);


		float initialVelocity = (1 / Mathf.Cos(initialAngle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(initialAngle) + yOffset));

		Vector3 velocity = new Vector3(initialVelocity * Mathf.Cos(initialAngle), initialVelocity * Mathf.Sin(initialAngle), 0);

		rigid.AddForce(velocity * rigid.mass, ForceMode.Impulse);
        //jumpThisFrame = true;
	}

	void EndJump(){
		Debug.Log ("End Jump");
        //Player.instance.ActivateAgent ();
        //targetObj = null;
	}
}

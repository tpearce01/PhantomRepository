using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour {
    [SerializeField] NavMeshAgent agent;
    int zLocation = 2;

	[SerializeField] float walkSpeed;
	[SerializeField] float runSpeed;
	[SerializeField] float runDistance;

	//Navigate on mouse click
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Navigate();
			SetSpeed ();
        }
	}

	//Set destination based on mouse location
    void Navigate() {
        agent.SetDestination(GetMouseLocation());
    }

	//Get mouse location in world space
    Vector3 GetMouseLocation() {
        Vector3 pos = Input.mousePosition;
        pos.z = 10.0f;
        pos = Camera.main.ScreenToWorldPoint(pos);
        return pos;
    }

	void SetSpeed(){
		if (agent.remainingDistance > runDistance) {
			agent.speed = runSpeed;
		} else {
			agent.speed = walkSpeed;
		}
	}
}

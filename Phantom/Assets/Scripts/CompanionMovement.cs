using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompanionMovement : MonoBehaviour {

	[SerializeField] NavMeshAgent agent;
	int zLocation = 2;

	[SerializeField] float walkSpeed;
	[SerializeField] float runSpeed;
	[SerializeField] float runDistance;

	[SerializeField] GameObject target;

	void OnEnable(){
		agent.stoppingDistance = 2;
		agent.SetDestination (agent.gameObject.transform.position);
	}

	void OnDisable(){
		agent.stoppingDistance = 0;
	}

	//Navigate on mouse click
	void FixedUpdate () {
		Navigate();
		SetSpeed ();
	}

	//Set destination based on mouse location
	void Navigate() {
		agent.SetDestination(target.transform.position);
		this.gameObject.GetComponent<NavMeshAgent>().destination = agent.destination;
	}

	//Set movement speed based on distance to destination
	void SetSpeed(){
		if (Mathf.Abs(agent.destination.x - gameObject.transform.position.x) > runDistance) {
			agent.speed = runSpeed;
		} else {
			agent.speed = walkSpeed;
		}
	}
}

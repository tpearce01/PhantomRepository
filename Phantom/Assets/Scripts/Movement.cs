using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour {
    [SerializeField] NavMeshAgent agent;
    //int zLocation = 2;

	[SerializeField] float walkSpeed;
	[SerializeField] float runSpeed;
	[SerializeField] float runDistance;

	void OnEnable(){
		agent.stoppingDistance = 0;
		agent.SetDestination (agent.gameObject.transform.position);
	}

	void OnDisable(){
		agent.stoppingDistance = 2;
	}

	//Navigate on mouse click
	void FixedUpdate () {
        if (/*agent.isActiveAndEnabled && */Input.GetKeyDown(KeyCode.Mouse0)) {
            Navigate();
			SetSpeed ();
			PlayerEventTrigger.instance.DeactivateTrigger ();

        }
		this.gameObject.GetComponent<NavMeshAgent>().destination = agent.destination;
	}

	//Set destination based on mouse location
    void Navigate() {
        agent.SetDestination(GetMouseLocation());
		Debug.Log("Active player destination: " + agent.destination);
    }

	//Get mouse location in world space
    Vector3 GetMouseLocation() {
        Vector3 pos = Input.mousePosition;
        pos.z = 10.0f;
        pos = Camera.main.ScreenToWorldPoint(pos);
        return pos;
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

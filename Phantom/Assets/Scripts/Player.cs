using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {
	public static Player instance;
    public static string targetEvent = "";
	NavMeshAgent agent;

	void OnEnable(){
		instance = this;
		agent = gameObject.GetComponent<NavMeshAgent> ();
	}

	public void DeactivateAgent(){
		agent.enabled = false;
	}

	public void ActivateAgent(){
		agent.enabled = true;
	}

	public void DisableMovement(){
		gameObject.GetComponent<NavMeshAgent> ().enabled = false;
		gameObject.GetComponent<Movement> ().enabled = false;
		gameObject.GetComponent<Rigidbody> ().useGravity = false;
	}

	public void EnableMovement(){
		gameObject.GetComponent<NavMeshAgent> ().enabled = true;
		gameObject.GetComponent<Movement> ().enabled = true;
		gameObject.GetComponent<Rigidbody> ().useGravity = true;
	}
}

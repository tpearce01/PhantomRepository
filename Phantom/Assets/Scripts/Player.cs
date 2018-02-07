using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {
	public static Player instance;
	NavMeshAgent agent;

	void Awake(){
		instance = this;
		agent = gameObject.GetComponent<NavMeshAgent> ();
	}

	public void DeactivateAgent(){
		agent.enabled = false;
	}

	public void ActivateAgent(){
		agent.enabled = true;
	}
}

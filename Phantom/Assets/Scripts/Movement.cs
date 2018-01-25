using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour {
    [SerializeField]
    NavMeshAgent agent;
    int zLocation = 2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Navigate();
        }
	}

    void Navigate() {
        agent.SetDestination(GetMouseLocation());
    }

    Vector3 GetMouseLocation() {
        Vector3 pos = Input.mousePosition;
        pos.z = 10.0f;
        pos = Camera.main.ScreenToWorldPoint(pos);
        Debug.Log("Mouse position: " + pos);
        return pos;
    }
}

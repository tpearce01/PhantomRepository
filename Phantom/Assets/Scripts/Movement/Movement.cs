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

    Animator animator;
    SpriteRenderer sprite;
    readonly float walkingVelocity = 0.1f;

	void OnEnable(){
        // Navigation
		gameObject.GetComponent<NavMeshAgent>().stoppingDistance = 0;
		agent.stoppingDistance = 0;
		agent.SetDestination (agent.gameObject.transform.position);

        // Animation
        animator = gameObject.GetComponentInChildren<Animator>();
        if(animator != null){
            sprite = animator.gameObject.GetComponent<SpriteRenderer>();
        }
	}

	//Navigate on mouse click
	void FixedUpdate () {
        if (/*agent.isActiveAndEnabled && */Input.GetKeyDown(KeyCode.Mouse0)) {
            Navigate();
			SetSpeed ();
			PlayerEventTrigger.instance.DeactivateTrigger ();

        }
		this.gameObject.GetComponent<NavMeshAgent>().destination = agent.destination;
        SetAnimation();
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

	//Set movement speed based on distance to destination
	void SetSpeed(){
		if (Mathf.Abs(agent.destination.x - gameObject.transform.position.x) > runDistance) {
			agent.speed = runSpeed;
		} else {
			agent.speed = walkSpeed;
		}
	}

    // Set the animation based on the current velocity
    void SetAnimation(){
        if(animator != null){
            if(Mathf.Abs(agent.velocity.magnitude) <= walkingVelocity){
                animator.SetBool("Walking", false);
            }
            else{
                animator.SetBool("Walking", true);
                if(agent.velocity.x > 0){
                    //walkright
                    sprite.flipX = false;
                }
                else{
                    //walkleft
                    sprite.flipX = true;
                }
            }
        }

    }
}

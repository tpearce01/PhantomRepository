using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompanionMovement : MonoBehaviour {

	[SerializeField] NavMeshAgent agent;
	//int zLocation = 2;

	[SerializeField] float walkSpeed;
	[SerializeField] float runSpeed;
	[SerializeField] float runDistance;

	[SerializeField] GameObject target;

    Animator animator;
    SpriteRenderer sprite;
    readonly float walkingVelocity = 0.1f;

	void OnEnable(){
        // Navigation
		gameObject.GetComponent<NavMeshAgent> ().stoppingDistance = 2;
		agent.stoppingDistance = 2;
		agent.SetDestination (agent.gameObject.transform.position);

        // Animation
        animator = gameObject.GetComponentInChildren<Animator>();
        if (animator != null)
        {
            sprite = animator.gameObject.GetComponent<SpriteRenderer>();
        }
	}

	//Navigate on mouse click
	void FixedUpdate () {
		Navigate();
		SetSpeed ();
        SetAnimation();
	}

	//Set destination based on mouse location
	void Navigate() {
		agent.SetDestination(target.transform.position);
		this.gameObject.GetComponent<NavMeshAgent>().destination = agent.destination;
	}

	//Set movement speed based on distance to destination
	void SetSpeed(){
		agent.speed = Player.instance.gameObject.GetComponent<NavMeshAgent> ().speed;
	}

    // Set the animation based on the current velocity
    void SetAnimation()
    {
        if (animator != null)
        {
            if (Mathf.Abs(agent.velocity.magnitude) <= walkingVelocity)
            {
                animator.SetBool("Walking", false);
            }
            else
            {
                
                animator.SetBool("Walking", true);
                if (agent.velocity.x > 0)
                {
                    //walkright
                    sprite.flipX = false;
                }
                else
                {
                    //walkleft
                    sprite.flipX = true;
                }
            }
        }

    }
}

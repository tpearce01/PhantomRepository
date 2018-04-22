using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    MoveObjectEvent
    
    Purpose:
        Move an object
     */
public class MoveObjectEvent : Event {
    public string TargetObjectName;                     // Name of the object to move
    GameObject TargetObject;                            // Object to move toward the destinations
    float safeDistance = 0.1f;                          // Distance to destination that behaves as having arrived at the destination
    public MoveObjectEventParameters[] arrDestinations; // Array of positions to navigate to

    public override IEnumerator TriggerEvent() {
        
        TargetObject = GameObject.Find(TargetObjectName);   // Find the target object based on name. Inefficient, but it's easy to implement

        // If target is Player, disable player movement
        if (TargetObject.CompareTag("Player")) {
            Player.instance.DisableMovement();
            yield return new WaitForFixedUpdate();
        }

        //Move object(s)
        for (int i = 0; i < arrDestinations.Length; i++) {
            long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            // Continue moving closer until object is within acceptable distance of the target destination
            float callsPerSec = 1 / Time.fixedDeltaTime;
            float distanceDelta = (2 / arrDestinations[i].duration) / callsPerSec;
            Debug.Log("Delta: " + distanceDelta);
            while (Mathf.Abs(Vector2.Distance(TargetObject.transform.position, arrDestinations[i].TargetDestination)) > safeDistance) {
                // Maintain TargetObject original z position to prevent background objects moving to the foreground
                TargetObject.transform.position = Vector3.MoveTowards(TargetObject.transform.position, new Vector3(arrDestinations[i].TargetDestination.x, arrDestinations[i].TargetDestination.y, TargetObject.transform.position.z), distanceDelta); 
                yield return new WaitForFixedUpdate();
            }
            long end = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long totalTime = end - start;
            Debug.Log("Time: " + totalTime);
        }

        // If target is Player, re-enable movement
        if (TargetObject.CompareTag("Player")) {
            Player.instance.EnableMovement();
        }
    }
	
}

[System.Serializable]
public class MoveObjectEventParameters {
    public Vector2 TargetDestination;   // Position of destination
    public float duration;              // Time of movement
}

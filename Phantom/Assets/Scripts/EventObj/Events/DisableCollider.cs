using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    DisableCollider

    Purpose:
        Disable collision between two objects
     */
public class DisableCollider : Event {
   public override IEnumerator TriggerEvent() {
        GameObject Collider = GameObject.FindGameObjectWithTag("ColliderOpening");
        GameObject player = GameObject.Find("Player");
        Physics.IgnoreCollision(Collider.GetComponent<Collider>(), player.GetComponent<Collider>());
        yield return new WaitForFixedUpdate();
   }

}

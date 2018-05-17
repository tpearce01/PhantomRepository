using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ShowCharacter

    Purpose:
        Reveal a previously invisible character
     */

public class ShowCharacter : Event {
		public override IEnumerator TriggerEvent() {
				GameObject.Find("Companion2").transform.localScale = new Vector3(1, 1, 1);
				GameObject.Find("Companion2").GetComponent<Rigidbody>().useGravity = true;
				GameObject.Find("Companion2").GetComponent<CompanionMovement>().enabled = true;
				yield return new WaitForFixedUpdate();

	}
}

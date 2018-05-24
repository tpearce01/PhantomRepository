using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ShowCharacter (OneTimeEvent)

    Purpose:
        Reveal a previously invisible character
				(Currently only works for Veronica)
     */

public class ShowCharacter : OneTimeEvent {
		protected override void Start() {
				base.Start();
		}
		public override IEnumerator TriggerEvent() {
				DeactivateTrigger();
				//switches isVeronicaAdded(located in GameManager) to true so she can be activated by GameManager for other scenes
				GameManager.isVeronicaAdded = true;
				//------------------------------------------------------------
				GameObject.Find("Veronica").transform.localScale = new Vector3(1, 1, 1);
				GameObject.Find("Veronica").GetComponent<Rigidbody>().useGravity = true;
				GameObject.Find("Veronica").GetComponent<CompanionMovement>().enabled = true;
				yield return new WaitForFixedUpdate();

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ActivateDialogue

    Purpose:
        Activate previously unactivated dialogue(Timed Dialogue Script)
     */
public class ActivateDialogue : Event {
		public override IEnumerator TriggerEvent() {
				GameObject.Find("Panel").GetComponent<TimedDialogue>().enabled = true;
				yield return new WaitForFixedUpdate();
		}
}

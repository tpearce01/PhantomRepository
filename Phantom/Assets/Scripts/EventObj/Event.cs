using System.Collections;
using UnityEngine;

/*
    Event class. Requires implementation of TriggerEvent so EventManager can properly
    fire events.
     */
public abstract class Event : MonoBehaviour{
    public abstract IEnumerator TriggerEvent();

    // Helper Functions
    protected void DeactivateEventTrigger() {
        GameObject trigger = gameObject.transform.Find("Trigger").gameObject;
        trigger.GetComponent<SpriteRenderer>().enabled = false;
        trigger.GetComponent<CircleCollider2D>().enabled = false;
    }
}

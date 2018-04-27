using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OneTimeEvent : Event {
    public string eventID;  // Event Identifier - Used by SaveData to determine which events to load

    // If this event has already been completed, destroy it on load
    protected virtual void Start() {
        if (SaveData.oneTimeEventsCompleted.Contains(eventID)) {
            //Destroy(gameObject);
            DeactivateTrigger();
        }
    }

    // Must be manually called to notify the save system once the event has been completed
    protected void Completed() {
        SaveData.oneTimeEventsCompleted.Add(eventID);
        SaveData.Save();
    }

    // Effectively disables this event. EventTriggerObject needs to remain active to fade out EventTitleText, so trigger components
    //  are disabled individually.
    protected void DeactivateTrigger() {
        gameObject.transform.Find("Sprite").gameObject.SetActive(false);
        DeactivateEventTrigger();
    }
}

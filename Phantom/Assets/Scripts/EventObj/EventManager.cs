using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/*
    Give this any number of events, and it will call them in order
     */
public class EventManager : MonoBehaviour {
    public Event[] eventToTrigger;

    public void TriggerEvent() {
        foreach (Event e in eventToTrigger) {
            StartCoroutine(e.TriggerEvent());
        }
    }
	
}

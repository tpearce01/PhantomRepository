using System.Collections;
using UnityEngine;

/*
    Event class. Requires implementation of TriggerEvent so EventManager can properly
    fire events.
     */
public abstract class Event : MonoBehaviour{
    public abstract IEnumerator TriggerEvent();
}

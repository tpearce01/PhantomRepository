using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor_old : Interactable {
    [SerializeField]
    GameObject doorObj;

    public override void TriggerEvent() {
        base.TriggerEvent();
        doorObj.SetActive(false);
        gameObject.SetActive(false);
    }

}

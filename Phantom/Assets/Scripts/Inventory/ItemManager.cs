using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    // In order to allow for re-usable items, I do not remove the item from the inventory here. If
    //  the item is consumed, that needs to happen as part of its event.
    public void UseItem(Item i) {
        StartCoroutine(i.TriggerEvent());
    }
}

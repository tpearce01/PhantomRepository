using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleKeyItem : Item {
    void Awake() {
        itemName = "Rusted Key";
        Texture2D tex = Resources.Load<Texture2D>("RustedKey");
        image = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
    }

    public override IEnumerator TriggerEvent() {
        // Event Code Goes Here
        //InventoryUIManager.instance.RemoveItem(itemName); // TESTING ONLY - Actually want to keep the key so the door can be used again
        yield break;
    }
}

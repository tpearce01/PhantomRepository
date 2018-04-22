using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : OneTimeEvent {
    public Item item;   // Item to add to inventory
    Text popup;         // Text to display "Acquired"
    Fade fade;          // Use this to fade text in / out

    // One time events must use the base Start() function of OneTimeEvent to prevent completed events from loading
    protected override void Start() {
        base.Start();
        popup = transform.Find("TextCanvas").Find("GetItemText").GetComponent<Text>();
        popup.color = new Color(popup.color.r, popup.color.g, popup.color.b, 0);
    }

    //One time events must 
    //  1) Call DeactivateTrigger() to immediately disable the event
    //  2) Call Completed() to notify the save system that the event should not be re-loaded
    public override IEnumerator TriggerEvent() {
        DeactivateTrigger();    // Required
        if (item)
            Inventory.AddItem(item);
        popup.text = "Acquired [" + item.itemName + "].";
        RectTransform rt = popup.gameObject.GetComponent<RectTransform>();
        rt.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 10));
        fade = Fade.CreateFade(gameObject);
        fade.FadeInText(popup);
        yield return new WaitForSeconds(3);
        fade.FadeOutText(popup);

        Completed();    // Required
        yield break;
    }
}

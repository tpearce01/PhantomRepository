using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Event {
    public string KeyName;  // Key required to open the door

    public override IEnumerator TriggerEvent() {
        if (Inventory.Contains(KeyName)) {
            // Deactivate Trigger
            DeactivateEventTrigger();

            // Open the door
            Fade fade = Fade.CreateFade(gameObject);
            GameObject sprite = gameObject.transform.Find("Sprite").gameObject;
            fade.FadeOutSprite(sprite.GetComponent<SpriteRenderer>(), 2);
            yield return new WaitForSeconds(1);

            //Destroy the nav obstacle
            Destroy(sprite.transform.Find("NavObstacle").gameObject);

            yield break;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.WaitForSeconds;
// MAKE SURE TO FIX DIALOGUE WHEN PLAYER GETS ITEM
public class HauntedHouseSecurityRoomKey : Item
{
    public GameObject myObject;

    void Awake()
    {
        itemName = "HauntedHouseSecurityRoomKey";
        Texture2D tex = Resources.Load<Texture2D>("HauntedHouseSecurityRoomKey");
        image = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
    }

    public override IEnumerator TriggerEvent()
    {
        yield break;
    }
}

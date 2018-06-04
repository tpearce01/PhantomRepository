using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wine : Item
{
    void Awake()
    {
        itemName = "Wine";
        Texture2D tex = Resources.Load<Texture2D>("Wine");
        image = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
    }

    public override IEnumerator TriggerEvent()
    {
        // Event Code Goes Here
        yield break;
    }
}

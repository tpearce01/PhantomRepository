using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalEntry2 : Item
{
    void Awake()
    {
        itemName = "JournalEntry2";
        Texture2D tex = Resources.Load<Texture2D>("JournalEntry2");
        image = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
    }

    public override IEnumerator TriggerEvent()
    {
        // Event Code Goes Here
        yield break;
    }
}

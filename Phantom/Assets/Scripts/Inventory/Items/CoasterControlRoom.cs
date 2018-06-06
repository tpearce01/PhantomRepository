using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoasterControlRoom : Item
{ 
    void Awake()
    {
        itemName = "CoasterControlRoom";
        Texture2D tex = Resources.Load<Texture2D>("CoasterControlRoom");
        image = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
    }

    public override IEnumerator TriggerEvent(){
 
        yield break; // Event Code Goes Here
    }
}
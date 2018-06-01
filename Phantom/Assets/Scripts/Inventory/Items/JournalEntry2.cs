using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.WaitForSeconds;
// MAKE SURE TO FIX DIALOGUE WHEN PLAYER GETS ITEM
public class JournalEntry2 : Item
{
    public GameObject myObject;

    void Awake()
    {
        itemName = "JournalEntry2";
        Texture2D tex = Resources.Load<Texture2D>("JournalEntry2");
        image = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
    }

    public override IEnumerator TriggerEvent()
    {
        //StartCoroutine(TimePassage());
        //myObject.SetActive(true);
        yield break;
    }
    //IEnumerator TimePassage()
    //{
    //    myObject.SetActive(true); // Event Code Goes Here
    //                              //yield return new WaitForSeconds(5);
    //                              // myObject.SetActive(false);
    //    yield break;
    //}

}

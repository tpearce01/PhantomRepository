using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Item class
    VERY IMPORTANT - When creating a new item, you must do the following steps to ensure it loads properly:
        1) Implement the following method in your item class, which is run when the item is used: 
                public override IEnumerator TriggerEvent() { ... }
        2) Import your item's image into the Resources folder in Unity. Give it a relevant and simple name.
        2) In your item class, create an "Awake" method to initialize the default values:
            void Awake() {
                itemName = "Your Item Name";
                Texture2D tex = Resources.Load<Texture2D>("YourImageName");
                image = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
            }
        3) Create a switch statement case in Inventory.cs method SetInventory(...) as demonstrated below:
            case "Your Item Name":
                YourItemClass newItem = InventoryUIManager.instance.gameObject.AddComponent<YourItemClass>();
                items.Add(newItem);
                break;

    Use SampleKeyItem as a basic example if you are unsure what to do here. If you have any questions, ask
    Tyler for help.
     */
public abstract class Item : Event {
    public string itemName { get; set; }             // Name of the item
    public Sprite image { get; set; }                // Item sprite

    /// <summary>
    /// UseItem does not implicitly remove the item from InventoryUI. This needs to be done manually as part of UseItem, if 
    ///     the item is consumed on use.
    /// </summary>
    public void UseItem() {
        StartCoroutine(TriggerEvent());
    }
}

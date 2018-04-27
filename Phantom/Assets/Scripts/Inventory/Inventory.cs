using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory {
    static ItemManager itemManager;
    static List<Item> items = new List<Item>();

    /// <summary>
    /// Get current inventory
    /// </summary>
    /// <returns></returns>
    public static List<Item> GetInventory() {
        return items;
    }
    public static string[] GetInventoryString() {
        List<string> toReturn = new List<string>();
        foreach (Item i in items) {
            toReturn.Add(i.itemName);
        }
        return toReturn.ToArray();
    }

    /// <summary>
    /// Load data to inventory
    /// </summary>
    /// <param name="data"></param>
    public static void SetInventory(string[] data) {
        foreach (string d in data) {
            switch (d) {
                case "Rusted Key":
                    SampleKeyItem newItem = InventoryUIManager.instance.gameObject.AddComponent<SampleKeyItem>();
                    items.Add(newItem);
                    break;
                default:
                    Debug.Log("Failed to set Inventory Item during Load");
                    break;
            }
        }
    }

    /// <summary>
    /// Add an item to the player's inventory and Inventory UI
    /// </summary>
    /// <param name="i"></param>
    public static void AddItem(Item i) {
        items.Add(i);
        InventoryUIManager.instance.AddItem(i);
    }

    /// <summary>
    /// Checks if the player owns a specific item
    /// </summary>
    /// <param name="itemName"></param>
    /// <returns></returns>
    public static bool Contains(string itemName) {
        foreach (Item i in items) {
            if (i.itemName == itemName) {
                return true;
            }
        }

        return false;
    }

    public static void UseItem(string itemName) {
        foreach (Item i in items) {
            if (i.itemName == itemName) {
                i.UseItem();
            }
        }
    }
}



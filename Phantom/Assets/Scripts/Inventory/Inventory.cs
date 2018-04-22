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

    /// <summary>
    /// Load data to inventory
    /// </summary>
    /// <param name="data"></param>
    public static void SetInventory(List<Item> data) {
        items = data;
    }

    /// <summary>
    /// Add an item to the player's inventory
    /// </summary>
    /// <param name="i"></param>
    public static void AddItem(Item i) {
        items.Add(i);
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
}



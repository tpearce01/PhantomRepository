using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour{
	public static ItemInfo instance;
	public Item[] masterItemList;

	void Awake(){
		instance = this;
	}

    void Start() {
        //TESTING ONLY - Adds all existing items to the player's inventory
        for (int i = 0; i < masterItemList.Length-2; i++) {
            //PlayerInventory.AddItem(masterItemList[i]);
        }
    }

    public Item GetItem(string name) {
        for (int i = 0; i < masterItemList.Length; i++) {
            if (name == masterItemList[i].name) {
                return masterItemList[i];
            }
        }
        return null;
    }
}

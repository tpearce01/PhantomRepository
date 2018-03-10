using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour{
	public static ItemInfo instance;
	public Item[] masterItemList;

	void Awake(){
		instance = this;
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

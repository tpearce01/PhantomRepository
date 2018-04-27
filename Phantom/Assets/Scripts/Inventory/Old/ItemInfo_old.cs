using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo_old : MonoBehaviour{
	public static ItemInfo_old instance;
	public Item_old[] masterItemList;

	void Awake(){
		instance = this;
	}

    public Item_old GetItem(string name) {
        for (int i = 0; i < masterItemList.Length; i++) {
            if (name == masterItemList[i].name) {
                return masterItemList[i];
            }
        }
        return null;
    }
}

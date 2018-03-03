using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour{
	public static ItemInfo instance;
	public Item[] masterItemList;

	void Awake(){
		instance = this;
	}
}

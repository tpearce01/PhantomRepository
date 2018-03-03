using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	[SerializeField] GameObject inventoryPanel;
	[SerializeField] GameObject itemPrefab;
	[SerializeField] GameObject gridLayout;

	// Use this for initialization
	void Start () {
		//TESTING ONLY - This adds all existing items to the player's inventory
		for (int i = 0; i < ItemInfo.instance.masterItemList.Length; i++) {
			AddItemToInventory (ItemInfo.instance.masterItemList [i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.I)){
			OpenInventory();
		}
	}

	void OpenInventory(){
		inventoryPanel.SetActive (true);
		StartCoroutine (Enlarge ());
	}

	IEnumerator Enlarge(){
		RectTransform rt = inventoryPanel.GetComponent<RectTransform> ();
		rt.localScale = new Vector3 (0, 0, 0);
		for (int i = 0; i < 25; i++) {
			rt.transform.localScale = new Vector3 (rt.localScale.x + .03f, rt.localScale.y + .03f, rt.localScale.z + .03f);
			yield return new WaitForSeconds (.01f);
		}
	}

	void AddItemToInventory(Item i){
		GameObject tempObj = Instantiate (itemPrefab, gridLayout.transform) as GameObject;
		tempObj.GetComponentsInChildren<Image> ()[1].sprite = i.image;
		tempObj.GetComponentInChildren<Text> ().text = i.name;
	}
}

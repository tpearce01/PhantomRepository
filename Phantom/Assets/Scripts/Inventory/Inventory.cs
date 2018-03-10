using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	[SerializeField] GameObject inventoryPanel;
	[SerializeField] GameObject itemPrefab;
	[SerializeField] GameObject gridLayout;
    [SerializeField] GameObject selector;

    void Awake() {
        
    }

	// Use this for initialization
	void Start () {
		PlayerInventory.LoadInventory();
        SetInventory();
	}

    void SetInventory() {
        for (int i = 0; i < PlayerInventory.items.Count; i++){
            AddItemToInventory(PlayerInventory.items[i]);
        }
    }

    void ClearInventory() {
        Image[] list = gridLayout.GetComponentsInChildren<Image>();
        for (int i = 0; i < list.Length; i++) {
            Destroy(list[i].gameObject);
        }
    }

	void AddItemToInventory(Item i){
		GameObject tempObj = Instantiate (itemPrefab, gridLayout.transform) as GameObject;
		tempObj.GetComponent<Image> ().sprite = i.image;
		//tempObj.GetComponentInChildren<Text> ().text = i.name;
	}

    void UseItem(int i) {
        Image[] list = gridLayout.GetComponentsInChildren<Image>();
        if (list.Length > i) {
            Destroy(list[i].gameObject);
        }
        PlayerInventory.UseItem(i);
    }

    void SelectItem(int i) {
        Image[] list = gridLayout.GetComponentsInChildren<Image>();
        if (list.Length > i) {
            Instantiate(selector);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            UseItem(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            UseItem(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            UseItem(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            UseItem(4);
        }
    }

    void OnDestroy() {
        PlayerInventory.SaveInventory();
    }
}



/*
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
    */

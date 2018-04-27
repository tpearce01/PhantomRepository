using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour {
    public static InventoryUIManager instance;
    public GameObject uiItemPrefab;
    Fade fade;

    // TESTING ONLY
    /*void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            SampleKeyItem temp = new SampleKeyItem();
            temp.itemName = "Test Item";
            AddItem(temp);
        }
    }*/

    // Only one instance of this should exist to prevent duplicating items to the UI
    void Awake() {
        if (instance == null) {
            instance = this;
            fade = Fade.CreateFade(gameObject);
            SaveData.Load();
        }
        else {
            Destroy(this);
        }
    }

    // Initialize the UI from inventory
    void Start() {
        InitializeItems();
    }

    // Adds all items from the inventory to the UI. This should only be called once per scene to prevent duplicates
    void InitializeItems() {
        foreach (Item i in Inventory.GetInventory()) {
            AddItem(i);
        }
    }

    // Adds an item to the UI
    public void AddItem(Item i) {
        GameObject newItem = Instantiate(uiItemPrefab, transform.Find("BackgroundPanel").Find("ItemSlotPanel"));
        newItem.GetComponent<InventoryUIItem>().itemName = i.itemName;
        newItem.transform.Find("ItemNameText").gameObject.GetComponent<Text>().text = i.itemName;
        Image im = newItem.GetComponent<Image>();
        im.sprite = i.image;
        im.color = new Color(im.color.r, im.color.g, im.color.b, 0);
        fade.FadeInImage(im, 1);
    }

    // Removes an item from the UI
    public void RemoveItem(string a_itemName) {
        StartCoroutine(RemoveItemCR(a_itemName));
    }

    // Coroutine to Remove an item from the UI
    public IEnumerator RemoveItemCR(string a_itemName) {
        InventoryUIItem[] items = transform.Find("BackgroundPanel").Find("ItemSlotPanel").GetComponentsInChildren<InventoryUIItem>();

        foreach (InventoryUIItem i in items) {
            if (i.itemName == a_itemName) {
                float fadeDuration = 1f;
                // Fade out image
                fade.FadeOutImage(i.gameObject.GetComponent<Image>(), fadeDuration);
                yield return new WaitForSeconds(fadeDuration);

                // Shrink image width so inventory bar smoothly collapses
                StartCoroutine(ShrinkWidthCR(i.gameObject.GetComponent<RectTransform>(), fadeDuration));
                yield return new WaitForSeconds(fadeDuration);

                //Destroy the removed item
                Destroy(i.gameObject);
                break;
            }
        }

        yield break;
    }

    // Coroutine to shrink the width of a RectTransform to 0
    public IEnumerator ShrinkWidthCR(RectTransform rt, float a_duration) {
        float callsPerSec = 1 / Time.fixedDeltaTime;
        float reductionSize = rt.sizeDelta.x / (a_duration * callsPerSec);
        while (rt.sizeDelta.x > 0) {
            rt.sizeDelta = new Vector2(rt.sizeDelta.x - reductionSize, rt.sizeDelta.y);
            yield return new WaitForFixedUpdate();
        }
    }
}

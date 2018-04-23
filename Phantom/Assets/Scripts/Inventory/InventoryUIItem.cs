using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler {
    public string itemName { get; set; }
    Fade fade;
    Text itemNameText;

    void Awake() {
        fade = Fade.CreateFade(gameObject, 0.5f);
        itemNameText = gameObject.transform.Find("ItemNameText").gameObject.GetComponent<Text>();
        itemNameText.color = new Color(itemNameText.color.r, itemNameText.color.g, itemNameText.color.b, 0);
    }

    // On Mouseover
    public void OnPointerEnter(PointerEventData eventData) {
        // Show Text
        fade.FadeInText(itemNameText);
    }

    // On Mouse exit
    public void OnPointerExit(PointerEventData eventData) {
        // Hide Text
        fade.FadeOutText(itemNameText);
    }

    // On Mouse Click
    public void OnPointerDown(PointerEventData eventData) {
        // Use item
        Inventory.UseItem(itemName);
    }
}

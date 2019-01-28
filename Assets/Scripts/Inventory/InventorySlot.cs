using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    [SerializeField]
    Image icon;

    [SerializeField]
    Button removeButton;

    Item item;

    public void AddItemToSlot(Item item) {
        this.item = item;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void RemoveItemFromSlot() {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton() {
        Inventory.instance.RemoveFromInventory(item);
    }

    public void UseItem() {
        if (item != null) {
            item.UseItem();
        }
    }
}

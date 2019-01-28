using UnityEngine;

public class InventoryUI : MonoBehaviour {

    [SerializeField]
    GameObject inventoryUI;

    [SerializeField]
    Transform itemContainer;

    Inventory inventory;

    InventorySlot[] itemSlots;


    void Start() {
        inventory = Inventory.instance;
        inventory.onInventoryChangedCallback += UpdateUI;

        itemSlots = itemContainer.GetComponentsInChildren<InventorySlot>();
    }

    void Update() {
        if (Input.GetButtonDown("Inventory")) {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI() {
        for (int i = 0; i < itemSlots.Length; i++) {
            if (i < inventory.items.Count) {
                itemSlots[i].AddItemToSlot(inventory.items[i]);
            } else {
                itemSlots[i].RemoveItemFromSlot();
            }
        }
    }

}

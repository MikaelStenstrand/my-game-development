using UnityEngine;

public class ItemPickup : Interactable	{

    public Item item;

    public override void Interact() {
        base.Interact();
        PickUpItem();
    }

    private void Awake() {
        if (item == null) {
            Debug.Log("Add Item reference to this ItemPickable");
        }
    }

    void PickUpItem() {
        Debug.Log("picking up item called: " + item.name);

        bool wasPickedUp = Inventory.instance.AddToInventory(item);

        if (wasPickedUp) {
            Destroy(gameObject);
        }
    }
}

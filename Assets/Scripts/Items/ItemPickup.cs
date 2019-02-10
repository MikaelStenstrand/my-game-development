using UnityEngine;

public class ItemPickup : Interactable	{

    public Item item;

    public override bool Interact() {
        return PickUpItem();
    }

    private void Awake() {
        if (item == null) {
            Debug.Log("Add Item reference to this ItemPickable");
        }
    }

    bool PickUpItem() {
        Debug.Log("picking up item called: " + item.name);

        bool wasPickedUp = Inventory.instance.AddToInventory(item);

        if (wasPickedUp) {
            base.WasInteracted();
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}

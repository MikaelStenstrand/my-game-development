using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour	{

    #region Singelton
    public static Inventory instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Debug.LogWarning("More than one instance of Inventory exists!");
            return;
        }
    }

    #endregion

    public int inventorySpace = 5;
    public List<Item> items = new List<Item>();

    public delegate void OnInventoryChanged();
    public OnInventoryChanged onInventoryChangedCallback;

    public bool AddToInventory(Item item) {
        if (inventorySpace <= items.Count) {
            Debug.Log("no more space in inventory");
            return false;
        }
        items.Add(item);

        if (onInventoryChangedCallback != null)
            onInventoryChangedCallback.Invoke();

        return true;
    }

    
    public void RemoveFromInventory(Item item) {
        items.Remove(item);
        if (onInventoryChangedCallback != null)
            onInventoryChangedCallback.Invoke();
    }

}

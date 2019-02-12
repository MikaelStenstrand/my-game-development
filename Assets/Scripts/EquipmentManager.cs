using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour	{

    #region Singleton

    public static EquipmentManager instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Debug.Log("duplicate instances of EquipmentManager");
            return;
        }
    }

    #endregion

    Equipment[] currentEquipment;

    Inventory inventory;

    public delegate void OnEquipmentChanged(Equipment newEquipment, Equipment oldEquipment);
    public OnEquipmentChanged onEquipmentChangedCallback;

    private void Start() {
        int numberOfEquipmentSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberOfEquipmentSlots];
        inventory = Inventory.instance;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.U)) {
            UnequipAll();
        }
    }


    public void Equip(Equipment newEquipment) {
        int slotIndex = (int)newEquipment.equipmentSlot;
        Equipment oldEquipment = null;
        
        if (currentEquipment[slotIndex] != null) {
            if (currentEquipment[slotIndex] != newEquipment) {
                oldEquipment = currentEquipment[slotIndex];
                inventory.AddToInventory(oldEquipment);
            }
        }
        currentEquipment[slotIndex] = newEquipment;
        inventory.RemoveFromInventory(newEquipment);

        if (onEquipmentChangedCallback != null)
            onEquipmentChangedCallback.Invoke(newEquipment, oldEquipment);
    }

    public void Unequip(Equipment equipment) {
        if (equipment != null) {
            int slotIndex = (int) equipment.equipmentSlot;
            if (currentEquipment[slotIndex] != null) {
                Equipment oldEquipment = currentEquipment[slotIndex];
                inventory.AddToInventory(oldEquipment);

                currentEquipment[slotIndex] = null;

                if (onEquipmentChangedCallback != null)
                    onEquipmentChangedCallback.Invoke(null, oldEquipment);
            }
        }
    }

    public void UnequipAll() {
        for (int i = 0; i < currentEquipment.Length - 1; i++) {
            Unequip(currentEquipment[i]);
        }
    }







}

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


    // 0: RightHand, 1: LeftHand
    public GameObject[] equipmentAttachmentPoints;

    GameObject[] currentEquipmentGOOnPlayer;
    Equipment[] currentEquipment;

    Inventory inventory;

    public delegate void OnEquipmentChanged(Equipment newEquipment, Equipment oldEquipment);
    public OnEquipmentChanged onEquipmentChangedCallback;

    private void Start() {
        int numberOfEquipmentSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberOfEquipmentSlots];
        currentEquipmentGOOnPlayer = new GameObject[numberOfEquipmentSlots];
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
        if (currentEquipmentGOOnPlayer[slotIndex] != null) {
            UnequipGOFromPlayer(slotIndex);
        }

        currentEquipment[slotIndex] = newEquipment;
        inventory.RemoveFromInventory(newEquipment);

        if (newEquipment.itemPrefab != null) {
            EquipGOToPlayer(newEquipment, slotIndex);
        }

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

                if (currentEquipmentGOOnPlayer[slotIndex] != null) {
                    UnequipGOFromPlayer(slotIndex);
                }

                if (onEquipmentChangedCallback != null)
                    onEquipmentChangedCallback.Invoke(null, oldEquipment);
            }
        }
    }

    public void UnequipAll() {
        for (int i = 0; i < currentEquipment.Length; i++) {
            Unequip(currentEquipment[i]);
        }
    }

    public bool isEquiped(Equipment equipment) {
        int slotIndex = (int) equipment.equipmentSlot;
        if (currentEquipment[slotIndex] != null && currentEquipment[slotIndex] == equipment) {
           return true;
        }
        return false;
    }

    public bool isEquiped(GameObject equipmentGO) {
        for (int i = 0; i < currentEquipmentGOOnPlayer.Length; i++) {
            if (equipmentGO == currentEquipmentGOOnPlayer[i]) {
                return true;
            }
        }
        return false;
    }

    void EquipGOToPlayer(Equipment equipment, int slotIndex) {
        GameObject equipmentGO = Instantiate(equipment.itemPrefab);
        Transform equipmentTransform = equipmentGO.transform;
        equipmentTransform.parent = equipmentAttachmentPoints[slotIndex].transform;
        equipmentTransform.localPosition = equipment.playerAttachmentPositionModifier;
        equipmentTransform.localEulerAngles = equipment.playerAttachmentRotationModifier;
        equipmentTransform.localScale = equipment.playerAttachmentScaleModifier;
        currentEquipmentGOOnPlayer[slotIndex] = equipmentGO;
    }

    void UnequipGOFromPlayer(int slotIndex) {
        Destroy(currentEquipmentGOOnPlayer[slotIndex]);
        currentEquipmentGOOnPlayer[slotIndex] = null;
    }
    



}

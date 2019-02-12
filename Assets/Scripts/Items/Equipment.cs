using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item	{

    public EquipmentSlot equipmentSlot;

    // equipment modifiers can be added here


    public override void UseItem() {
        base.UseItem();

        EquipmentManager.instance.Equip(this);
    }

}


public enum EquipmentSlot { RightHand, LeftHand, Head, Chest, Legs, Feet}
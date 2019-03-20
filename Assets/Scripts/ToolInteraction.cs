using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolInteraction : Interactable	{

    // equipment required to interact with this object
    public Equipment requiredEquipment;
    EquipmentManager equipmentManager;

    private void Start() {
        equipmentManager = EquipmentManager.instance;
    }

    public override bool Interact() {
        if (CheckEquipmentOnPlayer()) {
            return true;
        }
        Debug.Log("Player has not equiped the required tool");
        return false;
    }



    bool CheckEquipmentOnPlayer() {
        return equipmentManager.isEquiped(this.requiredEquipment);
    }

}

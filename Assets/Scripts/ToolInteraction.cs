using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActionLogic))]
public class ToolInteraction : Interactable	{

    // equipment required to interact with this object
    public Equipment requiredEquipment;


    EquipmentManager equipmentManager;
    ActionLogic action;

    private void Start() {
        equipmentManager = EquipmentManager.instance;
        action = GetComponent<ActionLogic>();
    }

    public override bool Interact() {
        if (CheckEquipmentOnPlayer()) {
            action.DoAction();
            return true;
        }
        Debug.Log("Player has not equiped the required tool");
        action.FailedToDoAction();
        return false;
    }



    bool CheckEquipmentOnPlayer() {
        return equipmentManager.isEquiped(this.requiredEquipment);
    }

}

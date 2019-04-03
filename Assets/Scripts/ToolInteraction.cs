using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolInteraction : Interactable	{

    // equipment required to interact with this object
    public Equipment requiredEquipment;
    EquipmentManager equipmentManager;

    [SerializeField] private GameEvent gameEventSuccess = null;
    [SerializeField] private GameEvent gameEventFail = null;


    private void Start() {
        equipmentManager = EquipmentManager.instance;
    }

    public override bool Interact() {
        if (CheckEquipmentOnPlayer()) {
            Debug.Log("Equiped ok! triggering event");
            if (gameEventSuccess != null)
                gameEventSuccess.Raise();
            return true;
        }
        Debug.Log("Player has not equiped the required tool");
        if (gameEventFail != null)
            gameEventFail.Raise();
        return false;
    }



    bool CheckEquipmentOnPlayer() {
        return equipmentManager.isEquiped(this.requiredEquipment);
    }

}

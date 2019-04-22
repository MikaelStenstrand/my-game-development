using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInteractable : Interactable {

    [SerializeField] GameEvent gameEventOn;
    [SerializeField] GameEvent gameEventOff;

    [SerializeField] BoolReference switchState;

    public override bool Interact() {
        if (switchState.Value) {
            if (gameEventOff != null) {
                Debug.Log("Switching off");
                switchState.Value = false;
                gameEventOff.Raise();
                return true;
            }
        } else {
            if (gameEventOn != null) {
                Debug.Log("Switching on");
                switchState.Value = true;
                gameEventOn.Raise();
                return true;
            }
        }
        return false;
    }



}
